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

            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.InitCreatingNewContact();
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
            app.Auth.Logout();
        }     
    }
}
