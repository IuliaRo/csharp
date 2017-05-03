using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager): base(manager) { }

        public void Login(AccountData account)
        {
            OpenMainPage();
            EnterUserName(account.Name);
            ClickLogin();
            EnterPassword(account.Password);
            ClickLogin();
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(password);
        }

        public void ClickLogin()
        {
            driver.FindElement(By.CssSelector("input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110")).Click();
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.4.0/mantisbt-2.4.0/login_page.php";
        }

        public void EnterUserName(string userName)
        {
            driver.FindElement(By.Id("username")).SendKeys(userName);
        }
    }
}
