using addressbook_web_tests;
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

            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitCreatingNewContact();
            FillContactForm(contact);
            SubmitContactCreation();
            Logout();
        }     
    }
}
