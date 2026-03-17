using NUnit.Framework;
using Reqnroll;
using Reqnroll_TurnUPProject.Pages;
using Reqnroll_TurnUPProject.Tests;
using Reqnroll_TurnUPProject.Utilities;
using System;

namespace Reqnroll_TurnUPProject.StepDefinitions
{
    [Binding]
    public class TM_TestsStepDefinitions : CommonDriver
    {
        [Given("Login to Turn UP portal successfully")]
        public void GivenLoginToTurnUPPortalSuccessfully()
        {
            BaseTest bs = new BaseTest();
            bs.ClosePasswordManagerPopup();

            LoginPage lp = new LoginPage();
            lp.LoginActions(driver);

        }

        [When("I naviagte to Time and Material page")]
        public void WhenINaviagteToTimeAndMaterialPage()
        {
            HomePage hp = new HomePage();
            hp.UserLoginConfirm(driver);
            hp.NavigatetoTMPage(driver);

        }

        [When("I create a Time record with valid data")]
        public void WhenICreateATimeRecordWithValidData()
        {
            {
                TMPage tmp = new TMPage();
                tmp.CreateTimeRecord(driver);
            }
        }

        [Then("the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tmp = new TMPage();

            String newCode = tmp.GetCode(driver);
            String newTypecode = tmp.GetTypeCode(driver);
            String newDescription = tmp.GetDescription(driver);
            String newPrice = tmp.GetPrice(driver);


            Assert.That(newCode == "Test-R1", "Actual Code and expected Code do not match.");
            Assert.That(newTypecode == "T", "Actual TypeCode and expected Code do not match.");
            Assert.That(newDescription == "Sample test description R1", "Actual Description and expected Description do not match.");
            Assert.That(newPrice == "$100.00", "Actual Price and expected Price do not match.");
        }

        [When("I update the {string} and {string} on an existing Time record")]
        public void WhenIUpdateTheAndOnAnExistingTimeRecord(string code, string description)
        {
            TMPage tmp = new TMPage();
            tmp.EditTimeRecord(driver, code, description);
        }

        [Then("the record should have the updated with {string} and {string}")]
        public void ThenTheRecordShouldHaveTheUpdatedWithAnd(string code, string description)
        {
            TMPage tmp = new TMPage();

            string editedCode = tmp.GetEditedCode(driver);
            string editedDescription = tmp.GetEditedDescription(driver);

            Assert.That(editedCode == code, "Expected Edited Code and actual edited code do not match.");
            Assert.That(editedDescription == description, "Expected Edited Description and actual edited description do not match.");
        }

        [When("I delete an existing record")]
        public void WhenIDeleteAnExistingRecord()
        {
            TMPage tmp = new TMPage();
            tmp.DeleteTimeRecord(driver);
        }

        [Then("the record should not be present on the list of Time and Material table")]
        public void ThenTheRecordShouldNotBePresentOnTheListOfTimeAndMaterialTable()
        {
             TMPage tmp = new TMPage();

            string deletedcode = tmp.GetDeletedCode(driver);
            Assert.That(deletedcode != "EditedRecord", "Record has not been deleted.");
        }


    }
}
