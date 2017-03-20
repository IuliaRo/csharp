using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            var newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            var group = new GroupData("aaa");
            group.Header = "bbb";
            group.Footer = "ccc";

            if (!app.Groups.CheckIfGroupExists())
            {
                app.Groups.Create(group);
            }

            app.Groups.Modify(1, newData);
        }
    }
}
