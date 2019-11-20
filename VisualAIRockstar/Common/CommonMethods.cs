using System;
using HackathonRockstar.PageObject;
using HackathonRockstar.Services;
using Microsoft.Extensions.Configuration;
using static System.String;

namespace HackathonRockstar.Common
{
    public static class CommonMethods
    {
        #region Public Properties

        public static readonly IConfiguration Config = new ConfigurationBuilder().AddJsonFile(@"Data/config.json").Build();

        #endregion

        #region Public Methods

        public static void Login(string username, string password)
        {
            //Perform Login and Verify the login is successful
            BrowserServices.ClearTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Username"));
            BrowserServices.EnterValueInTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Username"), username);
            //Password Label changed to Pwd in V2
            if (BrowserServices.IsElementPresent("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Password")))
            {
                BrowserServices.ClearTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Password"));
                BrowserServices.EnterValueInTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Password"), password);                
            }
            else
            {
                Console.Out.WriteLine("Password Label Should be changed to Pwd in V2 app.");
                BrowserServices.ClearTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Pwd"));
                BrowserServices.EnterValueInTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Pwd"), password);                
            }
            ClickLoginButton();            
        }

        public static void ClickCompareExpense()
        {
            BrowserServices.FindElement("CssSelector", DashboardPageObject.CompareExpenseCssSelector).Click();
        }

        public static void ClickShowDataForNextYear()
        {
            BrowserServices.FindElement("XPath", DashboardPageObject.ShowDataForNextYearXPath).Click();
        }

        public static void ClickAmountLabel()
        {
            BrowserServices.FindElement("CssSelector", DashboardPageObject.AmountLabelCssSelector).Click();
        }

        public static int GetRowCountInGrid()
        {
            return BrowserServices.FindElements("CssSelector", DashboardPageObject.RowValueCssSelector).Count;
        }

        public static void ClickLoginButton()
        {
            BrowserServices.FindElement("CssSelector", LoginPageObjects.LoginButtonCssSelector).Click();
        }      

        #endregion
    }
}
