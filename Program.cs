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
        static void Main(string[] args)
        {
            testFindContactByID(2);
        }
    }
}
