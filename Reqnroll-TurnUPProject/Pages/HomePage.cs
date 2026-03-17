using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Reqnroll_TurnUPProject.Utilities;

namespace Reqnroll_TurnUPProject.Pages
{
    public class HomePage
    {
        public void UserLoginConfirm(IWebDriver driver)
        {

            IWebElement actualText = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
            if (actualText.Text == "Hello hari!")
            {
                Console.WriteLine("User logged in Successfully!");

            }
            else
            {
                Console.WriteLine("User login failed.");

            }
        }
        private By clickOnAdminTab => By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span");
        IWebElement adminTab;
        public void NavigatetoTMPage(IWebDriver driver)
        {
            //Naviage to TM page
            adminTab = driver.FindElement(clickOnAdminTab);
            adminTab.Click();

            Wait.WaitForElementToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);

            IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMaterialOption.Click();
        }
        public void NavigatetoEmployeesPage(IWebDriver driver)
        {
            // Naviage to Employees Page

            try
            {
                adminTab = driver.FindElement(clickOnAdminTab);
                adminTab.Click();
            }
            catch (StaleElementReferenceException e)
            {

                adminTab = driver.FindElement(clickOnAdminTab);
                adminTab.Click();
            }

            Wait.WaitForElementToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);

            IWebElement employeesOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
            employeesOption.Click();
        }

    }
}
