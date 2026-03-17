using NUnit.Framework;
using Reqnroll;
using Reqnroll_TurnUPProject.Pages;
using Reqnroll_TurnUPProject.Tests;
using Reqnroll_TurnUPProject.Utilities;
using System;

namespace Reqnroll_TurnUPProject.StepDefinitions
{
    [Binding]

    public class EmployeeTestsStepDefinitions : CommonDriver
    {

        [Given("Login to the Turn UP portal successfully")]
        public void GivenLoginToTurnUPPortalSuccessfully()
        {
            BaseTest bs = new BaseTest();
            bs.ClosePasswordManagerPopup();

            LoginPage lp = new LoginPage();
            lp.LoginActions(driver);

        }

        [When("I naviagte to Employees page")]
        public void WhenINaviagteToEmployeesPage()
        {
            HomePage hp = new HomePage();
            hp.NavigatetoEmployeesPage(driver);
        }

        [When("I create a Employee record with valid data")]
        public void WhenICreateAEmployeeRecordWithValidData()
        {
            EmployeePage emp = new EmployeePage();
            emp.CreateEmployeeRecord(driver);
        }

        [Then("the employee record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            EmployeePage emp = new EmployeePage();

            String empname = emp.GetEmpName(driver);
            String empusername = emp.GetEmpUsername(driver);

            Assert.That(empname == "Rachel", "Actual Employee Name and expected Employee Name do not match.");
            Assert.That(empusername == "TestEngineerR21", "Actual Employee Username and expected Employee Username do not match.");

        }
        [When("I update the {string} and {string} on an existing Employee record")]
        public void WhenIUpdateTheAndOnAnExistingEmployeeRecord(string empname, string empusername)
        {
            EmployeePage emp = new EmployeePage();
            emp.EditEmployeeRecord(driver, empname, empusername);

        }

        [Then("the record should be the updated with {string} and {string}")]
        public void ThenTheRecordShouldBeTheUpdatedWithAnd(string empname, string empusername)
        {
            EmployeePage emp = new EmployeePage();

            string editedEmpName = emp.GetEditedEmpName(driver);
            string editedUsername = emp.GetEditedEmpUsername(driver);

            Assert.That(editedEmpName == empname, "Expected edited EmpName and actual EmpName do not match.");
            Assert.That(editedUsername == empusername, "Expected edited Username and actual Username do not match.");
        }
        
        [When("I delete an existing Employee record")]
        public void WhenIDeleteAnExistingEmployeeRecord()
        {
            EmployeePage emp = new EmployeePage();
            emp.DeleteEmployeeRecord(driver);
        }

        [Then("the record should not be present on the list of Employee table")]
        public void ThenTheRecordShouldNotBePresentOnTheListOfEmployeeTable()
        {
            EmployeePage emp = new EmployeePage();

            string deletedEmployee = emp.GetDeletedEmployee(driver);
            Assert.That(deletedEmployee != "Matt Henry", "Record has not been deleted.");
        }



    }
}
