using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebAddressbookTests;

namespace SeleniumTests
{
    [TestFixture]
    public class GroupCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";

            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        }

        // Methods
        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private void SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillGroupForm(GroupData name)//, string header, string footer)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(name.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(name.Header);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(name.Footer);
        }

        private void InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }

        private void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.UserName);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }
        
////////////////////////////////////////////////
        
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
