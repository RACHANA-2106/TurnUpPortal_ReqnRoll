using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Reqnroll_TurnUPProject.Pages;
using System;
using System.Collections.Generic;
using System.Text;

using Reqnroll_TurnUPProject.Utilities;

namespace Reqnroll_TurnUPProject.Tests
{
    [TestFixture]
    public class EmployeeTests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            BaseTest bs = new BaseTest();
            bs.ClosePasswordManagerPopup();

            LoginPage lp = new LoginPage();
            lp.LoginActions(driver);


            HomePage hp = new HomePage();
            hp.NavigatetoEmployeesPage(driver);
        }
        [Test]
        public void CreateEmployeeTest()
        {
            EmployeePage emp = new EmployeePage();
            emp.CreateEmployeeRecord(driver);
        }
    }
}
