namespace ContactBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContactService service = new ContactService();
            while (true)
            {
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("Main Menu");
                Console.WriteLine("1: Add Contact");
                Console.WriteLine("2: Show All Contacts");
                Console.WriteLine("3: Show Contact Details");
                Console.WriteLine("4: Update Contact");
                Console.WriteLine("5: Delete Contact");
                Console.WriteLine("0: Exit");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Company: ");
                        string company = Console.ReadLine();
                        Console.Write("Mobile Number: ");
                        string mobileNumber = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Birthdate (dd-MM-yyyy): ");
                        while (true)
                        {
                            try
                            {
                                DateTime birthdate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                                ContactsBook contact = new ContactsBook(firstName, lastName, company, mobileNumber, email, birthdate);
                                service.AddContact(contact);
                                break;

                            }
                            catch
                            {
                                Console.WriteLine("Please enter BirthDate in correct format");
                            }

                        }
                        

                        break;
                    case "2":
                        service.ShowContactDetails(); break;
                    case "3":
                        Console.Write("Enter First Name: ");
                        firstName = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        lastName = Console.ReadLine();
                        List<ContactsBook> contactDetails = service.ShowContactDetails(firstName, lastName);
                        if (contactDetails != null)
                        {
                            foreach (ContactsBook details in contactDetails)
                            {
                                Console.WriteLine($"Name: {details.FirstName} {details.LastName}");
                                Console.WriteLine($"Company: {details.Company}");
                                Console.WriteLine($"Mobile: {details.MobileNumber}");
                                Console.WriteLine($"Email: {details.Email}");
                                Console.WriteLine($"Birthdate: {details.Birthdate.ToShortDateString()}");
                            }

                        }
                        break;
                    case "4":
                        Console.Write("Enter First Name of contact to be updated: ");
                        firstName = Console.ReadLine();
                        Console.Write("Enter Last Name of contact to be updated: ");
                        lastName = Console.ReadLine();
                        Console.Write("Enter Mobile number of contact to be updated: ");
                        String number = Console.ReadLine();
                        Console.Write("New First Name: ");
                        string newFirstName = Console.ReadLine();
                        Console.Write("New Last Name: ");
                        string newLastName = Console.ReadLine();
                        Console.Write("New Company: ");
                        string newCompany = Console.ReadLine();
                        Console.Write("New Mobile Number: ");
                        string newMobileNumber = Console.ReadLine();
                        Console.Write("New Email: ");
                        string newEmail = Console.ReadLine();
                        Console.Write("New Birthdate (dd-MM-yyyy): ");
                        DateTime newBirthdate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

                        ContactsBook updatedContact = new ContactsBook(newFirstName, newLastName, newCompany, newMobileNumber, newEmail, newBirthdate);
                        service.UpdateContact(firstName, lastName, number, updatedContact);
                        break;
                    case "5":
                        Console.Write("Enter First Name of contact to delete: ");
                        firstName = Console.ReadLine();
                        Console.Write("Enter Last Name of contact to delete: ");
                        lastName = Console.ReadLine();
                        Console.Write("Enter mobile number of contact to be deleted: ");
                        number = Console.ReadLine();
                        service.DeleteContact(firstName, lastName, number);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
