using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Contact> contacts = new List<Contact>();
        Dictionary<string, List<Contact>> AddressBookName = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> CityWiseDict = new Dictionary<string, List<Contact>>();
        Dictionary<string, List<Contact>> StateWiseDict = new Dictionary<string, List<Contact>>();



        public Contact AddContacts()
        {
            Contact newContact = new Contact();

            Console.WriteLine("Enter the First Name of Contact");
            newContact.firstName = Console.ReadLine();
            if (contacts.Find(x => x.firstName.ToLower() == newContact.firstName.ToLower()) != null)//Checking duplicates
            {
                Console.WriteLine("The same name person exists in address book already");
                AddContacts();
                return null;
            }

            Console.WriteLine("Enter the Last Name of Contact");
            newContact.lastName = Console.ReadLine();
            Console.WriteLine("Enter the City of Contact");
            newContact.city = Console.ReadLine();
            Console.WriteLine("Enter the State of Contact");
            newContact.state = Console.ReadLine();
            Console.WriteLine("Enter the address of Contact");
            newContact.address = Console.ReadLine();
            Console.WriteLine("Enter the Zip Code of Contact");
            newContact.zip = Console.ReadLine();
            Console.WriteLine("Enter the Phone of Contact");
            newContact.Phone = Console.ReadLine();
            Console.WriteLine("Enter the email of Contact");
            newContact.email = Console.ReadLine();

            contacts.Add(newContact);
            return newContact;
        }
    }
}
