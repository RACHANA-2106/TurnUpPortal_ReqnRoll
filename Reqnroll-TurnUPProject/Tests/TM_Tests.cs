using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Reqnroll_TurnUPProject.Pages;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Reqnroll_TurnUPProject.Utilities;

namespace Reqnroll_TurnUPProject.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            BaseTest bs = new BaseTest();
            bs.ClosePasswordManagerPopup();

            LoginPage lp = new LoginPage();
            lp.LoginActions(driver);


            HomePage hp = new HomePage();
             hp.UserLoginConfirm(driver);
            hp.NavigatetoTMPage(driver);
        }
            [Test]
            public void CreateTimeRecordTest()
            {
                TMPage tmp = new TMPage();
                tmp.CreateTimeRecord(driver);
            }

            [Test]
            public void EditTimeRecordTest()
        {
            // Edit Time Record
            TMPage tmp = new TMPage();
            tmp.EditTimeRecord(driver, "Test-R1 Edited", "Sample Test-R1 desc Updated");
        }
        
        [Test]
        public void DeleteTimeRecordTest()
        {
            // Edit Time Record
            TMPage tmp = new TMPage();
            tmp.DeleteTimeRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
    
}
