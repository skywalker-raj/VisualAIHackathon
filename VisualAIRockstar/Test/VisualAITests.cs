using System;
using Applitools;
using Applitools.Selenium;
using Applitools.Utils.Geometry;
using HackathonRockstar.Common;
using HackathonRockstar.PageObject;
using HackathonRockstar.Services;
using NUnit.Framework;

namespace HackathonRockstar.Test
{
    [TestFixture]
    public class VisualAITests
    {
        #region Private properties

        private EyesRunner _runner;
        private Eyes _eyes;
        private const string Key = "V2SMURpRxCrei1faWBlDfjIowbQ5Vu98Xy101cn6105lQWc110";
        private BatchInfo _batchInfo;

        #endregion

        #region Base Methods

        [OneTimeSetUp]
        public void Setbatch()
        {
            //Set Batch
            _batchInfo = new BatchInfo("Visual Test") { Id = "Visual_test_batch" };
            //Initialize the Runner for your test.
            _runner = new ClassicRunner();
            // Initialize the eyes SDK (IMPORTANT: make sure your API key  is set in the APPLITOOLS_API_KEY env variable).
            _eyes = new Eyes(_runner)
            {
                ApiKey = Key,
                Batch = _batchInfo,
                ForceFullPageScreenshot = true
            };
        }

        [SetUp]
        public void BeforeEach()
        {
            
        }

        [TearDown]
        public  void AfterEach()
        {
            // Close the browser.
            BrowserServices.WebDriver.Quit();
            // If the test was aborted before eyes.close was called, ends the test as aborted.
            _eyes.AbortIfNotClosed();
            //Wait and collect all test results
            TestResultsSummary allTestResults = _runner.GetAllTestResults();
        }

        #endregion

        #region Test Methods

        [Test, Category("Login Page Verification")]
        public void Verify_Login_Page()
        {
            //Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            _eyes.Open(BrowserServices.WebDriver, "Hackathan App", "Login Page Verification", new RectangleSize(1366, 728));
            //Navigate the browser to the "ACME" demo app. To see visual bugs after the first run, use the commented line below instead.
            //BrowserServices.WebDriver.Url = CommonMethods.Config["url"];
            //Url navigation for V2 app.
            BrowserServices.WebDriver.Url = CommonMethods.Config["urlV2"];
            //Visual checkpoint #1 - Check the login page.
            _eyes.CheckWindow("Login Page"); 
            //End the test.
            _eyes.CloseAsync();
        }

        [Test, Category("Data Driven")]
        public void Verify_Login_Functionality()
        {
            //Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            _eyes.Open(BrowserServices.WebDriver, "Hackathan App", "Login Functionality Verification", new RectangleSize(1366, 728));
            //Navigate the browser to the "ACME" demo app. To see visual bugs after the first run, use the commented line below instead.
            BrowserServices.WebDriver.Url = CommonMethods.Config["url"];
            //Url navigation for V2 app.
            //BrowserServices.WebDriver.Url = CommonMethods.Config["urlV2"];
            //Click Login Button
            CommonMethods.ClickLoginButton();
            //Visual checkpoint #1 - Check the username and Password misssing message.
            _eyes.CheckWindow("Username & Password Missing");
            //Enter Username
            BrowserServices.EnterValueInTextBox("XPath", String.Format(LoginPageObjects.LoginFormTextBoxXPath, "Username"), CommonMethods.Config["username"]);
            //Click Login Button
            CommonMethods.ClickLoginButton();
            //Visual checkpoint #2 - Check the username missing message.
            _eyes.CheckWindow("Password Missing");
            //Clear Username
            BrowserServices.ClearTextBox("XPath", String.Format(LoginPageObjects.LoginFormTextBoxXPath, "Username"));
            //Enter Password
            BrowserServices.EnterValueInTextBox("XPath", String.Format(LoginPageObjects.LoginFormTextBoxXPath, "Password"), CommonMethods.Config["password"]);
            //CommonMethods.EnterValueInTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Pwds"), CommonMethods.Config["password"]);
            //Click Login Button
            CommonMethods.ClickLoginButton();
            //Visual checkpoint #3 - Check the password missing message.
            _eyes.CheckWindow("Username Missing");
            //Enter Username
            BrowserServices.EnterValueInTextBox("XPath", String.Format(LoginPageObjects.LoginFormTextBoxXPath, "Username"), CommonMethods.Config["username"]);
            //Click Login Button
            CommonMethods.ClickLoginButton();
            //Visual checkpoint #3 - Check the password missing message.
            _eyes.CheckWindow("Login Complete");
            //End the test.
            _eyes.CloseAsync();
        }

        [Test, Category("Table Sort")]
        public void Verify_Table_Sort()
        {
            // Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            _eyes.Open(BrowserServices.WebDriver, "Hackathan App", "Table Sort", new RectangleSize(1366, 728));
            // Navigate the browser to the "ACME" demo app. To see visual bugs after the first run, use the commented line below instead.
            BrowserServices.WebDriver.Url = CommonMethods.Config["url"];
            //Url navigation for V2 app.
            //BrowserServices.WebDriver.Url = CommonMethods.Config["urlV2"];
            //Login 
            CommonMethods.Login(CommonMethods.Config["username"], CommonMethods.Config["password"]);
            // Visual checkpoint #1 - Check the app page.
            _eyes.CheckWindow("Window With Transaction table before sorting");
            //Clicking Amount Label
            BrowserServices.FindElement("CssSelector", DashboardPageObject.AmountLabelCssSelector).Click();
            // Visual checkpoint #2 - Check the app page.
            _eyes.CheckWindow("Transaction table after sorting");
            // End the test.
            _eyes.CloseAsync();
        }

        [Test, Category("Canvas Chart")]
        public void Verify_Compare_Expense_Chart()
        {
            // Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            _eyes.Open(BrowserServices.WebDriver, "Hackathan App", "Canvas Chart", new RectangleSize(1366, 728));
            // Navigate the browser to the "ACME" demo app. To see visual bugs after the first run, use the commented line below instead.
            BrowserServices.WebDriver.Url = CommonMethods.Config["url"];
            //Url navigation for V2 app.
            //BrowserServices.WebDriver.Url = CommonMethods.Config["urlV2"];
            //Login 
            CommonMethods.Login(CommonMethods.Config["username"], CommonMethods.Config["password"]);
            Assert.True(BrowserServices.IsElementPresent("CssSelector", DashboardPageObject.CompareExpenseCssSelector), "Compare Expense Link should be present after the login.");
            //Click Compare
            CommonMethods.ClickCompareExpense();
            // Visual checkpoint #1 - Check the app page.
            _eyes.CheckWindow("Chart page with data for 2017 and 2018");
            //Click Show Data for next year
            CommonMethods.ClickShowDataForNextYear();
            // Visual checkpoint #2 - Check the app page.
            _eyes.CheckWindow("Chart page with data of 2019 added");
            // End the test.
            _eyes.CloseAsync();
        }

        [Test, Category("Dynamic Content")]
        public void Verify_Dynamic_Content()
        {
            // Start the test by setting AUT's name, window or the page name that's being tested, viewport width and height
            _eyes.Open(BrowserServices.WebDriver, "Hackathan App", "Dynamic Content", new RectangleSize(1366, 728));
            // Navigate the browser to the "ACME" demo app. To see visual bugs after the first run, use the commented line below instead.
            BrowserServices.WebDriver.Url = CommonMethods.Config["urlwithadd"];
            //Url navigation for V2 app.
            //BrowserServices.WebDriver.Url = CommonMethods.Config["urlwithaddV2"];
            //Login 
            CommonMethods.Login(CommonMethods.Config["username"], CommonMethods.Config["password"]);
            // Visual checkpoint #1 - Check the app page.
            _eyes.CheckWindow("Check for the adds");
            // End the test.
            _eyes.CloseAsync();
        }

        #endregion
    }
}
