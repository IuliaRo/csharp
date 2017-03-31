using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitCreatingNewContact();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Remove(int contactNumber)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contactNumber);
            RemoveContact();
            CloseAlert();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper Modify(int contactNumber, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contactNumber);
            InitContactModification(0);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();
            
        }
        
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//div[2]/input")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int contactNumber)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (contactNumber + 1) + "]")).Click();
            return this;
        }

        private List<ContactData> contactCache;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();

                ICollection<IWebElement> lines = driver.FindElements(By.CssSelector("tr"));

                foreach (IWebElement line in lines)
                {
                    var cells = line.FindElements(By.TagName("td")).ToList();
                    if (cells.Count != 0)
                    {
                        var lastName = cells[1].Text;
                        var firstName = cells[2].Text;
                        contactCache.Add(new ContactData(firstName, lastName));
                    }
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.TelephoneHome);
            Type(By.Name("mobile"), contact.TelephoneMobile);
            Type(By.Name("work"), contact.TelephoneWork);

            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.BirthdayDay);
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.BirthdayMonth);
            Type(By.Name("byear"), contact.BirthdayYear);
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.AnniversaryDay);
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.AnniversaryMonth);
            Type(By.Name("ayear"), contact.AnniversaryYear);
            Type(By.Name("address2"), contact.SecondaryAddress);
            Type(By.Name("phone2"), contact.SecondaryHome);
            Type(By.Name("notes"), contact.SecondaryNotes);

            return this;
        }

        public ContactHelper InitCreatingNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public bool CheckIfContactExists()
        {
            manager.Navigator.GoToHomePage();
            if (IsElementPresent(By.Name("selected[]")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                TelephoneHome = homePhone,
                TelephoneMobile = mobilePhone,
                TelephoneWork = workPhone,
                Email1 = email,
                Email2 = email2
            };
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
