using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
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
            myViewPageObjects.ClickOnExcelExportLink();
            Assert.AreEqual("", verificationErrors.ToString());
        }

    }
}
