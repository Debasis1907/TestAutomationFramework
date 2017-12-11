using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.BaseClass;

namespace TestAutomationFramework.Pages
{
    public class HomePage:TestBase
    {

        public HomePage()
        {
            PageFactory.InitElements(driver, this);
        }
        #region WebElements
        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'User: Naveen K')]")]
        IWebElement userNameLabel;

        [FindsBy(How = How.XPath, Using = "//a[@title='Contacts']")]
        IWebElement contactsLink;

        [FindsBy(How = How.XPath, Using = "//a[@title='Deals']")]
        IWebElement dealsLink;

        [FindsBy(How = How.XPath, Using = "//a[@title='New Contact']")]
        IWebElement newContactsLink;

        #endregion

        #region Actions

        public Boolean validateUserName()
        {
            return userNameLabel.Displayed;
        }

        public string validateHomePageTitle()
        {
            return driver.Title;
        }

        public ContactsPage clickonContactsLink()
        {
            //contactsLink.Click();
            clickOnNewContactsLinks();
            return new ContactsPage();
        }

        public DealsPage clickonDealsLink()
        {
            dealsLink.Click();
            return new DealsPage();
        }

        public void clickOnNewContactsLinks()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(contactsLink).Build().Perform();
            newContactsLink.Click();
        }

        #endregion
    }
}
