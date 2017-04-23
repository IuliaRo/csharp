using System.Collections.Generic;
using NUnit.Framework;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
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

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[0];
            app.Contacts.Modify(toBeModified, newData);

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
