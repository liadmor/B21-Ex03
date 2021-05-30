using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

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
            Console.WriteLine(
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
            Console.WriteLine("\t\tWELCOME TO GILIAD GARAGE");
            mainMenu();
        }

        private void mainMenu()
        {
            bool exitGarage = false;
            int getOption;

            while (!exitGarage)
            {
                presentUserMenu();
                try
                {
                    getOption = Validation.ReceiveEnumInput<eGarageMenu>();

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
                catch (FormatException)
                {
                    Console.WriteLine("You need to choose one of the given option");
                }
            }
        }

        private void PressEnterToMainMenu()
        {
            Console.WriteLine("Press ENTER to return the Main Menu");
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
            int selectedVehicleType = -1;
            int indexToChoose = 1;
            Vehicle newVehicle = null;
            string[] possibleVehiclesTypes = Enum.GetNames(typeof(Factory.ePossibleVehicles));
            StringBuilder possibleVehiclesToChoose = new StringBuilder();

            foreach (string vehicleType in possibleVehiclesTypes)
            {
                possibleVehiclesToChoose.AppendLine(string.Format("{0}\t{1}", indexToChoose, vehicleType));
                indexToChoose++;
            }
            while (selectedVehicleType == -1)
            {
                try
                {
                    Console.WriteLine("Please select the vehicle type: \n" + possibleVehiclesToChoose);
                    selectedVehicleType = Validation.ReceiveEnumInput<Factory.ePossibleVehicles>();
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to choose one of the given option");
                }

            }
            try
            {
                newVehicle = Factory.NewVehicle((Factory.ePossibleVehicles)selectedVehicleType);
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
            }
            catch (FormatException)
            {
                Console.WriteLine("You need to choose one of the given option");
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
            Console.Write("Phone number: ");
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
            int filterLicense = -1;

            Console.WriteLine(@"Please enter the filter where you would like to print the license list - choose an option: 
                                        1   InRepaired
                                        2   Repaired
                                        3   Paid");
                try
                {
                    filterLicense = Validation.ReceiveEnumInput<Garage.OwnerInformation.eVehicleStatus>();
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to choose one of the given option");
                }

            StringBuilder licenseNumbersString = new StringBuilder();
            List<string> ListLicenseNumbers = r_NewGarage.ListOfLicensingNumberOfTheVehicleInTheGarageByStatus((Garage.OwnerInformation.eVehicleStatus)filterLicense);
            licenseNumbersString.AppendFormat("The license number in the gerage that {0}: {1}", (Garage.OwnerInformation.eVehicleStatus)filterLicense, Environment.NewLine);
            foreach (string licenseNumber in ListLicenseNumbers)
            {
                licenseNumbersString.Append(licenseNumber);
                licenseNumbersString.Append(Environment.NewLine);
            }
            Console.WriteLine(licenseNumbersString);
        }

        private void ChangeStatusVehicle()
        {
            int newStatus;

            Console.WriteLine(
            @"Please enter the new status of the vehicle - choose an option: 
            1   InRepaired
            2   Repaired
            3   Paid");
            try
            {
                newStatus = Validation.ReceiveEnumInput<Garage.OwnerInformation.eVehicleStatus>();
                string VihecleLicense = getLicenseNumberFromUser();
                if (IsTheLicenseInGarege(VihecleLicense))
                {
                    r_NewGarage.ChangeStatusVehicle(VihecleLicense, (Garage.OwnerInformation.eVehicleStatus)newStatus);
                    Console.WriteLine("the vehicle Status has been change");
                }
                else
                {
                    Console.WriteLine("The license number is not in the garage");
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("You need to choose one of the given option");
            }
        }

        private bool IsTheLicenseInGarege(string i_LicenseNumber)
        {
            bool isLicenseInGarage = true;
            if (!r_NewGarage.IsInGarege(i_LicenseNumber))
            {
                isLicenseInGarage = false;
                Console.WriteLine("This vehicle is not in the garage");
            }

            return isLicenseInGarage;
        }

        private void InflateTiresToMax()
        {
            string VihecleLicense;

            do
            {
                VihecleLicense = getLicenseNumberFromUser();
            } while (!IsTheLicenseInGarege(VihecleLicense));

            Console.WriteLine("inflating, please wait...");
            r_NewGarage.InflateTiresToMax(VihecleLicense);
            Console.WriteLine("Done!");

        }

        private void RefuelVehicle()
        {
            string VihecleLicense;

            VihecleLicense = getLicenseNumberFromUser();
            if (IsTheLicenseInGarege(VihecleLicense)) { 

                if (r_NewGarage.VehicleInTheGarage[VihecleLicense].Vehicle is FuelBasedVehicles)
                {

                    Console.WriteLine(
                                        @"Fuel Type:
                                1   Soler
                                2   Octan95
                                3   Octan96
                                4   Octan98
                                Please select Fuel type: ");
                    int FuelType;
                    string AmountToFillInput;
                    float AmountToFill;

                    try
                    {
                        FuelType = Validation.ReceiveEnumInput<FuelBasedVehicles.eFuelType>();
                        Console.WriteLine("Please enter the amount to fill");
                        do
                        {
                            AmountToFillInput = Console.ReadLine();

                        } while (!ValidInputFloat(AmountToFillInput));

                        AmountToFill = float.Parse(AmountToFillInput);
                        r_NewGarage.RefuelAFuelBasedVehicle(VihecleLicense, (FuelBasedVehicles.eFuelType)FuelType, AmountToFill);
                        Console.WriteLine("Refuel succese");
                    }
                    catch (ArgumentException)
                    {
                        Console.Write(" This vehicle does not get this type of fuel type");
                    }
                    catch (ValueOutOfRangeException ValueOutOfRange)
                    {
                        Console.WriteLine(ValueOutOfRange.Message);
                    }
                }

                else
                {
                    Console.WriteLine("This is a electric car. Please choose the recharge option");
                }
            
            }

        }

        private void ChargeVehicle()
        {

            string VihecleLicense;
            string AmountToFillInput;
            float AmountToFill;

            
            VihecleLicense = getLicenseNumberFromUser();
            if (IsTheLicenseInGarege(VihecleLicense))
            {
                if (r_NewGarage.VehicleInTheGarage[VihecleLicense].Vehicle is ElectricBasedVehicles)
                {
                    try
                    {
                        Console.WriteLine("Please enter the amount to fill in minutes");
                        do
                        {
                            AmountToFillInput = Console.ReadLine();

                        } while (!ValidInputFloat(AmountToFillInput));

                        AmountToFill = float.Parse(AmountToFillInput);
                        r_NewGarage.ChargeAnElectricBasedVehicle(VihecleLicense, (AmountToFill / 60));
                        Console.WriteLine("Recharge succese");
                    }
                    catch (ValueOutOfRangeException ValueOutOfRange)
                    {
                        Console.WriteLine(ValueOutOfRange.Message);
                    }
                }
                else
                {
                    Console.WriteLine("This is a fuel based vehicle! please choose the refuel option");
                }
            }
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
            //bool isValidAirPressure;
            string manufacturerName;
            string CurrentAirPressureInput;
            float CurrentAirPressure = 0;

            Console.Write("Please enter the manufacturer's name of the tires:   ");
            do
            {
                manufacturerName = Console.ReadLine();
                isValidManufacture = Validation.CheckName(manufacturerName);
            }
            while (!isValidManufacture);

            while (CurrentAirPressure == 0)
            {
                try
                {
                    Console.Write("Please enter the current air pressure of the tires, where the maximum air pressure is {0}    ", i_newVehicle.MaxTireAirPressure);
                    do
                    {
                        CurrentAirPressureInput = Console.ReadLine();

                    } while (!ValidInputFloat(CurrentAirPressureInput));

                    CurrentAirPressure = float.Parse(CurrentAirPressureInput);
                    i_newVehicle.SetTireInfo(manufacturerName, i_newVehicle.MaxTireAirPressure, CurrentAirPressure);
                }
                catch (ValueOutOfRangeException valueOutOfRange)
                {
                    Console.WriteLine(valueOutOfRange.Message);
                    CurrentAirPressure = 0;
                }
            }
        }

        private void GetLicenseTypeFromUser(Vehicle i_newVehicle)
        {
            int licenseType = -1;

            Console.WriteLine(
                @"Please enter the license type - choose an option: 
                1   A
                2   B1
                3   AA
                4   BB");
            while (licenseType == -1)
                try
                {

                    licenseType = Validation.ReceiveEnumInput<Motorcycle.eLicenseType>();

                    if (i_newVehicle is FuelBasedMotorcycle)
                    {
                        ((i_newVehicle as FuelBasedVehicles) as FuelBasedMotorcycle).LicenseType = (Motorcycle.eLicenseType)licenseType;
                    }
                    else
                    {
                        ((i_newVehicle as ElectricBasedVehicles) as ElectricMotorcycle).LicenseType = (Motorcycle.eLicenseType)licenseType;

                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to choose one of the given option");
                    licenseType = -1;
                }
        }

        private void GetEngineCapacityFromUser(Vehicle i_newVehicle)
        {
            int engineCapacity;
            bool isValidEngineCapacity = false;

            Console.WriteLine(@"Please enter the engine capacity in cc: must be Positiv number ");
            do
            {
                try
                {
                    engineCapacity = int.Parse(Console.ReadLine());
                    isValidEngineCapacity = Validation.CheckEngineCapacity(engineCapacity);

                    if (i_newVehicle is FuelBasedMotorcycle)
                    {
                        ((i_newVehicle as FuelBasedVehicles) as FuelBasedMotorcycle).Enginecapacity = engineCapacity;
                    }
                    else
                    {
                        ((i_newVehicle as ElectricBasedVehicles) as ElectricMotorcycle).EngineCapacity = engineCapacity;

                    }
                }
                catch (FormatException)
                {
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!isValidEngineCapacity);

        }


        private void GetCurrentEnergyAmountFromUser(Vehicle i_newVehicle)
        {
            float currentEnergy, MaxEnergy;
            bool isValidCurrenEnergy = false;

            MaxEnergy = i_newVehicle.MaxEnergySource;
            Console.Write(@"Please enter the current energy amount, the maximum is {0}  ", i_newVehicle.MaxEnergySource);

            do
            {
                try
                {
                    currentEnergy = float.Parse(Console.ReadLine());
                    isValidCurrenEnergy = Validation.CheckCurrentEnergy(currentEnergy, MaxEnergy);
                    i_newVehicle.CurrentEnergySource = currentEnergy;
                }
                catch (FormatException)
                {
                }
                catch (ValueOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!isValidCurrenEnergy);


        }

        private void GetDoorsNumberFromUser(Vehicle i_newVehicle)
        {
            int doorsNumber = -1;

            Console.WriteLine(
                @"Please enter the number of doors: 
                2   
                3    
                4    
                5");
            while (doorsNumber == -1)
            {
                try
                {
                    doorsNumber = Validation.ReceiveEnumInput<Car.eNunDoors>();
                    if (i_newVehicle is FuelBasedCar)
                    {
                        ((i_newVehicle as FuelBasedVehicles) as FuelBasedCar).NumberOfDoors = (Car.eNunDoors)doorsNumber;
                    }
                    else
                    {
                        ((i_newVehicle as ElectricBasedVehicles) as ElectricCar).NumberOfDoors = (Car.eNunDoors)doorsNumber;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to choose one of the given option");
                    doorsNumber = -1;
                }
            }
        }

        private void GetColorFromUser(Vehicle i_newVehicle)
        {
            int color = -1;

            Console.WriteLine(
            @"Please enter the car's color: 
            1   Red
            2   Black,
            3   White,
            4   Silver");
            while (color == -1)
            {
                try
                {
                    color = Validation.ReceiveEnumInput<Car.eColor>();
                    if (i_newVehicle is FuelBasedCar)
                    {
                        ((i_newVehicle as FuelBasedVehicles) as FuelBasedCar).Color = (Car.eColor)color;
                    }
                    else
                    {
                        ((i_newVehicle as ElectricBasedVehicles) as ElectricCar).Color = (Car.eColor)color;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You need to choose one of the given option");
                    color = -1;
                }
            }
        }

        private void GetIfDangerusSubstences(Vehicle i_newVehicle)
        {
            bool dangerusSubstences;
            bool isValidAnswerDangerus;
            string inputToCheck;

            Console.Write(@"Is the truck contains dangerus substences? enter True or False  ");
            do
            {
                inputToCheck = Console.ReadLine();
                isValidAnswerDangerus = Validation.CheckAnsDangerus(inputToCheck);
            }
            while (!isValidAnswerDangerus);
            dangerusSubstences = bool.Parse(inputToCheck);

            ((i_newVehicle as FuelBasedVehicles) as Truck).IsContainDangerousSubstances = dangerusSubstences;
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
