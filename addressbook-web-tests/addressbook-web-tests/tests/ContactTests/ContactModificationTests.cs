using System.Collections.Generic;
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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
