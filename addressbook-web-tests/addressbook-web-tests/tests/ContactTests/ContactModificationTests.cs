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
            ContactData newData = new ContactData("Testname", "Testlastname");
            newData.Title = "Miss";
            newData.Address = "Nahimova str";

            app.Contacts.Modify(1, newData);
            //app.Auth.Logout();
        }
    }
}
