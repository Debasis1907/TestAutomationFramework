using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationFramework.BaseClass;
using TestAutomationFramework.Utility;

namespace TestAutomationFramework.Pages
{
   public class ContactsPage:TestBase
    {
        #region WebElement
        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Contacts')]")]
        IWebElement contactsLabel;

        [FindsBy(How = How.Name, Using = "first_name")]
        IWebElement FirstName;

        [FindsBy(How = How.Name, Using = "surname")]
        IWebElement LastName;

        [FindsBy(How = How.Name, Using = "phone")]
        IWebElement Phone;

        [FindsBy(How = How.Name, Using = "mobile")]
        IWebElement Mobile;

        [FindsBy(How = How.Name, Using = "email")]
        IWebElement Email;

        [FindsBy(How = How.Name, Using = "company_position")]
        IWebElement CompanyPosition;

        [FindsBy(How = How.Name, Using = "department")]
        IWebElement Department;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit' and @value=' = SUBMIT = ']")]
        IWebElement Savebtn;
        
        #endregion

        public ContactsPage()
        {
            PageFactory.InitElements(driver, this);
        }

        #region Actions

        public Boolean verifyContactslabel()
        {
            return contactsLabel.Displayed;
        }

        public void selectContactsByName(string name)
        {
            driver.FindElement(By.XPath("//a[text()='"+name+"']//parent::td[@class='datalistrow']//preceding-sibling::td[@class='datalistrow']//input[@name='contact_id']")).Click();
        }

        public void createNewContact(string testName)
        {

            //SelectElement select = new SelectElement(driver.FindElement(By.Name("title")));
            // select.SelectByText(title);
            var UserData = ExcelData.GetTestData(testName);
            FirstName.SendKeys(UserData.FirstName);
            LastName.SendKeys(UserData.LastName);
            Phone.SendKeys(Convert.ToString(UserData.Phone));
            Email.SendKeys(UserData.Email);
            Department.SendKeys(UserData.Department);
            


        }
        #endregion
    }
}
