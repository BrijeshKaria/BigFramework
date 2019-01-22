using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace BigFramework.ThickClient.Tests
{
    /// <summary>
    /// Summary description for PersonScenarios
    /// </summary>
    [TestClass]
    public class PersonScenarios:ThickClientSession 
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }

        [TestMethod]
        public void UpdateFirstNameLastName()
        {
            //set firstname and last name and then check full name
            var firstname = session.FindElementByAccessibilityId("TBFirstName");
            var lastname = session.FindElementByAccessibilityId("LastName");
            var fullname = session.FindElementByAccessibilityId("FullName");
            Assert.IsNotNull(firstname);
            Assert.IsNotNull(lastname);
            Assert.IsNotNull(fullname);
            firstname.SendKeys(Keys.Control + "a" + Keys.Control);
            //editBox.SendKeys(Keys.Delete);
            firstname.SendKeys("Brijesh");
            lastname.SendKeys(Keys.Control + "a" + Keys.Control);
            lastname.SendKeys("Karia");
            Assert.AreEqual("Brijesh Karia", fullname.Text);
        }

        [TestMethod]
        public void UpdateNamesFindbyName()
        {
            //set firstname and last name and then check full name
            var firstname = session.FindElementByAccessibilityId("TBFirstName");
            var lastname = session.FindElementByName("LastName");
            var fullname = session.FindElementByAccessibilityId("FullName");
            Assert.IsNotNull(firstname);
            Assert.IsNotNull(lastname);
            Assert.IsNotNull(fullname);
            firstname.SendKeys(Keys.Control + "a" + Keys.Control);
            //editBox.SendKeys(Keys.Delete);
            firstname.SendKeys("Brijesh");
            lastname.SendKeys(Keys.Control + "a" + Keys.Control);
            lastname.SendKeys("Karia");
            Assert.AreEqual("Brijesh Karia", fullname.Text);
        }


    }
}
