using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected LoginHelper LoginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper GroupHelper;
        protected ContactHelper ContactHelper;
        protected IWebDriver driver;
        protected string baseURL;

        public ApplicationManager()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost";

            LoginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            GroupHelper = new GroupHelper(this);
            ContactHelper = new ContactHelper(this);
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return LoginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return GroupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return ContactHelper;
            }
        }      
    }
}
