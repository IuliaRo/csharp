using System.Collections.Generic;
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
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.RemoveGroup(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }       
    }
}