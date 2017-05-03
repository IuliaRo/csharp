using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    public class RemoveProjectTests : TestBase
    {
        [Test]
        public void TestRemovingProject()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "456123",
            };
            var projectName = "project1";

            app.Login.Login(account);
            app.Project.RemoveProject(projectName);
        }
    }
}
