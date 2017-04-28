using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework.Constraints;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovingTests : TestBase
    {
        [Test]
        public void TestGroupRemoving()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.RemoveGroup(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(oldGroups[0]);

            oldGroups.Sort();
            newGroups.Sort();

            NUnit.Framework.Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
