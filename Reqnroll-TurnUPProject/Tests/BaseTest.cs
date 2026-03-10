using OpenQA.Selenium.Chrome;
using Reqnroll_TurnUPProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqnroll_TurnUPProject.Tests
{
    public class BaseTest: CommonDriver
    {
        public void ClosePasswordManagerPopup()
        {
            
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            driver = new ChromeDriver(options);
        }
     }
}
