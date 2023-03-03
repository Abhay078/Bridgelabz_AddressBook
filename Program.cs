namespace AddressBookSystem
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
                        break;
                }
            }
        }
    }
}
