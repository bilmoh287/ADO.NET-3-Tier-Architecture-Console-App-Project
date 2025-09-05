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
            if(clsContact.DeleteContact(ID))
            {
                Console.WriteLine("Contact Deletede Successfully:-)");
            }
            else
            {
                Console.WriteLine("Contact Deletetion Failed:-(");
            }
        }
        static void Main(string[] args)
        {
            //testFindContactByID(1);
            //testAddNewContact();
            //testUpdateContact(8);
            testDeleteContact(10);
            Console.ReadKey();
        }
    }
}
