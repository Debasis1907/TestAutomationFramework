using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestAutomationFramework.BaseClass;

namespace TestAutomationFramework.Pages
{
    
    public class LoginPage:TestBase
    {
        //IWebDriver driver;
        #region WebElement

        [FindsBy(How = How.Name, Using = "username")]
        IWebElement UserName;

        [FindsBy(How = How.Name, Using = "password")]
        IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//input[@value='Login']")]
        IWebElement LogIn;

        [FindsBy(How = How.XPath, Using = "//img[@class='img-responsive']")]
        IWebElement crmLogo;

        #endregion

        #region Actions

        public string validateLoginPageTitle()
        {
            return driver.Title;
        }

        public Boolean validatecrmImage()
        {
           return crmLogo.Displayed;
        }

        public HomePage validateLogin(string un,string pwd)
        {
            UserName.SendKeys(un);
            Password.SendKeys(pwd);
            Thread.Sleep(2000);
            LogIn.Click();
            return new HomePage();
        }

        #endregion
        public  LoginPage()
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
