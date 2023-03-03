﻿namespace AddressBookSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            bool boolean = true;
            AddressBook add = new AddressBook();
            while (boolean)
            {
                Console.WriteLine("Enter the choice");
                Console.WriteLine("Press 1 for Creating New Contact\n Press 2 for Adding Contact to Address Book \n Press 3 for Editing Existing Contact" +
                    "\n Press 4 for Deleting Contact\n Press 5 for Adding Multiple Contact at a time\n Press 6 for Adding a Address Book having unique name" +
                    "\n Press 7 for Duplicate not Allowed in Particular Address Book\n Press 8 for Searching People on City or State \n Press 9 for View Person that are enter according to city or state" +
                    "\n Press 10 for exit");
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

                }
            }
        }
    }
}
