using AddressBookSystem;
namespace AddressBookTesting
{
    [TestClass]
    public class AddressTest
    {
        AddressBook address=new AddressBook();
        [TestMethod]
        public void AddContactTest_returnContact()
        {
            Contact c1=new Contact 
            {
                firstName = "Abhay",lastName="Srivastava",address="130 Civil",city="Lmp",state="UP",Phone="8953171369",email="Email@gmail.com"

            };
            Contact person = address.AddTestContact();
            CollectionAssert.Equals(c1,person);
        }
        [TestMethod]
        public void EditContact_returnTrue()
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
            
            address.contacts.Add(c1);  
            string name = "Abhay";
            bool actual=address.EditTestContact(name);
            Assert.IsTrue(actual);

        }
        [TestMethod]
        public void DeleteContact_returnTrue()
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

            address.contacts.Add(c1);
            string name = "Abhay";
            bool actual=address.DeleteTestContact(name);
            Assert.IsTrue(actual);

        }
        [TestMethod]
        public void SearchContact_returnTrue()
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
            address.contacts.Add(c1);
            string city = "Lmp";
            bool actual = address.SearchTestContact(city);
            Assert.IsTrue(actual);


        }
    }
}