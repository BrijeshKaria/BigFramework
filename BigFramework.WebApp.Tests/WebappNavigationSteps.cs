using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace BigFramework.WebApp.Tests
{
    [Binding]
    public class WebappNavigationSteps
    {
        [Given(@"I have WebApplication running")]
        public void GivenIHaveWebApplicationRunning()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on about link")]
        public void WhenIClickOnAboutLink()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"content about works is displayed")]
        public void ThenContentAboutWorksIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        //static string chromeDriverDir = "";
        //static ChromeDriverService 

        [BeforeTestRun]
        public static void Startup()
        {
             

            //driver.

        }
    }
}
