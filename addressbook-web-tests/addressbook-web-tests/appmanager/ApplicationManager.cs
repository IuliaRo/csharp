using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper LoginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper GroupHelper;
        protected ContactHelper ContactHelper;

        private static ThreadLocal <ApplicationManager> app = new ThreadLocal<ApplicationManager>(); 

        private ApplicationManager()
        {
            driver = new FirefoxDriver(new FirefoxBinary("C:\\Program Files\\Mozilla Firefox\\firefox.exe"), new FirefoxProfile());
            baseURL = "http://localhost";

            LoginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            GroupHelper = new GroupHelper(this);
            ContactHelper = new ContactHelper(this);
        }

         ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
                
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get { return driver; }
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
