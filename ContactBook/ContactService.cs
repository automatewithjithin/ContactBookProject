using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    public class ContactService
    {
        //Service Layer
        //List for storing contacts
        private List<ContactsBook> contactsDb = new List<ContactsBook>();

        public ContactService()
        {
            InitializeContacts();
        }
        public void InitializeContacts()
        {
            ContactsBook person1 = new ContactsBook("Jithin", "Jose", "CTS", "123456789", "test@gmail.com", DateTime.ParseExact("01-01-1991", "dd-MM-yyyy", null));
            contactsDb.Add(person1);
            ContactsBook person2 = new ContactsBook("Arunima", "Alex", "CTS", "234567890", "test@gmail.com", DateTime.ParseExact("01-01-1991", "dd-MM-yyyy", null));
            contactsDb.Add(person2);
            ContactsBook person3 = new ContactsBook("Sarath", "Kumar", "CTS", "123456789", "test@gmail.com", DateTime.ParseExact("01-01-1991", "dd-MM-yyyy", null));
            contactsDb.Add(person3);
            ContactsBook person4 = new ContactsBook("Shyam", "Jith", "CTS", "234567890", "test@gmail.com", DateTime.ParseExact("01-01-1991", "dd-MM-yyyy", null));
            contactsDb.Add(person4);
            ContactsBook person5 = new ContactsBook("Shalu", "Nair", "CTS", "123456789", "test@gmail.com", DateTime.ParseExact("01-01-1991", "dd-MM-yyyy", null));
            contactsDb.Add(person5);
            ContactsBook person6 = new ContactsBook("Dhruv", "Sharath", "CTS", "234567890", "test@gmail.com", DateTime.ParseExact("01-01-1991", "dd-MM-yyyy", null));
            contactsDb.Add(person6);
            ContactsBook person7 = new ContactsBook("Diksh", "Sharath", "CTS", "123456789", "test@gmail.com", DateTime.ParseExact("01-01-1991", "dd-MM-yyyy", null));
            contactsDb.Add(person7);
            ContactsBook person9 = new ContactsBook("Rahul", "Sharma", "TCS", "345678901", "rahul.sharma@tcs.com", DateTime.ParseExact("15-02-1988", "dd-MM-yyyy", null));
            contactsDb.Add(person9);

            ContactsBook person10 = new ContactsBook("Anita", "Verma", "Infosys", "456789012", "anita.verma@infosys.com", DateTime.ParseExact("20-03-1992", "dd-MM-yyyy", null));
            contactsDb.Add(person10);

            ContactsBook person11 = new ContactsBook("Vijay", "Patel", "Wipro", "567890123", "vijay.patel@wipro.com", DateTime.ParseExact("05-04-1990", "dd-MM-yyyy", null));
            contactsDb.Add(person11);

            ContactsBook person12 = new ContactsBook("Asha", "Reddy", "HCL", "678901234", "asha.reddy@hcl.com", DateTime.ParseExact("30-05-1985", "dd-MM-yyyy", null));
            contactsDb.Add(person12);

            ContactsBook person13 = new ContactsBook("Arjun", "Nair", "IBM", "789012345", "arjun.nair@ibm.com", DateTime.ParseExact("25-06-1987", "dd-MM-yyyy", null));
            contactsDb.Add(person13);

            ContactsBook person14 = new ContactsBook("Priya", "Singh", "Tech Mahindra", "890123456", "priya.singh@techmahindra.com", DateTime.ParseExact("10-07-1993", "dd-MM-yyyy", null));
            contactsDb.Add(person14);

            ContactsBook person15 = new ContactsBook("Amit", "Joshi", "Accenture", "901234567", "amit.joshi@accenture.com", DateTime.ParseExact("17-08-1991", "dd-MM-yyyy", null));
            contactsDb.Add(person15);

            ContactsBook person16 = new ContactsBook("Neha", "Kumar", "Capgemini", "912345678", "neha.kumar@capgemini.com", DateTime.ParseExact("12-09-1989", "dd-MM-yyyy", null));
            contactsDb.Add(person16);

            ContactsBook person17 = new ContactsBook("Rohan", "Das", "Cognizant", "923456789", "rohan.das@cognizant.com", DateTime.ParseExact("22-10-1994", "dd-MM-yyyy", null));
            contactsDb.Add(person17);

            ContactsBook person18 = new ContactsBook("Kavita", "Mishra", "Oracle", "934567890", "kavita.mishra@oracle.com", DateTime.ParseExact("02-11-1995", "dd-MM-yyyy", null));
            ContactsBook person19 = new ContactsBook("Suresh", "Menon", "Deloitte", "945678901", "suresh.menon@deloitte.com", DateTime.ParseExact("14-12-1988", "dd-MM-yyyy", null));
            contactsDb.Add(person19);

            ContactsBook person20 = new ContactsBook("Lavanya", "Prasad", "SAP", "956789012", "lavanya.prasad@sap.com", DateTime.ParseExact("28-01-1990", "dd-MM-yyyy", null));
            contactsDb.Add(person20);

        }
        public void AddContact(ContactsBook contacts)
        {
            if (contacts.MobileNumber != null)
            {
                contactsDb.Add(contacts);
                Console.WriteLine("Contact added Successfully!!!");
            }
            
           

        }
        public void ShowContactDetails()
        {
            if (contactsDb != null && contactsDb.Any())
            {
                foreach (var contact in contactsDb)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}" +
                        $"\nCompany: {contact.Company}" +
                        $"\nMobile: {contact.MobileNumber}\nEmail: {contact.Email}" +
                        $"\nBirthdate: {contact.Birthdate.ToShortDateString()}");
                    Console.WriteLine("**************************");
                }

            }
            else
            {
                Console.WriteLine("No contacts found");
            }

        }
        public List<ContactsBook> ShowContactDetails(String firstName, String lastName)
        {
            //Method overloading
            List<ContactsBook> contactDetails = contactsDb.FindAll
                (c => c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) 
                && c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
            if (contactDetails != null)
            {
                return contactDetails;
            }
            else
            {
                Console.WriteLine("No contact details with given Firstname and LastName");
                return null;
            }
        }
        public ContactsBook ShowContactDetails(String firstName, String lastName, String phoneNumber)
        {
            ContactsBook contactDetails = contactsDb.Find(c => c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
            if (contactDetails != null)
            {
                return contactDetails;
            }
            else
            {
                Console.WriteLine("No contact details with given First Name, Last Name and Mobile Number");
                return null;
            }
        }
        public void UpdateContact(String firstName, String lastName, String phoneNumber, ContactsBook updatedContactDetails)
        {
            var contact = ShowContactDetails(firstName, lastName, phoneNumber);
            if (contact != null)
            {


                if (contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && contact.LastName.Equals(lastName, 
                    StringComparison.OrdinalIgnoreCase) && contact.MobileNumber == phoneNumber)
                {
                    contact.FirstName = updatedContactDetails.FirstName;
                    contact.LastName = updatedContactDetails.LastName;
                    contact.Company = updatedContactDetails.Company;
                    contact.MobileNumber = updatedContactDetails.MobileNumber;
                    contact.Email = updatedContactDetails.Email;
                    contact.Birthdate = updatedContactDetails.Birthdate;
                    Console.WriteLine("Contact updated Sucessfully!!!");
                }
                else
                {
                    Console.WriteLine("Something went wrong!!! Please try again....");
                }
            }

        }

        public void DeleteContact(String firstName, String lastName, String mobileNUmber)
        {
            var contact = ShowContactDetails(firstName, lastName, mobileNUmber);
            if (contact != null)
            {


                if (contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) && contact.LastName.Equals(lastName,
                    StringComparison.OrdinalIgnoreCase) && contact.MobileNumber == mobileNUmber)
                {
                    contactsDb.Remove(contact);
                    Console.WriteLine("Contact Deleted Successfully!!!");
                }
                else
                {
                    Console.WriteLine("No contacts found!!! Unable to delete..");
                }

            }
        }
    }

}

