using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContactBook
{
    public class ContactsBook
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public ContactsBook(string firstName, string lastName, string company, string mobileNumber, string email, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Company = company;
            MobileNumber = ValidateMobileNumber(mobileNumber);
            Email = email;
            Birthdate = birthdate;

        }



        public string? ValidateMobileNumber(string mobileNumber)
        {
            try
            {
                if (Regex.IsMatch(mobileNumber, @"^[1-9]\d{8}$"))
                {
                    
                    return mobileNumber; 
                }
                    
                else
                    throw new ArgumentException("Invalid mobile number. Must be a 9-digit, non-zero positive number.");
            }
            catch
            {
                Console.WriteLine("Invalid mobile number. Must be a 9-digit, non-zero positive number.");
            }

            return null;
        }
    }
}
