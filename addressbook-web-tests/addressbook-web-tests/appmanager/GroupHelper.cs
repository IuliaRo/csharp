using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

      public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper RemoveGroup(int i, GroupData group = null)
        {
            
            manager.Navigator.GoToGroupsPage();
            if (!IsElementPresent(By.Name("selected[]")))
            {
                InitNewGroupCreation();
                FillGroupForm(group);
                SubmitGroupCreation();
            }
            SelectGroup(i);
            RemoveGroup();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int groupNumber, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(groupNumber);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        protected GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        protected GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        protected GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        protected GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        protected GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        protected GroupHelper FillGroupForm(GroupData name) //, string header, string footer)
        {
            Type(By.Name("group_name"), name.Name);
            Type(By.Name("group_header"), name.Header);
            Type(By.Name("group_footer"), name.Footer);
           
            return this;
        }

        protected GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }       
    }
}
