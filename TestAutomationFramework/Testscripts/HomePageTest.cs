using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestAutomationFramework.BaseClass;
using TestAutomationFramework.Pages;
using TestAutomationFramework.Utility;

namespace TestAutomationFramework.Testscripts
{
    [TestClass]
   public class HomePageTest:TestBase
    {
        LoginPage loginpage;
        HomePage homepage;
        TestUtil testutil;
        ContactsPage contactspage;
        public HomePageTest()
        {

        }

        [TestInitialize]
        public void setUp()
        {
            Initialize();
            testutil = new TestUtil();
            loginpage = new LoginPage();
            contactspage = new ContactsPage();
            homepage = loginpage.validateLogin(ConfigurationManager.AppSettings.Get("username"), ConfigurationManager.AppSettings.Get("password"));
            Thread.Sleep(2000);
            
        }

   
        [TestMethod]
        public void verifyHomePageTitle()
        {
            string homepagetitle = homepage.validateHomePageTitle();
            Assert.AreEqual(homepagetitle, "CRMPRO","HomePage Title not matched");
        }

        [TestMethod]

        public void verifyUserNamelabel()
        {
            testutil.switchToFrame();
            Assert.IsTrue(homepage.validateUserName());
        }

        [TestMethod]

        public void verifyContacts()
        {
            testutil.switchToFrame();
           contactspage =  homepage.clickonContactsLink();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
