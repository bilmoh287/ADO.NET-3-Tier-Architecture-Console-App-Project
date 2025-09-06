using System;
using System.Data;
using ContactsBusinessLayer;

namespace ContactsConsoleAppPresentationLayer
{
    internal class Program
    {
        public static void testFindContactByID(int ID)
        {
            clsContact ContactInfo = clsContact.Find(ID);
            if (ContactInfo != null)
            {
                Console.WriteLine("----Contact Found-----");
                Console.WriteLine(ContactInfo.ID);
                Console.WriteLine(ContactInfo.FirstName);
                Console.WriteLine(ContactInfo.LastName);
                Console.WriteLine(ContactInfo.Email);
                Console.WriteLine(ContactInfo.Phone);
                Console.WriteLine(ContactInfo.Address);
                Console.WriteLine(ContactInfo.DateOfBirth);
                Console.WriteLine(ContactInfo.ImagePath);
                Console.WriteLine(ContactInfo.CountryID);
            }

            else
            {
                Console.WriteLine("Contact Not Found:-(");
            }
        }

        public static void testAddNewContact()
        {
            clsContact Contact1 = new clsContact();

            Contact1.FirstName = "Bilo";
            Contact1.LastName = "Nur";
            Contact1.Email = "bilmoh@gmail";
            Contact1.Phone  = "0902220108";
            Contact1.Address = "123 A.A";
            Contact1.DateOfBirth = new DateTime(2003, 03, 05, 10, 20, 0);
            Contact1.CountryID = 5;
            Contact1.ImagePath = "";

            if(Contact1.Save())
            {
                Console.WriteLine("Contact Added Successfully:-)");
            }
            else
            {
                Console.WriteLine("Faild to Add new Contact:-(");
            }
        }

        public static void testUpdateContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Contact1.ID = ID;
                Contact1.FirstName = "Jemila";
                Contact1.LastName = "Abdellah";
                Contact1.Email = "Jem@gmail";
                Contact1.Phone = "0904440108";
                Contact1.Address = "123 Jimma";
                Contact1.DateOfBirth = new DateTime(2003, 01, 17, 10, 30, 0);
                Contact1.CountryID = 5;
                Contact1.ImagePath = "";


                if (Contact1.Save())
                {
                    Console.WriteLine("Contact Updated Successfully:-)");
                }
                else
                {
                    Console.WriteLine("Faild to Update Contact:-(");
                }
            }

            else
            {
                Console.WriteLine("Faild to Update Contact:-(");
            }

        }

        static void testDeleteContact(int ID)
        {
            if(clsContact.IsContactExist(ID))
            {
                if (clsContact.DeleteContact(ID))
                {
                    Console.WriteLine("Contact Deletede Successfully:-)");
                }
                else
                {
                    Console.WriteLine("Contact Deletetion Failed:-(");
                }
            }
            else
            {
                Console.WriteLine("Contact with ID = " + ID + " Not Found");
            }
        }

        static void testListContacts()
        {
            DataTable dataTable = clsContact.GetAllContact();
            Console.WriteLine("Contact Data:-");

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    Console.WriteLine($"{row["ContactID"]},  {row["FirstName"]} {row["LastName"]}");
            //}

            foreach (DataRow Row in dataTable.Rows)
            {
                string contactID = Row["ContactID"].ToString().PadRight(5);   // عرض 5 خانات
                string firstName = Row["FirstName"].ToString().PadRight(15);  // عرض 15 خانة
                string lastName = Row["LastName"].ToString().PadRight(15);   // عرض 15 خانة
                string email = Row["Email"].ToString().PadRight(25);      // عرض 25 خانة

                Console.WriteLine($"{contactID}{firstName}{lastName}{email}");
            }
        }

        static void IsContactExists(int ID)
        {
            if(clsContact.IsContactExist(ID))
            {
                Console.WriteLine("Yes, Contact with ID = " + ID + " is there.");
            }
            else
            {
                Console.WriteLine("Countact Not Found:-(");
            }
        }

        static void testFindCountry(int ID)
        {
            //cannot create empity object if 
            clsCountries Country = clsCountries.FindCountry(ID);
            if(Country != null)
            {
                Console.WriteLine("Country Found:-)");
                Console.WriteLine(Country.ID);
                Console.WriteLine(Country.CountryName);
                Console.WriteLine(Country.Code);
                Console.WriteLine(Country.PhoneCode);
            }
            else
            {
                Console.WriteLine("Country Not Found:-(");
            }
        }

        static void testFindCountry(string CountryName)
        {
            //cannot create empity object if 
            clsCountries Country = clsCountries.FindCountry(CountryName);
            if (Country != null)
            {
                Console.WriteLine("Country Found:-)");
                Console.WriteLine(Country.ID);
                Console.WriteLine(Country.CountryName);
                Console.WriteLine(Country.Code);
                Console.WriteLine(Country.PhoneCode);
            }
            else
            {
                Console.WriteLine("Country Not Found:-(");
            }
        }

        static void testAddNewCountry()
        {
            string CountryName = "Turkey";
            string Code = "TR";
            string PhoneCode = "+90";

            clsCountries Country1 = new clsCountries();

            Country1.CountryName = CountryName;
            Country1.Code = Code;
            Country1.PhoneCode = PhoneCode;

            if (Country1.Save())
            {
                Console.WriteLine("Country Added Successfuly:-)");
            }
            else
            {
                Console.WriteLine("Failed to Add Contact:-(");
            }
        }

        static void testUpdateCountry(int ID)
        {
            string CountryName = "Egypt";
            string Code = "EG";
            string PhoneCode = "+20";

            clsCountries Country1 = clsCountries.FindCountry(ID);

            if (Country1 != null)
            {
                Country1.CountryName = CountryName;
                Country1.Code = Code;
                Country1.PhoneCode = PhoneCode;
                if (Country1.Save())
                {
                    Console.WriteLine("Country Updated Successfuly:-)");
                }
                else
                {
                    Console.WriteLine("Failed to Update Contact:-(");
                }
            }
            else
            {
                Console.WriteLine("Failed to Update Contact:-(");
            }
        }

        static void testIsCountryExist(int ID)
        {
            if(clsCountries.IsCountryExists(ID))
            {
                Console.WriteLine("Yes, Country is there");
            }
            else
            {
                Console.WriteLine("Country with ID = " + ID + " is Not there.");
            }
        }

        static void testIsCountryExist(string CountryName)
        {
            if (clsCountries.IsCountryExists(CountryName))
            {
                Console.WriteLine("Yes, Country is there");
            }
            else
            {
                Console.WriteLine("Country with CountryName = " + CountryName + " is Not there.");
            }
        }

        static void testDeleteCountry(int ID)
        {
            if(clsCountries.IsCountryExists(ID))
            {
                if(clsCountries.DeleteCountry(ID))
                {
                    Console.WriteLine("Country Deleted Successfully.");
                }
                else
                {
                    Console.WriteLine("Country Deletion Faield!");
                }
            }
            else
            {
                Console.WriteLine("Country with ID = " + ID + " is Not there.");
            }
        }

        static void testListCountries()
        {
            DataTable dataTable = clsCountries.GetAllCountries();
            Console.WriteLine("Countries Data:-");

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    Console.WriteLine($"{row["ContactID"]},  {row["FirstName"]} {row["LastName"]}");
            //}

            foreach (DataRow Row in dataTable.Rows)
            {
                string CountryID = Row["CountryID"].ToString().PadRight(5);   // عرض 5 خانات
                string CountryName = Row["CountryName"].ToString().PadRight(15);  // عرض 15 خانة

                Console.WriteLine($"{CountryID}{CountryName}");
            }
        }

        static void Main(string[] args)
        {
            //testFindContactByID(1);
            //testAddNewContact();
            //testUpdateContact(8);
            //testDeleteContact(55);
            //testListContacts();
            //IsContactExists(8);

            //testFindCountry("Ethiopia");
            //testFindCountry(7);
            //testAddNewCountry();
            //testUpdateCountry(7);
            testIsCountryExist(8);
            //testDeleteCountry(7);
            //testListCountries();

            Console.ReadKey();
        }
    }
}
