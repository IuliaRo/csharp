using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace mantis_tests
{
    public class AddProjectTests : TestBase
    {
        [Test]
        public void TestAddingProject()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "456123",
            };
            var projectName = "project2";

            app.Login.Login(account);
            app.Project.CreateNewProject(projectName);
        }
    }
}
