using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {     
        [Test]
        public void GroupRemovalTest()
        {
            var group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";

            if (!app.Groups.CheckIfGroupExists())
            {
                app.Groups.Create(group);
            }
            app.Groups.RemoveGroup(1);
            app.Navigator.GoToGroupsPage();
        }       
    }
}
