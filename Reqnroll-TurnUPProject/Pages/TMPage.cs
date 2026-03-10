using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Reqnroll_TurnUPProject.Utilities;

namespace Reqnroll_TurnUPProject.Pages
{
    public class TMPage
    {
        public void CreateTimeRecord(IWebDriver driver)
        {
            IWebElement createNew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNew.Click();


            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            //Thread.Sleep(2000);
            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 2);


            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("Test-R1");

            IWebElement description = driver.FindElement(By.Id("Description"));
            description.SendKeys("Sample test description R1");

            IWebElement priceClick = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div[1]/span[1]/span[1]/input[1]"));
            priceClick.Click();

            IWebElement price = driver.FindElement(By.Id("Price"));
            price.SendKeys("100");

            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();
            Thread.Sleep(3000);

            IWebElement lastPaginationButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]"));
            lastPaginationButton.Click();

            IWebElement newRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table[1]/tbody[1]/tr[last()]/td[1]"));

            if (newRecord.Text == "Test-R1")
            {
                Assert.Pass("Time record created successfully!");
            }
            else
            {
                Assert.Fail("Time record creation failed.");

            }
        }
        //    public string GetCode(IWebDriver driver)
        //{
        //    IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        //    return newCode.Text;
        //}
        //public string GetTypeCode(IWebDriver driver)
        //{
        //    IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
        //    return newTypeCode.Text;
        //}

        //public string GetDescription(IWebDriver driver)
        //{
        //    IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
        //    return newDescription.Text;
        //}

        //public string GetPrice(IWebDriver driver)
        //{
        //    IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
        //    return newPrice.Text;
        //}
        

       
        public void EditTimeRecord(IWebDriver driver, String code, String description, String price)
        {
            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]", 5);

            IWebElement lastPaginationButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]"));
            lastPaginationButton.Click();

            Wait.WaitForElementToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 3);

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.Clear();
            codeTextbox.SendKeys(code);

            IWebElement descriptionText = driver.FindElement(By.Id("Description"));
            descriptionText.Clear();
            descriptionText.SendKeys(description);

            IWebElement priceClick = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div[1]/span[1]/span[1]/input[1]"));
            priceClick.Click();

            IWebElement priceValue = driver.FindElement(By.Id("Price"));
            priceValue.Clear();
            //priceValue.SendKeys(price);

            IWebElement save = driver.FindElement(By.Id("SaveButton"));
            save.Click();

            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]", 3);

            IWebElement lastPaginationButton2 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]"));
            lastPaginationButton2.Click();

        }
        //public string GetEditedCode(IWebDriver driver)
        //{
        //    IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        //    return editedCode.Text;
        //}

        //public string GetEditedDescription(IWebDriver driver)
        //{
        //    IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
        //    return editedDescription.Text;
        //}
        //public string GetEditedPrice(IWebDriver driver)
        //{
        //    IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
        //    return editedPrice.Text;
        //}
        public void DeleteTimeRecord(IWebDriver driver)
        {

            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 3);

            IWebElement lastPageButton3 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton3.Click();

            Wait.WaitForElementToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 3);

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            //Thread.Sleep(1500);

   
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);

            driver.Navigate().Refresh();
            Wait.WaitForElementToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 3);

            IWebElement lastPageButton4 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPageButton4.Click();

            Wait.WaitForElementToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 3);

            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (deletedCode.Text != "Test-R1 Edited")
            {
                Console.WriteLine("Record deleted successfully");
            }
            else
            {
                Console.WriteLine("Record has not been delete.");
            }

        }

    }
}
