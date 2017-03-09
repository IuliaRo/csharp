using NUnit.Framework;
using WebAddressbookTests;

namespace addressbook_web_tests.tests.ContactTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(1);
        }
    }
}
