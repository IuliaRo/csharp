﻿using OpenQA.Selenium;

namespace mantis_tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        protected HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        protected void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By by)
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
    }
}
