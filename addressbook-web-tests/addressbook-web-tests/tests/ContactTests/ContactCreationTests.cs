using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Firstname", "Lastname");
            contact.Title = "Missis";
            contact.Address = "Lenina str";

            app.Contacts.Create(contact);
            app.Auth.Logout();
        }     
    }
}
