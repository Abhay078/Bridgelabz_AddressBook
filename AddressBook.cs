using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        public  List<Contact> contacts = new List<Contact>();
        public Dictionary<string, List<Contact>> AddressBookName = new Dictionary<string, List<Contact>>();
        public Dictionary<string, List<Contact>> CityWiseDict = new Dictionary<string, List<Contact>>();
        public Dictionary<string, List<Contact>> StateWiseDict = new Dictionary<string, List<Contact>>();
        string cs = ConfigurationManager.ConnectionStrings["AddressDb"].ConnectionString;
        SqlConnection con = null;



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

            try
            {
                Console.WriteLine("Inserting data into database");
                con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand();

                string query = "INSERT INTO CONTACTLIST VALUES(@firstName,@lastName,@city,@address,@state,@zip,@Phone,@email,GETDATE())";
                cmd.Parameters.AddWithValue("@firstName", newContact.firstName);
                cmd.Parameters.AddWithValue("@lastName", newContact.lastName);
                cmd.Parameters.AddWithValue("@city", newContact.city);
                cmd.Parameters.AddWithValue("@state", newContact.state);
                cmd.Parameters.AddWithValue("@address", newContact.address);
                cmd.Parameters.AddWithValue("@zip", newContact.zip);
                cmd.Parameters.AddWithValue("@Phone", newContact.Phone);
                cmd.Parameters.AddWithValue("@email", newContact.email);


                cmd.CommandText = query;
                cmd.Connection = con;
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    Console.WriteLine("Insertion is done successfully");
                    
                }
                else
                {
                    Console.WriteLine("Some error while inserting");
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            finally
            {
                con.Close();

            }
            return newContact;
        }
        

        public void EditContact(string firstname)
        {


            firstname = firstname.ToLower();
            foreach (Contact contact in contacts)
            {
                if (firstname.ToLower().Equals(contact.firstName.ToLower()))
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
        public void viewListContact()
        {
            foreach(var contact in contacts)
            {
                Console.WriteLine(contact.ToString());

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
       

        public void ViewPersonByStateOrCity()
        {
            Console.WriteLine("Enter the Choice Whether you want to view person by State or City");
            Console.WriteLine("Press 1 for Viewing City wise Contact\n Press 2 for Viewing state Wise Contact");
            int input = Convert.ToInt32(Console.ReadLine());
            List<List<Contact>> person = new List<List<Contact>>();
            foreach (string book in AddressBookName.Keys)
            {
                person.Add(AddressBookName[book]);
            }
            switch (input)
            {
                case 1:
                    Console.WriteLine("The City Wise Dictionary of all contact is:- ");
                    foreach (List<Contact> people in person)
                    {
                        foreach (Contact contact in people)
                        {
                            if (!CityWiseDict.ContainsKey(contact.city))
                            {
                                CityWiseDict.Add(contact.city, new List<Contact>());

                            }
                            CityWiseDict[contact.city].Add(contact);
                        }

                    }
                    foreach (var kvp in CityWiseDict)
                    {

                        Console.WriteLine("City :-  " + kvp.Key);
                        foreach (Contact contact in kvp.Value)
                        {
                            Console.WriteLine($"First name :-  {contact.firstName}      State :-  {contact.state}      Phone Number :- {contact.Phone}");
                        }
                    }

                    break;
                case 2:
                    Console.WriteLine("The State Wise Dictionary of all contact is:- ");
                    foreach (List<Contact> people in person)
                    {
                        foreach (Contact contact in people)
                        {
                            if (!StateWiseDict.ContainsKey(contact.state))
                            {
                                StateWiseDict.Add(contact.state, new List<Contact>());

                            }
                            StateWiseDict[contact.state].Add(contact);
                        }

                    }
                    foreach (var kvp in StateWiseDict)
                    {
                        Console.WriteLine("State :-  " + kvp.Key);

                        foreach (Contact contact in kvp.Value)
                        {
                            Console.WriteLine($"First name :-  {contact.firstName}       State :-  {contact.state}       Phone Number :-  {contact.Phone}");
                        }
                    }
                    break;

            }
        }
        public void CountByStateOrCity()
        {
            Console.WriteLine("Enter the Choice Whether you want to view person by State or City");
            Console.WriteLine("Press 1 for Viewing Count of City wise Contact\n Press 2 for Viewing Count of state Wise Contact");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:

                    foreach (var kvp in CityWiseDict)
                    {
                        Console.Write("City :-  " + kvp.Key + "\t");
                        int count = 0;

                        foreach (Contact contact in kvp.Value)
                        {
                            count++;

                        }
                        Console.WriteLine($" address Book has {count} Person from this city ");
                    }
                    break;
                case 2:

                    foreach (var kvp in StateWiseDict)
                    {
                        Console.Write("State :-  " + kvp.Key + "\t");
                        int counter = 0;

                        foreach (Contact contact in kvp.Value)
                        {
                            counter++;

                        }
                        Console.WriteLine($" Address Book has {counter} Person from this state ");
                    }
                    break;


            }

        }

        public void SortByPersonName()
        {
            Console.WriteLine("sorting the contacts by their first name");
            List<Contact> person = new List<Contact>();
            foreach (var book in AddressBookName.Keys)
            {
                person = AddressBookName[book].ToList();
                person.Sort();

                foreach (Contact people in person)
                {

                    Console.WriteLine(people.ToString());
                }

            }
        }
        public void SortPeopleByCityStateOrZip()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the Choice :--");
            Console.WriteLine("Press 1 for Sorting by city\n Press 2 for sorting by State \n Press 3 for sorting by Zip Code");
            Console.WriteLine("");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            int choice = Convert.ToInt32(Console.ReadLine());
            List<Contact> person = new List<Contact>();
            switch (choice)
            {
                case 1:

                    foreach (string book in AddressBookName.Keys)
                    {
                        person = AddressBookName[book].ToList();
                        person.Sort((x, y) => x.city.CompareTo(y.city));
                        foreach (Contact contact in person)
                        {
                            Console.WriteLine(contact.ToString());
                        }
                    }
                    break;
                case 2:

                    foreach (string book in AddressBookName.Keys)
                    {
                        person = AddressBookName[book].ToList();
                        person.Sort((x, y) => x.state.CompareTo(y.state));
                        foreach (Contact contact in person)
                        {
                            Console.WriteLine(contact.ToString());
                        }
                    }
                    break;
                case 3:

                    foreach (string book in AddressBookName.Keys)
                    {
                        person = AddressBookName[book].ToList();
                        person.Sort((x, y) => x.zip.CompareTo(y.zip));
                        foreach (Contact contact in person)
                        {
                            Console.WriteLine(contact.ToString());
                        }
                    }
                    break;

            }
            Console.WriteLine("-----------------------------------------------------------------------------------------");



        }

        public void ReadWriteText()
        {
            Console.WriteLine("Press 1 for Reading Text File\n Press 2 for Writing into text File");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            string path = "D:\\AddressBookMain\\AddressBookSystem\\ReadWriteContacts.txt";
            switch (choice)
            {
                case 1:

                    if (File.Exists(path))
                    {
                        string data = File.ReadAllText(path);
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.WriteLine("");
                        Console.WriteLine(data);
                        Console.WriteLine("---------------------------------------------------------------------------------------------");
                        Console.WriteLine("");

                    }
                    break;
                case 2:

                    try
                    {

                        using (StreamWriter sw = new StreamWriter(path, true))
                        {
                            var entry = AddContacts();
                            sw.WriteLine(entry.ToString());
                            sw.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            }

        }

        public void ReadWriteCSV()
        {
            Console.WriteLine("Press 1 for Reading CSV File\n Press 2 for Writing into CSV File");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            string path = "D:\\AddressBookMain\\AddressBookSystem\\ReadWriteCSV.csv";
            switch (choice)
            {
                case 1:
                    using (var reader = new StreamReader(path))
                    using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<Contact>();
                        foreach (var record in records)
                        {
                            Console.WriteLine(record.ToString());
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the number of contacts that you want to enter");
                    int count = Convert.ToInt32(Console.ReadLine());
                    List<Contact> multiContact = multipleAddContact(count);

                    using (var writer = new StreamWriter(path, true))
                    using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        csv.WriteRecords(multiContact);
                    }
                    Console.WriteLine("Writing to csv file is done");
                    break;


            }
        }

        public void ReadWriteJSON()
        {
            Console.WriteLine("Press 1 for Reading Json File\n Press 2 for Writing into Json File");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            string path = "D:\\AddressBookMain\\AddressBookSystem\\ReadWriteContact.json";
            switch (choice)
            {
                case 1:
                    string json = File.ReadAllText(path);
                    List<Contact> personFromFile = JsonConvert.DeserializeObject<List<Contact>>(json) ?? new List<Contact>();
                    Console.WriteLine("---------------------------------------------------------------------------------------------");
                    Console.WriteLine("");
                    foreach (var person in personFromFile)
                    {
                        Console.WriteLine(person.ToString());
                    }
                    Console.WriteLine("");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");

                    break;

                case 2:
                    List<Contact> listContact = new List<Contact>();
                    if (File.Exists(path))
                    {
                        string jsonExtract = File.ReadAllText(path);
                        listContact = JsonConvert.DeserializeObject<List<Contact>>(jsonExtract) ?? new List<Contact>();

                    }
                    Console.WriteLine("How many contacts you want to enter in Json File");
                    int count = Convert.ToInt32(Console.ReadLine());
                    listContact.AddRange(multipleAddContact(count));


                    string jsonToFile = JsonConvert.SerializeObject(listContact);
                    File.WriteAllText(path, jsonToFile);

                    Console.WriteLine("Writing to Json File done....");
                    
                    break;


            }
        }

        public bool SearchTestContact(string city)
        {
            city = city.ToLower();
            foreach (var person in contacts)
            {
                if (city.Equals(person.city.ToLower()))
                {
                    return true;
                }
            }
            return false;

        }

        public bool DeleteTestContact(string firstname)
        {
            firstname = firstname.ToLower();
            foreach (var contact in contacts)
            {
                if (firstname.Equals(contact.firstName.ToLower()))
                {
                    contacts.Remove(contact);
                    return true;
                }

            }
            return false;

        }

        public bool EditTestContact(string firstname)
        {
            foreach (Contact contact in contacts)
            {
                if (firstname.ToLower().Equals(contact.firstName.ToLower()))
                {
                    return true;

                }


            }
            return false;
        }

        public Contact AddTestContact()
        {
            Contact c1 = new Contact
            {
                firstName = "Abhay",
                lastName = "Srivastava",
                address = "130 Civil",
                city = "Lmp",
                state = "UP",
                Phone = "8953171369",
                email = "Email@gmail.com"

            };
            return c1;

        }


    }
}
