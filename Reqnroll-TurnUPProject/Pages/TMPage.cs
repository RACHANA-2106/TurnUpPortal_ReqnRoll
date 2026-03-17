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

        private By clickonLastPaginationButton => By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]");


        public void CreateTimeRecord(IWebDriver driver)
        {
            IWebElement createNew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNew.Click();

            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            //Thread.Sleep(2000);
            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 5);

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

            Thread.Sleep(6000);

            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]", 10);

            try
            {
                IWebElement lastPaginationButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]"));
                lastPaginationButton.Click();
            }
            catch (StaleElementReferenceException e)
            {
                IWebElement lastPaginationButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]"));
                lastPaginationButton.Click();
            }

        }
        public string GetCode(IWebDriver driver)
        {
            Wait.WaitForElementToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 10);

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }
        public string GetTypeCode(IWebDriver driver)
        {
            IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            return newTypeCode.Text;
        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }


        public void EditTimeRecord(IWebDriver driver, String code, String description)
        {
            Thread.Sleep(10000);
            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]", 10);

            //IWebElement lastPaginationButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]"));
            IWebElement lastPaginationButton = driver.FindElement(clickonLastPaginationButton);
            lastPaginationButton.Click();

            Wait.WaitForElementToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 10);

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

            Thread.Sleep(10000);

            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]", 10);

            //IWebElement lastPaginationButton2 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span[1]"));
            IWebElement lastPaginationButton2 = driver.FindElement(clickonLastPaginationButton);
            lastPaginationButton2.Click();

        }
        public string GetEditedCode(IWebDriver driver)
        {
            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedCode.Text;
        }

        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;
        }
        public string GetEditedPrice(IWebDriver driver)
        {
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return editedPrice.Text;
        }
        public void DeleteTimeRecord(IWebDriver driver)
        {

            Thread.Sleep(10000);

            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);

            //IWebElement lastPageButton3 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            IWebElement lastPaginationButton = driver.FindElement(clickonLastPaginationButton);
            lastPaginationButton.Click();

            Wait.WaitForElementToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 15);

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            Thread.Sleep(8000);

            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(3000);

            driver.Navigate().Refresh();

            Thread.Sleep(10000);

            Wait.WaitForElementToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 10);

            IWebElement lastPaginationButton3 = driver.FindElement(clickonLastPaginationButton);
            lastPaginationButton3.Click();

        }
        public string GetDeletedCode(IWebDriver driver)
        {
            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return deletedCode.Text;
        }

    }
}
