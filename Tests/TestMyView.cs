using NUnit.Framework;
using System.Threading;
using TestMantisSelenium.BaseClass;
using TestMantisSelenium.Helpers;
using TestMantisSelenium.PageObjects;

namespace TestMantisSelenium.Tests
{
    [TestFixture]
    public class TestMyView : TestBase
    {
        [Test]
        [Category("CT")]
        public void ViewIssues()
        {
            Login login = new Login();
            login.DoLogin(driver);

            MyViewPageObjects myViewPageObjects = new MyViewPageObjects(driver);
            myViewPageObjects.ClickOnViewIssues();
            myViewPageObjects.ClickOnUnassignedIssues();
            myViewPageObjects.ClickOnCSVExportLink();
            Assert.AreEqual("", verificationErrors.ToString());
        }

    }
}
