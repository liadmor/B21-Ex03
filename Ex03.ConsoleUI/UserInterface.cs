using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class UserInterface
    {
        private const int k_ExitProgram = 9;
        private readonly Garage r_NewGarage;

        internal enum eGarageMenu
        {
            AddNewVehicle = 1,
            ListOfLicensingNumberOfTheVehicleInTheGarage = 2,
            ListOfLicensingNumberOfTheVehicleInTheGarageByStatus = 3,
            ChangeStatusVehicle = 4,
            InflateTiresToMax = 5,
            RefuelAFuelBasedVehicle = 6,
            ChargeAnElectricBasedVehicle = 7,
            DisplayVehicleInformation = 8,
            Exit = 9
        }

        private void presentUserMenu()
        {
            Console.Write(
                            @"Garage Menu - please choose an option: 
                                        1   Add New Vehicle
                                        2   Show List Of License Numbers Of The Vehicles In The Garage
                                        3   Show List Of License Numbers Of The Vehicles In The Garage By Status
                                        4   Change Vehicle's status
                                        5   Inflate Tires To Maximum
                                        6   Refuel A Fuel Based Vehicle
                                        7   Charge A Electric Based Vehicle
                                        8   Display Vehicle Information
                                        9   Exit
                                        ");
        }

        internal UserInterface()
        {
            r_NewGarage = new Garage();
            mainMenu();
        }

        private void mainMenu()
        {
            bool exitGarage = false;

            while (!exitGarage)
            {
                presentUserMenu();
                int getOption = Validation.ReceiveEnumInput<eGarageMenu>();

                if (getOption == k_ExitProgram)
                {
                    exitGarage = true;
                    break;
                }

                GarageMenuOperation((eGarageMenu)getOption);
                if (!exitGarage)
                {
                    PressEnterToMainMenu();

                }
            }
        }

        private void PressEnterToMainMenu()
        {
            Console.Write("Press ENTER to return the Main Menu");
            Console.ReadLine();
            Console.Clear();
        }

        private void newVehicle()
        {
            string licenseNumber = getLicenseNumberFromUser();
            Vehicle newVehicle = createNewVehicle(licenseNumber);
            addNewVehicleToGarage(newVehicle);
        }

        private Vehicle createNewVehicle(string i_LicenseNumber)
        {
            int selectedVehicleType;
            int indexToChoose = 1;
            string[] possibleVehiclesTypes = Enum.GetNames(typeof(Factory.ePossibleVehicles));
            StringBuilder possibleVehiclesToChoose = new StringBuilder();

            foreach (string vehicleType in possibleVehiclesTypes)
            {
                possibleVehiclesToChoose.AppendLine(string.Format("{0}\t{1}", indexToChoose, vehicleType));
                indexToChoose++;
            }

            Console.WriteLine("Please select the vehicle type: " + possibleVehiclesToChoose);
            selectedVehicleType = Validation.ReceiveEnumInput<Factory.ePossibleVehicles>();
            Vehicle newVehicle = Factory.NewVehicle((Factory.ePossibleVehicles)selectedVehicleType);
            newVehicle.LicensingNumber = i_LicenseNumber;
            newVehicle.VehicleType = (Factory.ePossibleVehicles)selectedVehicleType;
            GetTiresInfoFromUser(newVehicle);


            switch (newVehicle.VehicleType)
            {
                case Factory.ePossibleVehicles.ElectricBasedMotorcycle://vehicle is motorcycle
                case Factory.ePossibleVehicles.FuelBasedMotorcycle:
                    GetLicenseTypeFromUser(newVehicle);
                    GetEngineCapacityFromUser(newVehicle);
                    GetCurrentEnergyAmountFromUser(newVehicle);
                    break;

                case Factory.ePossibleVehicles.ElectricBasedCar://vehicle is car
                case Factory.ePossibleVehicles.FuelBaseCar:
                    GetCurrentEnergyAmountFromUser(newVehicle);
                    GetColorFromUser(newVehicle);
                    GetDoorsNumberFromUser(newVehicle);
                    break;

                case Factory.ePossibleVehicles.Truck://vehicle is truck
                    GetCurrentEnergyAmountFromUser(newVehicle);
                    GetIfDangerusSubstences(newVehicle);
                    GetMaxTank(newVehicle);
                    break;

            }
            return newVehicle;
        }


        private void receiveVehicleOwnerInformation(out string o_OwnerName, out string o_PhoneNumber)
        {
            string ownerName, ownerPhoneNumber;
            bool isValidName, isValidPhoneNumber;

            Console.WriteLine("Please Enter The Owner's information");
            Console.Write("Name: ");
            do
            {
                ownerName = Console.ReadLine();
                isValidName = Validation.CheckName(ownerName);
            }
            while (!isValidName);

            o_OwnerName = ownerName;
            Console.Write("Phone-number: ");
            do
            {
                ownerPhoneNumber = Console.ReadLine();
                isValidPhoneNumber = Validation.CheckOwnerPhoneNumber(ownerPhoneNumber);
            }
            while (!isValidPhoneNumber);

            o_PhoneNumber = ownerPhoneNumber;
        }

        private void addNewVehicleToGarage(Vehicle i_NewVehicle)
        {
            string ownerName, ownerPhoneNumber;
            bool isValidInput;

            receiveVehicleOwnerInformation(out ownerName, out ownerPhoneNumber);
            Console.WriteLine(r_NewGarage.AddNewVehicle(ownerName, ownerPhoneNumber, i_NewVehicle));
        }

        private void exitSystem()
        {
            Console.Write("You chose to exit system. Bye!");
        }

        private void showLicenseNumbers()
        {
            StringBuilder licenseNumbersString = new StringBuilder();
            List<string> ListLicenseNumbers = r_NewGarage.ListOfLicensingNumberOfTheVehicleInTheGarage();
            foreach (string licenseNumber in ListLicenseNumbers)
            {
                licenseNumbersString.Append(licenseNumber);
                licenseNumbersString.Append(Environment.NewLine);
            }
            Console.WriteLine(licenseNumbersString);
        }

        private void printLicenseNumbersByStatuse()
        {
            Console.WriteLine(@"Please enter the filter where you would like to print the license list - choose an option: 
                                        1   InRepaired
                                        2   Repaired
                                        3   Paid");
            //TODO change the TOstring;
            int filterLicense = int.Parse(Console.ReadLine());
            StringBuilder licenseNumbersString = new StringBuilder();
            List<string> ListLicenseNumbers = r_NewGarage.ListOfLicensingNumberOfTheVehicleInTheGarageByStatus((Garage.OwnerInformation.eVehicleStatus)filterLicense);
            licenseNumbersString.AppendFormat("The license number in the gerage that {0}", (Garage.OwnerInformation.eVehicleStatus)filterLicense);
            foreach (string licenseNumber in ListLicenseNumbers)
            {
                licenseNumbersString.Append(licenseNumber);
                licenseNumbersString.Append(Environment.NewLine);
            }
            Console.WriteLine(licenseNumbersString);
        }

        private void ChangeStatusVehicle()
        {
            Console.WriteLine(@"Please enter the new status of the vehicle - choose an option: 
                                        1   InRepaired
                                        2   Repaired
                                        3   Paid");

            int newStatus = int.Parse(Console.ReadLine());
            string VihecleLicense = getLicenseNumberFromUser();
            if (IsTheLicenseInGarege(VihecleLicense))
            {
                r_NewGarage.ChangeStatusVehicle(VihecleLicense, (Garage.OwnerInformation.eVehicleStatus)newStatus);

            }
            else
            {
                Console.WriteLine("The license number is not in the garage");
                PressEnterToMainMenu();
            }
        }
        private bool IsTheLicenseInGarege( string i_LicenseNumber)
        {
            return r_NewGarage.IsInGarege(i_LicenseNumber);

        }
        private void InflateTiresToMax()
        {
            string VihecleLicense;

            do
            {
                VihecleLicense = getLicenseNumberFromUser();
            } while (!IsTheLicenseInGarege(VihecleLicense));

            r_NewGarage.InflateTiresToMax(VihecleLicense);
        }

        private void RefuelVehicle()
        {
            string VihecleLicense = getLicenseNumberFromUser();
            FuelBasedVehicles.eFuelType FuelType = (r_NewGarage.VehicleInTheGarage[VihecleLicense].Vehicle as FuelBasedVehicles).VehicleFuelType;
            Console.WriteLine("Please enter the amount to fill");
            float AmountToFill = float.Parse(Console.ReadLine());
            r_NewGarage.RefuelAFuelBasedVehicle(VihecleLicense, FuelType, AmountToFill);
        }

        private void ChargeVehicle()
        {

            //TODO ADD DO WHILE ANTIL WE GET VALID INPUT
            string VihecleLicense = getLicenseNumberFromUser();
            Console.WriteLine("Please enter the amount to fill");
            String amountToFillInput = Console.ReadLine();
            if (!ValidInputFloat(amountToFillInput) || IsTheLicenseInGarege(VihecleLicense))
            {
                PressEnterToMainMenu();
            }
            else
            {
                float AmountToFill = float.Parse(Console.ReadLine());

                r_NewGarage.ChargeAnElectricBasedVehicle(VihecleLicense, AmountToFill);

            }

            //TODO - check if the amount to fill is biger than the max
        }

        private bool ValidInputFloat(string i_input)
        {
            bool ans = true;
            float parseInput;

            try
            {
                parseInput = float.Parse(i_input);
            }
            catch
            {
                Console.WriteLine("The input is invalid");
                ans = false;
            }

            return ans;
        }

        private void ShowVehicleInformation()
        {

            string VihecleLicense;
            do
            {
                VihecleLicense = getLicenseNumberFromUser();
            } while (!IsTheLicenseInGarege(VihecleLicense));

            Console.WriteLine(r_NewGarage.DisplayVehicleInformation(VihecleLicense));
            
            //סוג דלק, מצב מצבר, שאר מידע רלוונטי כתלות בסוג רכב
            //not finish
        }

        private string getLicenseNumberFromUser()
        {
            bool isValidLicenseNumber;
            string licenseNumber;

            Console.Write("Please enter the license number: ");
            do
            {
                licenseNumber = Console.ReadLine();
                isValidLicenseNumber = Validation.CheckLicenseNumber(licenseNumber);
            }
            while (!isValidLicenseNumber);

            return licenseNumber;
        }

        private void GetTiresInfoFromUser(Vehicle i_newVehicle)
        {
            bool isValidManufacture;
            bool isValidAirPressure;
            string manufacturerName;
            string CurrentAirPressureInput;
            float CurrentAirPressure;

            Console.Write("Please enter the manufacturer's name of the tires:   ");
            do
            {
                manufacturerName = Console.ReadLine();
                isValidManufacture = Validation.CheckName(manufacturerName);
            }
            while (!isValidManufacture);

            Console.Write("Please enter the current air pressure of the tires:   ");
            do
            {
                CurrentAirPressureInput = Console.ReadLine();
                //TODO check if the input bigger than the max
                isValidAirPressure = Validation.CheckAirPressure(CurrentAirPressureInput);
            }
            while (!isValidAirPressure);

            CurrentAirPressure = float.Parse(CurrentAirPressureInput);
            i_newVehicle.SetTireInfo(manufacturerName, i_newVehicle.MaxTireAirPressure, CurrentAirPressure);
        }

        private void GetLicenseTypeFromUser(Vehicle i_newVehicle)
        {
            int licenseType;
            string licenseTypeInput;
            bool isValidLicenseType;

            Console.Write(@"Please enter the license type - choose an option: 
                                        1   A
                                        2   B1
                                        3   AA
                                        4   BB");

            do
            {
                licenseTypeInput = Console.ReadLine();
                isValidLicenseType = Validation.CheckColorCar(licenseTypeInput);
            }
            while (!isValidLicenseType);

            licenseType = int.Parse(licenseTypeInput);
            if (i_newVehicle is FuelBasedMotorcycle)
            {
                ((i_newVehicle as FuelBasedVehicles) as FuelBasedMotorcycle).LicenseType = (Motorcycle.eLicenseType)licenseType;
            }
            else
            {
                ((i_newVehicle as ElectricBasedVehicles) as ElectricMotorcycle).LicenseType = (Motorcycle.eLicenseType)licenseType;

            }
        }

        private void GetEngineCapacityFromUser(Vehicle i_newVehicle)
        {
            int engineCapacity;
            bool isValidEngineCapacity;

            Console.Write(@"Please enter the engine capacity in cc: must be Positiv number ");
            do
            {

                //TODO try catch
                engineCapacity = int.Parse(Console.ReadLine());
                isValidEngineCapacity = Validation.CheckEngineCapacity(engineCapacity);
            }
            while (!isValidEngineCapacity);
            if (i_newVehicle is FuelBasedMotorcycle)
            {
                ((i_newVehicle as FuelBasedVehicles) as FuelBasedMotorcycle).Enginecapacity = engineCapacity;
            }
            else
            {
                ((i_newVehicle as ElectricBasedVehicles) as ElectricMotorcycle).EngineCapacity = engineCapacity;

            }

        }

        private void GetCurrentEnergyAmountFromUser(Vehicle i_newVehicle)
        {
            float currentEnergy, MaxEnergy;
            bool isValidCurrenEnergy;

            MaxEnergy = i_newVehicle.MaxEnergySource;
            Console.Write(@"Please enter the current engine capacity: ");

            do
            {
                //TODO TRY CATCH
                //ADD TO THE PRINT THE MAXCAPACITY
                currentEnergy = float.Parse(Console.ReadLine());
                isValidCurrenEnergy = Validation.CheckCurrentEnergy(currentEnergy, MaxEnergy);
            }
            while (!isValidCurrenEnergy);

            i_newVehicle.CurrentEnergySource = currentEnergy;
        }

        private void GetDoorsNumberFromUser(Vehicle i_newVehicle)
        {
            int doorsNumber;
            bool isValidDoorsNumber;

            Console.Write(@"Please enter the number of doors: 
                                       2   
                                       3    
                                       4    
                                       5");

            do
            {
                doorsNumber = int.Parse(Console.ReadLine());
                isValidDoorsNumber = GarageLogic.Validation.CheckDoorsNumber(doorsNumber);
            }
            while (!isValidDoorsNumber);
            if (i_newVehicle is FuelBasedCar)
            {
                ((i_newVehicle as FuelBasedVehicles) as FuelBasedCar).NumberOfDoors = (Car.eNunDoors)doorsNumber;
            }
            else
            {
                ((i_newVehicle as ElectricBasedVehicles) as ElectricCar).NumberOfDoors = (Car.eNunDoors)doorsNumber;
            }

        }
        private void GetColorFromUser(Vehicle i_newVehicle)
        {
            int color;
            String colorInput;
            bool isValidColor;

            Console.Write(@"Please enter the car's color: 
                                                            1   Red
                                                            2   Black,
                                                            3   White,
                                                            4   Silver");

            do
            {
                colorInput = Console.ReadLine();
                isValidColor = Validation.CheckColorCar(colorInput);
            }
            while (!isValidColor);

            color = int.Parse(colorInput);
            if (i_newVehicle is FuelBasedCar)
            {
                ((i_newVehicle as FuelBasedVehicles) as FuelBasedCar).Color = (Car.eColor)color;
            }
            else
            {
                ((i_newVehicle as ElectricBasedVehicles) as ElectricCar).Color = (Car.eColor)color;
            }
        }

        private void GetIfDangerusSubstences(Vehicle i_newVehicle)
        {
            bool dangerusSubstences;
            bool isValidAnswerDangerus;
            string inputToCheck;

            Console.Write(@"Is the truck contains dangerus substences? enter True or False");
            do
            {
                inputToCheck = Console.ReadLine();
                isValidAnswerDangerus = GarageLogic.Validation.CheckAnsDangerus(inputToCheck);
            }
            while (!isValidAnswerDangerus);
            dangerusSubstences = bool.Parse(inputToCheck);

            ((i_newVehicle as FuelBasedVehicles) as Truck).IsContainDangerouSsubstance = dangerusSubstences;
        }
        private void GetMaxTank(Vehicle i_newVehicle)
        {
            string inputMaxCarryWeight;
            float maxCarryWeight;
            bool isValidMaxWeight;

            Console.Write(@"Enter maximum carry weight of truck: ");
            do
            {
                inputMaxCarryWeight = Console.ReadLine();
                isValidMaxWeight = GarageLogic.Validation.CheckMaxTank(inputMaxCarryWeight);
            }
            while (!isValidMaxWeight);

            maxCarryWeight = float.Parse(inputMaxCarryWeight);
            ((i_newVehicle as FuelBasedVehicles) as Truck).MaxCarryingWeight = maxCarryWeight;
        }

        private void GarageMenuOperation(eGarageMenu i_OptionSelection)
        {
            Console.Clear();
            switch (i_OptionSelection)
            {
                case eGarageMenu.AddNewVehicle:
                    newVehicle();
                    break;
                case eGarageMenu.ListOfLicensingNumberOfTheVehicleInTheGarage:
                    showLicenseNumbers();
                    break;
                case eGarageMenu.ListOfLicensingNumberOfTheVehicleInTheGarageByStatus:
                    printLicenseNumbersByStatuse();
                    break;
                case eGarageMenu.ChangeStatusVehicle:
                    ChangeStatusVehicle();
                    break;
                case eGarageMenu.InflateTiresToMax:
                    InflateTiresToMax();
                    break;
                case eGarageMenu.RefuelAFuelBasedVehicle:
                    RefuelVehicle();
                    break;
                case eGarageMenu.ChargeAnElectricBasedVehicle:
                    ChargeVehicle();
                    break;
                case eGarageMenu.DisplayVehicleInformation:
                    ShowVehicleInformation();
                    //TODO not finish
                    break;
                case eGarageMenu.Exit:
                    exitSystem();
                    break;
            }
        }

    }
}
