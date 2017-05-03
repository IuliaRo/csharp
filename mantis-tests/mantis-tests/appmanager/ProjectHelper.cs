using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager): base(manager) { }

        public void CreateNewProject(string projectName)
        {
            GoToProjectManagementPage();
            GoToProjectCreationPage();
            CreateProject(projectName);
            ClickAddProject();
            CheckThatProjectIsAdded(projectName);
        }

        public void RemoveProject(string projectName)
        {
            GoToProjectManagementPage();
            Remove(projectName);
            CheckThatProjectIsRemoved(projectName);
        }

        private void CheckThatProjectIsRemoved(string projectName)
        {
            Assert.IsFalse(driver.FindElements(By.LinkText(projectName)).Any());
        }

        public void Remove(string projectName)
        {
            driver.FindElement(By.LinkText(projectName)).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm.btn-white.btn-round")).Click();
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
        }

        public void GoToProjectManagementPage()
        {
            driver.FindElement(By.CssSelector("i.menu-icon.fa.fa-gears")).Click();
            driver.FindElement(By.LinkText("Управление проектами")).Click();
        }

        public void GoToProjectCreationPage()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
        }

        public void CheckThatProjectIsAdded(string projectName)
        {
            for (int i = 0; i < 30; i++)
            {
                if (!driver.FindElements(By.LinkText(projectName)).Any())
                {
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        public void ClickAddProject()
        {
            driver.FindElement(By.CssSelector("input.btn.btn-primary.btn-white.btn-round")).Click();
        }

        public void CreateProject(string projectName)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(projectName);
        }
    }
}
