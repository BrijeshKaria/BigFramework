using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
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
        //public static string driverdir = @"C:\Users\Administrator\Downloads\chromedriver_win32";
        public static string driverdir = @"E:\SamplePrograms\chromedriver_win32";
        public static ChromeOptions options;
        public static IWebDriver embeddeddriver;

        [Given(@"Embedded app is running")]
        public void GivenEmbeddedAppIsRunning()
        {
            _chromeService = ChromeDriverService.CreateDefaultService(driverdir);
            _chromeService.HideCommandPromptWindow = true;
            _chromeService.Port = 9515;
            options = new ChromeOptions { DebuggerAddress = "127.0.0.1:9515" };
            options.BinaryLocation = @"C:\Users\Administrator\Documents\visual studio 2015\Projects\BigFramework\BigFramework.ThickClient\bin\x86\Debug\BigFramework.ThickClient.exe";
            options.AddArgument("--auto-open-devtools-for-tabs");
            options.AddArgument("--whitelisted-ips=127.0.0.1:9515");
            embeddeddriver = new ChromeDriver(driverdir, options);
        }

        [Then(@"Able to navigate app")]
        public void ThenAbleToNavigateApp()
        {
            ThenAbleToNavigateApp(embeddeddriver);
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

       

       


    }
}
