using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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

    }
}
