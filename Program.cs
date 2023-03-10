namespace AddressBookSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            bool boolean = true;
            AddressBook add = new AddressBook();
            AdoAddressSystem ado = new AdoAddressSystem();
            while (boolean)
            {
                Console.WriteLine("Enter the choice");
                Console.WriteLine("Press 1 for Adding Contact to Address Book\n Press 2 for Editing Existing Contact \n Press 3 for Deleting Contact" +
                    "\n Press 4 for View Contacts \n Press 5 for Adding Multiple Contact at a time\n Press 6 for Adding a Address Book having unique name" +
                    "\n Press 7 for Searching People on City or State\n Press 8 for View Person that are enter according to city or state \n Press 9 for Count number of person by city or state " +
                    "\n Press 10 for Sort number of people according to their name\n Press 11 for Sort people by state or city or ZIP\n Press 12 for Read and write contacts into text file" +
                    "\n Press 13 for Read and write contacts into CSV file\n Press 14 for Read and write contacts into Json file\n Press 15 for Retrieve Contacts from Database" +
                    "\n Press 16 for Update Contact in database \n Press 17 for Deleting the Contact from Database \n Press 18 for Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        add.AddContacts();
                        break;

                    case 2:
                        Console.WriteLine("Enter the first name of contact that you want to edit");
                        string name = Console.ReadLine();
                        add.EditContact(name);
                        break;
                    case 3:
                        Console.WriteLine("Enter the first name of contact that you want to edit");
                        string firstname = Console.ReadLine();
                        add.DeleteContact(firstname);
                        break;
                    case 4:
                        add.ViewContact();
                        break;
                    case 5:
                        Console.WriteLine("Enter the number of contacts you want to enter");
                        int count = Convert.ToInt32(Console.ReadLine());
                        add.multipleAddContact(count);
                        break;
                    case 6:
                        add.AddAddressBook();
                        break;
                    case 7:
                        add.SearchContactAcrossBooks();
                        break;
                    case 8:
                        add.ViewPersonByStateOrCity();
                        break;
                    case 9:
                        add.CountByStateOrCity();
                        break;
                    case 10:
                        add.SortByPersonName();
                        break;
                    case 11:
                        add.SortPeopleByCityStateOrZip();
                        break;
                    case 12:
                        add.ReadWriteText();
                        break;
                    case 13:
                        add.ReadWriteCSV();
                        break;
                    case 14:
                        add.ReadWriteJSON();
                        break;
                    case 15:
                        
                        ado.RetrieveData();
                        break;
                    case 16:
                        Console.WriteLine("Enter the name of person that you want to update");
                        string nameOfContact=Console.ReadLine();
                        ado.UpdateAddressBook(nameOfContact);
                        break;
                    case 17:
                        Console.WriteLine("Enter the name of person that you want to update");
                        string personName = Console.ReadLine();
                        ado.DeleteContact(personName);
                        break;
                    case 18:
                        add.AddContacts();
                        Console.WriteLine("Data in local list is :-");
                        add.viewListContact();

                        break;
                    case 19:
                        
                        break;




                }
            }
        }
    }
}
