using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Linq;
using System.Text;
using NUnit.Framework.Constraints;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;

namespace addressbook_web_tests.tests
{
    public class WebAddressbookTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldContactsList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldContactsList).First();

            //Act
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newContactsList = group.GetContacts();
            oldContactsList.Add(contact);
            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);
        }

        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldContactsList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldContactsList).First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newContactsList = group.GetContacts();
            oldContactsList.Remove(contact);
            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList, newContactsList);
        }

    }
}
