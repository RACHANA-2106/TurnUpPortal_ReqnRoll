using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll_TurnUPProject.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reqnroll_TurnUPProject.Pages
{
    public class EmployeePage
    {

        public void CreateEmployeeRecord(IWebDriver driver)
        {
            IWebElement createNew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNew.Click();

            IWebElement name = driver.FindElement(By.XPath("//input[@id='Name']"));
            name.SendKeys("Rachel");

            IWebElement username = driver.FindElement(By.Id("Username"));
            username.SendKeys("TestEngineerR21");

            IWebElement contactNo = driver.FindElement(By.Id("ContactDisplay"));
            contactNo.SendKeys("0274561234");

            IWebElement password = driver.FindElement(By.XPath("//input[@name='Password']"));
            password.SendKeys("TestR@211");

            IWebElement retypePassword = driver.FindElement(By.Id("RetypePassword"));
            retypePassword.SendKeys("TestR@211");

            IWebElement adminCheckbox = driver.FindElement(By.CssSelector("#IsAdmin"));
            adminCheckbox.Click();

            IWebElement groupDropdown = driver.FindElement(By.CssSelector(".k-multiselect-wrap.k-floatwrap"));
            groupDropdown.Click();

            Wait.WaitForElementToBeClickable(driver, "XPath", "/html[1]/body[1]/div[5]/div[1]/ul[1]/li[1]", 8);

            IWebElement groupOption = driver.FindElement(By.XPath("/html[1]/body[1]/div[5]/div[1]/ul[1]/li[1]"));
            groupOption.Click();

            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();

            IWebElement list = driver.FindElement(By.CssSelector("div[id='container'] div a"));
            list.Click();

            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[4]/a[4]/span[1]", 10);

            IWebElement lastPaginationButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span[1]"));
            lastPaginationButton.Click();

            //IWebElement newEmpRecord = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table[1]/tbody[1]/tr[last()]/td[1]"));

        }
        public string GetEmpName(IWebDriver driver)
        {
            IWebElement newEmpRecordName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table[1]/tbody[1]/tr[last()]/td[1]"));
            return newEmpRecordName.Text;
        }
        public string GetEmpUsername(IWebDriver driver)
        {
            IWebElement newEmpRecordUsername = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table[1]/tbody[1]/tr[last()]/td[2]"));
            return newEmpRecordUsername.Text;
        }

        public void EditEmployeeRecord(IWebDriver driver, String empname, String empusername)
        {
            Thread.Sleep(5000);
            IWebElement lastPaginationButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span[1]"));
            lastPaginationButton.Click();

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            editButton.Click();

            IWebElement name = driver.FindElement(By.XPath("//input[@id='Name']"));
            name.Clear();
            name.SendKeys(empname);

            IWebElement username = driver.FindElement(By.Id("Username"));
            username.Clear();
            username.SendKeys(empusername);

            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();

            IWebElement list = driver.FindElement(By.CssSelector("div[id='container'] div a"));
            list.Click();

            Thread.Sleep(2000);

            IWebElement lastPaginationButton1 = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span[1]"));
            lastPaginationButton1.Click();


        }
        public string GetEditedEmpName(IWebDriver driver)
        {
            IWebElement newEmpName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table[1]/tbody[1]/tr[last()]/td[1]"));
            return newEmpName.Text;
        }
        public string GetEditedEmpUsername(IWebDriver driver)
        {
            IWebElement newEmpUsername = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table[1]/tbody[1]/tr[last()]/td[2]"));
            return newEmpUsername.Text;
        }

        public void DeleteEmployeeRecord(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement lastPaginationButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span[1]"));
            lastPaginationButton.Click();

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
            deleteButton.Click();

            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);

            driver.Navigate().Refresh();

            Thread.Sleep(3000);

        }
        public string GetDeletedEmployee(IWebDriver driver)
        {
            IWebElement deletedEmp = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return deletedEmp.Text;
        }
    }

}