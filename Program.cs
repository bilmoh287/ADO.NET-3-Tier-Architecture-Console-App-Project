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

            Contact1.FirstName = "Bilal";
            Contact1.LastName = "Mohammed";
            Contact1.Email = "bilmoh@gmail";
            Contact1.Phone  = "0902220108";
            Contact1.Address = "123 A.A";
            Contact1.DateOfBirth = new DateTime(2003, 03, 05, 10, 20, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";
        }
        static void Main(string[] args)
        {
            testFindContactByID(1);
            Console.ReadKey();
        }
    }
}
