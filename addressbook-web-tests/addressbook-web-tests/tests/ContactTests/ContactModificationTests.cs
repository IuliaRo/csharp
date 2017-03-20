using NUnit.Framework;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            var newData = new ContactData("Testname", "Testlastname");
            newData.Title = "Miss";
            newData.Address = "Nahimova str";

            var contact = new ContactData("Firstname", "Lastname");
            contact.Title = "Missis";
            contact.Address = "Lenina str";

            if (!app.Contacts.CheckIfContactExists())
            {
                app.Contacts.Create(contact);
            }

            app.Contacts.Modify(1, newData);
        }
    }
}
