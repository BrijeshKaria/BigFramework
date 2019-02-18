using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace BigFramework.WebApp.Tests
{
    [Binding]
    public class WebappNavigationSteps
    {

        [Given(@"App is running in chrome")]
        public void GivenAppIsRunningInChrome()
        {
            ChromeSession.chromedriver = new ChromeDriver(ChromeSession.driverdir);
            ChromeSession.chromedriver.Navigate().GoToUrl("http://localhost:4200/");
        }

        [Then(@"App navigation in chrome")]
        public void ThenAppNavigationInChrome()
        {
            ThenAbleToNavigateApp(ChromeSession.chromedriver);
        }

        public void ThenAbleToNavigateApp(IWebDriver driver)
        {
            var element = driver.FindElement(By.Id("btnfirstclick"));
            Assert.IsNotNull(element);

            var clickcount = driver.FindElement(By.Id("clickcount"));
            for (int i = 0; i < 10; i++)
            {
                var valbefore = clickcount.Text;
                int before = Convert.ToInt32(valbefore.Trim());
                element.Click();
                var valafter = clickcount.Text;
                int after = Convert.ToInt32(valafter.Trim());

                Assert.AreEqual(after, before + 1);
            }
        }


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
