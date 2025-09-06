using System;
using System.Data;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using ContactsBusinessLayer;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsContact
    {
        public enum enMode { AddNewMode, UpdateMode};
        public enMode Mode = enMode.AddNewMode;

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public int CountryID { get; set; }
        
        public clsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = "";
            this.CountryID = -1;

            Mode = enMode.AddNewMode;
        }

        private clsContact(int ID, string FirstName, string LastName, string Email, string Phonne, string Address, 
            DateTime DateOfBirth, string ImagePath, int CountryID)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phonne;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.ImagePath = ImagePath;
            this.CountryID = CountryID;

            Mode = enMode.UpdateMode;
        }

        private bool _AddNewContact()
        {
            this.ID = ContactData.AddNewContact(this.FirstName, this.LastName, this.Email, this.Phone,
                this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);

            return (this.ID != -1);
        }
        public static clsContact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;

            if (ContactData.GetContactInfoByID(ID, ref FirstName, ref LastName, ref Email,
            ref Phone, ref Address, ref DateOfBirth, ref ImagePath, ref CountryID))
            {
                return new clsContact(ID, FirstName, LastName, Email, Phone, Address,
            DateOfBirth, ImagePath, CountryID);
            }
            else
            {
                return null;
            }
        }

        private bool _UpdateContact()
        {
            return ContactData.UpdateContact(this.ID, this.FirstName, this.LastName, this.Email, this.Phone,
                this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);
        }

        public bool Save()

        {
            switch (Mode)
            {
                case enMode.AddNewMode:
                    if(_AddNewContact())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    return _UpdateContact();
            }
            return false;
        }

        public static bool DeleteContact(int ID)
        {
            return ContactData.DeleteContact(ID);
        }

        public static DataTable GetAllContact()
        {
            return ContactData.GetAllContacts();
        }

        public static bool IsContactExist(int ID)
        {
            return ContactData.IsContactExist(ID);
        }
    }

    public class clsCountries
    { 
        public enum enMode { AddNewMode, UpdateMode};
        public enMode Mode;

        public int ID { get; set; }
        public string CountryName { get; set; }

        public clsCountries()
        {
            this.ID = -1;
            this.CountryName = "";

            Mode = enMode.AddNewMode;
        }
        private clsCountries(int ID, string CountrName)
        {
            this.ID = ID;
            this.CountryName = CountrName;

            Mode = enMode.UpdateMode;
        }

        private bool _AddNewCountry()
        {
            int ID = ContactData.AddNewCountry(this.CountryName);
            return (ID != -1);
        }

        private bool _UpdateCountry()
        {
            return ContactData.UpdateContact(this.ID, this.CountryName);
        }

        public static clsCountries FindCountry(int ID)
        {
            string CountryName = "";
            if (ContactData.FindCountryByID(ID, ref CountryName))
            {
                return new clsCountries(ID, CountryName);
            }
            else
            {
                return null;
            }
        }

        public static clsCountries FindCountry(string CountryName)
        {
            int ID = -1;
            if (ContactData.FindCountryByName(CountryName, ref ID))
            {
                return new clsCountries(ID, CountryName);
            }
            else
            {
                return null;
            }
        }

        

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNewMode:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.UpdateMode:
                    return _UpdateCountry();
            }
            return false;
        }

        public static bool IsCountryExists(int ID)
        {
            return ContactData.IsCountryExist(ID);
        }

        public static bool IsCountryExists(string CountryName)
        {
            return ContactData.IsCountryExist(CountryName);
        }

        public static bool DeleteCountry(int ID)
        {
            return ContactData.DeleteCountry(ID);
        }

        public static DataTable GetAllCountries()
        {
            return ContactData.GetAllCountries();
        }
    }
}

