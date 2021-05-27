using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class UserInterface
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
                    int getOption = GarageLogic.Validation.ReceiveEnumInput<eGarageMenu>();

                    if (menuOption == k_ExitProgram)
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
                selectedVehicleType = GarageLogic.Validation.ReceiveEnumInput<Factory.ePossibleVehicles>();
                Vehicle newVehicle = Factory.NewVehicle((Factory.ePossibleVehicles)selectedVehicleType);
                newVehicle.m_LicensingNumber = i_LicenseNumber;
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
                    isValidName = GarageLogic.Validation.CheckOwnerName(ownerName);
                }
                while (!isValidName);

                o_OwnerName = ownerName;
                Console.Write("Phone-number: ");
                do
                {
                    ownerPhoneNumber = Console.ReadLine();
                    isValidPhoneNumber = GarageLogic.Validation.CheckOwnerPhoneNumber(ownerPhoneNumber);
                }
                while (!isValidPhoneNumber);

                o_PhoneNumber = ownerPhoneNumber;
            }


            private void addNewVehicleToGarage(Vehicle i_NewVehicle)
            {
                string ownerName, ownerPhoneNumber;
                bool isValidInput;

                receiveVehicleOwnerInformation(out ownerName, out ownerPhoneNumber);
                //i_NewVehicle.UpdateProperties(userDialogueInputsList);
                r_NewGarage.AddNewVehicle(ownerName, ownerPhoneNumber, i_NewVehicle);
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

                int filterLicense = int.Parse(Console.ReadLine());
                StringBuilder licenseNumbersString = new StringBuilder();
                List<string> ListLicenseNumbers = r_NewGarage.ListOfLicensingNumberOfTheVehicleInTheGarageByStatus((Garage.OwnerInformation.eVehicleStatus)filterLicense);
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
                r_NewGarage.ChangeStatusVehicle(VihecleLicense, (Garage.OwnerInformation.eVehicleStatus)newStatus);
            }

            private void InflateTiresToMax()
            {
                string VihecleLicense = getLicenseNumberFromUser();
                r_NewGarage.InflateTiresToMax(VihecleLicense);
            }

            private void RefuelVehicle()
            {
                string VihecleLicense = getLicenseNumberFromUser();
                FuelBasedVehicles.eFuelType FuelType = (r_NewGarage.VehicleInTheGarage[VihecleLicense].Vehicle as FuelBasedVehicles).VehicleFuelType;
                Console.WriteLine("Please enter the amount to fill");
                float AmountToFill = float.Parse(Console.ReadLine());
                r_NewGarage.RefuelAFuelBasedVehicle(VihecleLicense, FuelType, AmountToFill );
            }

            private void ChargeVehicle()
            {
                string VihecleLicense = getLicenseNumberFromUser();
                Console.WriteLine("Please enter the amount to fill");
                float AmountToFill = float.Parse(Console.ReadLine());
                r_NewGarage.ChargeAnElectricBasedVehicle(VihecleLicense, AmountToFill);    
            }

            private void ShowVehicleInformation()
            {
                string VihecleLicense = getLicenseNumberFromUser();
                r_NewGarage.VehicleInTheGarage[VihecleLicense].Vehicle.ToString();
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
                    isValidLicenseNumber = GarageLogic.Validation.CheckLicenseNumber(licenseNumber);
                }
                while (!isValidLicenseNumber);

                return licenseNumber;
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
                        //not finish
                        break;
                    case eGarageMenu.Exit:
                        exitSystem();
                        break;
                }
            }

    }
}
