using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void CompareContactInformationInTableAndEditForm()
        {
            ContactData fromTable =  app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm =  app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void CompareContactInformationInEditFormAndViewPage()
        {
            var fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);
            var fromViewPage = app.Contacts.GetContactInformationFromViewPage(0);

            Assert.AreEqual(fromEditForm.WholeContactString, fromViewPage);
        }
    }
}
