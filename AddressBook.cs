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

        public void EditContact(string firstname)
        {


            firstname = firstname.ToLower();
            foreach (Contact contact in contacts)
            {
                if (firstname.Equals(contact.firstName.ToLower()))
                {
                    Console.WriteLine("Enter first name that you want to update");
                    contact.firstName = Console.ReadLine();
                    Console.WriteLine("Enter last name that you want to update");
                    contact.lastName = Console.ReadLine();
                    Console.WriteLine("Enter city that you want to update");
                    contact.city = Console.ReadLine();
                    Console.WriteLine("Enter state that you want to update");
                    contact.state = Console.ReadLine();
                    Console.WriteLine("Enter address that you want to update");
                    contact.address = Console.ReadLine();
                    Console.WriteLine("Enter ZipCode that you want to update");
                    contact.zip = Console.ReadLine();
                    Console.WriteLine("Enter phone number that you want to update");
                    contact.Phone = Console.ReadLine();
                    Console.WriteLine("Enter email that you want to update");
                    contact.email = Console.ReadLine();


                }
                else
                {
                    Console.WriteLine("Contact not found");
                }

            }
        }

        public void DeleteContact(string firstname)
        {
            firstname = firstname.ToLower();
            foreach (var contact in contacts)
            {
                if (firstname.Equals(contact.firstName.ToLower()))
                {
                    contacts.Remove(contact);
                    Console.WriteLine("The Contact is Successfully removed");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect name or conatct not found");
                }
            }
        }

        public void ViewContact()
        {
            foreach (var book in AddressBookName.Keys)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("AddressBook:-  " + book);

                List<Contact> person = AddressBookName[book];
                foreach (var people in person)
                {
                    Console.WriteLine(people.ToString());
                }
            }
        }

        public List<Contact> multipleAddContact(int count)
        {
            List<Contact> AddressBookContact = new List<Contact>();
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine("Enter the details for contact no {0}", i);
                AddressBookContact.Add(AddContacts());


            }


            return AddressBookContact;
        }

        public void AddAddressBook()
        {
            Console.WriteLine("Enter the name of Address Book that you want");
            string bookName = Console.ReadLine();
            Console.WriteLine("Enter the number of contact you want to enter in this Address Book");
            int count = Convert.ToInt32(Console.ReadLine());
            if (!AddressBookName.ContainsKey(bookName))
            {
                List<Contact> person = multipleAddContact(count);
                AddressBookName.Add(bookName, person);
            }
            else
            {
                Console.WriteLine("Enter the correct name of book . It is Already Exists");
            }

            Console.WriteLine("Contact is successfully added to Address Book");

        }

        public void SearchContactAcrossBooks()
        {

            Console.WriteLine("Enter the City you want to search in");
            string city1 = Console.ReadLine();

            Console.WriteLine("Enter the State you want to search in");
            string state = Console.ReadLine();
            List<List<Contact>> record = new List<List<Contact>>();

            foreach (string book in AddressBookName.Keys)
            {
                record.Add(AddressBookName[book]);

            }
            foreach (var person in record)
            {
                var list = person.Where(x => x.city == city1 || x.state == state);
                var name = list.Select(x => x.firstName).ToList();
                foreach (var names in name)
                {
                    Console.WriteLine(names);
                }

            }


        }
    }
}
