using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };

            app.Groups.AddGroup(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
