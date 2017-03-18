using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {     
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.RemoveGroup(1);
            app.Navigator.GoToGroupsPage();
        }       
    }
}
