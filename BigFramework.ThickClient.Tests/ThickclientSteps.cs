using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace BigFramework.ThickClient.Tests
{
    [Binding]
    public class ThickClientSteps: ThickClientSession
    {
        [Given(@"I have entered ""(.*)"" into the firstname")]
        public void GivenIHaveEnteredIntoTheFirstname(string p0)
        {
            //ScenarioContext.Current.Pending();
            var firstname = session.FindElementByAccessibilityId("TBFirstName");
            Assert.IsNotNull(firstname);
            firstname.SendKeys(Keys.Control + "a" + Keys.Control);
            firstname.SendKeys(p0);
        }

        [Given(@"I have entered ""(.*)"" into the lastname")]
        public void GivenIHaveEnteredIntoTheLastname(string p0)
        {
            //ScenarioContext.Current.Pending();
            var lastname = session.FindElementByAccessibilityId("LastName");
            Assert.IsNotNull(lastname);
            lastname.SendKeys(Keys.Control + "a" + Keys.Control);
            lastname.SendKeys(p0);
        }

        [Then(@"the ""(.*)"" appears in fullname")]
        public void ThenTheAppearsInFullname(string p0)
        {
            //ScenarioContext.Current.Pending();
            //set firstname and last name and then check full name
            var fullname = session.FindElementByAccessibilityId("FullName");
            Assert.IsNotNull(fullname);
            Assert.AreEqual(p0, fullname.Text);
        }

        [When(@"I click on Clear button")]
        public void WhenIClickOnClearButton()
        {
            //ScenarioContext.Current.Pending();
            var clear = session.FindElementByAccessibilityId("btnClear");
            clear.Click();
        }

        [Then(@"All Text Fields are cleared\.")]
        public void ThenAllTextFieldsAreCleared_()
        {
            //set firstname and last name and then check full name
            var firstname = session.FindElementByAccessibilityId("TBFirstName");
            var lastname = session.FindElementByAccessibilityId("LastName");
            var fullname = session.FindElementByAccessibilityId("FullName");
            
            Assert.IsNotNull(firstname);
            Assert.IsNotNull(lastname);
            Assert.IsNotNull(fullname);

            Assert.AreEqual("", firstname.Text.Trim());
            Assert.AreEqual("", lastname.Text.Trim());
            Assert.AreEqual("", fullname.Text.Trim());
        }


        public static ChromeDriverService _chromeService;
        public static string driverdir = @"C:\Users\Administrator\Downloads\chromedriver_win32";
        public static ChromeOptions options;
        public static IWebDriver driver;

        [Given(@"Embedeed app is running")]
        public void GivenEmbedeedAppIsRunning()
        {
            _chromeService = ChromeDriverService.CreateDefaultService(driverdir);
            _chromeService.HideCommandPromptWindow = true;
            _chromeService.Port = 9515;
            options = new ChromeOptions { DebuggerAddress = "127.0.0.1:9515" };
            options.AddArgument("--auto-open-devtools-for-tabs");
            options.AddArgument("--whitelisted-ips=127.0.0.1:9515");
            driver = new ChromeDriver(driverdir, options);
        }

        [Then(@"Able to navigate app")]
        public void ThenAbleToNavigateApp()
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
            

            //element.SendKeys("webdriver");
            //element.SendKeys(Keys.Enter);

            //Thread.Sleep(5000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //wait.Until(x => x.Title.Contains("webdriver"));
        }


    }
}
