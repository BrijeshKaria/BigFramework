using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BigFramework.WebApp.Tests
{
    [Binding]
    public sealed class ChromeSession
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public static ChromeDriverService _chromeService;
        public static string driverdir = @"E:\SamplePrograms\chromedriver_win32";
        public static ChromeOptions options;
        public static IWebDriver chromedriver;




        [AfterTestRun]
        public static void Cleanup()
        {
            try
            {
                chromedriver.Quit();
            }
            catch { }
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

    }

}
