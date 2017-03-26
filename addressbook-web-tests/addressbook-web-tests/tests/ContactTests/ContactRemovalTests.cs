using System.Collections.Generic;
using NUnit.Framework;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            var contact = new ContactData("Firstname", "Lastname");
            contact.Title = "Missis";
            contact.Address = "Lenina str";

            if (!app.Contacts.CheckIfContactExists())
            {
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
