using NUnit.Framework;
using WebAddressbookTests;

namespace addressbook_web_tests.tests.ContactTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Testname", "Testlastname");
            newData.Title = "Miss";
            newData.Address = "Nahimova str";

            app.Contacts.Modify(1, newData);
        }
    }
}
