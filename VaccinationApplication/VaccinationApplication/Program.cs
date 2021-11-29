using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationApplication
{
    /// <summary>
    /// This is the program for Vaccination Application
    /// </summary>
    class Program
    {


       public static List<BeneficiaryDetails> beneficiaryDetails = new List<BeneficiaryDetails>();

        static void Main(string[] args)
        {
            int homePageOption;
            do
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(">>Home");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("\nSpecify your Option:\n1.Beneficiary Registration\n2.Vacccination\n3.Exit");

                homePageOption = int.Parse(Console.ReadLine());
                switch (homePageOption)
                {
                    case 1:
                        AddBeneficiaryDetails(homePageOption);
                        break;
                    case 2:
                         VaccinationProcess();
                        break;
                    case 3:
                        Console.WriteLine("Thank You");
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (homePageOption != 3);


        }

        //Registration Process For New User
        private static void AddBeneficiaryDetails(int dose)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(">>Home>>Adding Beneficiary");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your your Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your Gender:\n1.Male\n2.Female\n3.Transgender");
            int gender = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Phone number:");
            long mobile = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Address:");
            string address = Console.ReadLine();
            BeneficiaryDetails beneficiary = new BeneficiaryDetails(name, mobile, address, age, gender);
            Console.WriteLine($"Hi {beneficiary.Name} your Registration ID is {beneficiary.RegistrationID}");
            beneficiaryDetails.Add(beneficiary);

        }
        //Vaccination Process After Registration
        private static void VaccinationProcess()
        {

            bool flag = true;
            do
            {
                ShowListOfBeneficiaries();
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(">>Home>>Vaccination");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Enter your registration ID:");
                int registeredId = int.Parse(Console.ReadLine());
                BeneficiaryDetails currentBenificiary = null;
                foreach (BeneficiaryDetails beneficiary in beneficiaryDetails)//traverse in beneficiary list to find specific beneficiary
                {
                    if (registeredId == beneficiary.RegistrationID)
                    {
                        currentBenificiary = beneficiary;
                    }
                }
               
                if (currentBenificiary != null)
                {
                    int beneficiaryOption = 1;
                    do
                    {
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine(">>Home>>Vaccination");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine($"Hi {currentBenificiary.Name} \nSpecify your options:\n1.Take Vaccination\n2.Vaccination History\n3.Next Dose Due Date\n4.Go to Main Menu");
                        beneficiaryOption = int.Parse(Console.ReadLine());
                        switch (beneficiaryOption)
                        {
                            case 1:
                                TakeVaccination(currentBenificiary);
                                break;
                            case 2:
                               VaccinationHistory(currentBenificiary);
                                break;
                            case 3:
                                Console.WriteLine(currentBenificiary.DueDate());
                                break;
                            case 4:
                                flag = false;//to stop the loop
                                break;
                            default:
                                Console.WriteLine("invalid input");
                                break;



                        }
                    } while (beneficiaryOption != 4);
                }
                //executes when Condition is false
                else
                {
                    Console.WriteLine("Incorrect registration number");
                }
            } while (flag);


        }

        private static void TakeVaccination(BeneficiaryDetails currentBeneficiary)
        {

            do
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine(">>Home>>Vaccination>>Take Vaccination");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Choose your Vaccine:\n1.Covaxin\n2.Covishield\n3.Sputnic");
                int vaccineType = int.Parse(Console.ReadLine());
                if (currentBeneficiary.VaccinatedDetails.Count == 0)//checks whether beneficiary has vaccination history
                {
                    Console.WriteLine("Enter Date in dd/mm/yyyy");
                    string enteredDate = Console.ReadLine();
                    string[] splitDate = enteredDate.Split('/');
                    DateTime date = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
                    Console.WriteLine($"You are Vaccinated {currentBeneficiary.Vaccinate(vaccineType, date)}");
                    break;
                }
                else if (currentBeneficiary.VaccinatedDetails.Count == 1)//checks for the beneficiary has first dose
                {
                    if ((VaccineType)vaccineType == currentBeneficiary.VaccinatedDetails[0].Vaccine)//To check 1st dose vaccine with choosen vaccine
                    {
                        Console.WriteLine("Enter Date in dd/mm/yyyy");
                        string enteredDate = Console.ReadLine();
                        string[] splitDate = enteredDate.Split('/');
                        DateTime date = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
                        Console.WriteLine(currentBeneficiary.Vaccinate(vaccineType, date));
                        break;
                    }
                    else//executes when choosen vaccine is different from 1st dose
                    {
                        Console.WriteLine($"You have selected different vaccine. Your First vaccine is {currentBeneficiary.VaccinatedDetails[0].Vaccine}");
                    }
                }

            } while (true);
        }

        private static void VaccinationHistory(BeneficiaryDetails currentBeneficiary)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(">>Home>>Vaccination>> Vacination History");
            Console.WriteLine("-------------------------------------------");
            foreach (VaccineDetails detail in currentBeneficiary.VaccinatedDetails)//traverse through vaccinated details list
            {
                Console.WriteLine($"Vaccine: {detail.Vaccine} | Dosage:{detail.Dosage} dose | Date:{detail.VaccinatedDate.ToString("dd/MM/yyyy")}");
            }


        }

        private static void ShowListOfBeneficiaries()
        {
            foreach (BeneficiaryDetails beneficiary in beneficiaryDetails)
            {
                Console.WriteLine($"REGISTRATION ID: {beneficiary.RegistrationID} | BENEFICIARY NAME:{beneficiary.Name}");
            }
        }
    }
}
