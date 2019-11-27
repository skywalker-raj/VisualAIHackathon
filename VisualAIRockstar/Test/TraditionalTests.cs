using System;
using System.Collections.Generic;
using System.Linq;
using HackathonRockstar.Common;
using HackathonRockstar.Data_Classes;
using HackathonRockstar.PageObject;
using HackathonRockstar.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using static System.String;

namespace HackathonRockstar.Test
{     
    public class TraditionalTests
    {
        #region Base Methods

        [SetUp]
        public void Init()
        {
            //Navigate to App
            BrowserServices.Init(CommonMethods.Config["url"]);
            //For V2 app navigation
            //BrowserServices.Init(CommonMethods.Config["urlV2"]);
            //Navigate to App with Add For Dynamic Content Test only
            //BrowserServices.Init(CommonMethods.Config["urlwithadd"]);
            //Navigate to V2 app with Add For Dynamic Content Test only
            //BrowserServices.Init(CommonMethods.Config["urlwithaddV2"]);
        }

        [TearDown]
        public void Dispose()
        {
            BrowserServices.Dispose();
        }

        #endregion
        
        #region TestMethods

        [Test, Category("Login Page Verification")]
        public void Verify_Login_Page()
        {
            try
            {
                //Verifying all the elements are present in login form. 
                Assert.True(BrowserServices.IsElementPresent("CssSelector", LoginPageObjects.LogoLinkCssSelector), "Logo Link Should be present.");
                if(BrowserServices.IsElementPresent("CssSelector", LoginPageObjects.LoginFormHeaderCssSelector))
                {
                    Console.Out.WriteLine("Login Form header Should be present.");
                    var title = BrowserServices.GetElementText("CssSelector", LoginPageObjects.LoginFormHeaderCssSelector);
                    var headermsg = title == "Login Form"
                        ? "Login Form Header Should be present."
                        : $"Login Form Header has been changed to {title}";
                    Console.Out.WriteLine(headermsg);
                }
                Assert.True(BrowserServices.IsElementPresent("XPath", Format(LoginPageObjects.LoginFormLabelXPath, "Username")), "Username Label Should be present.");
                if (BrowserServices.IsElementPresent("XPath", Format(LoginPageObjects.LoginFormLabelXPath, "Password")))
                {
                    Console.Out.WriteLine("Password Label Should be present.");
                }
                else
                {
                    //Password Label Changed to Pwd
                    Assert.True(BrowserServices.IsElementPresent("XPath", Format(LoginPageObjects.LoginFormLabelXPath, "Pwd")), "Password Label Should be changed for V2 app.");
                }
                var userIconmsg = BrowserServices.IsElementPresent("CssSelector", LoginPageObjects.UserIconCssSelector)
                    ? "Username Icon Should be present."
                    : "Username Icon Should removed in V2 app.";
                Console.Out.WriteLine(userIconmsg);
                var passwordIconmsg = BrowserServices.IsElementPresent("CssSelector", LoginPageObjects.PasswordIconCssSelector)
                    ? "Password Icon Should be present."
                    : "Password Icon Should be removed in V2 app.";
                Console.Out.WriteLine(passwordIconmsg);
                Assert.True(BrowserServices.IsElementPresent("XPath", Format(LoginPageObjects.LoginFormLabelXPath, "Remember Me")), "Remember Me Label Should be present.");
                Assert.True(BrowserServices.IsElementPresent("CssSelector", LoginPageObjects.RememberMeCheckBoxCssSelector), "Remember Me Checkbox Should be present.");
                Assert.True(BrowserServices.IsElementPresent("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Username")), "Username Textbox Should be present.");
                var usernameplaceholder = BrowserServices.GetAttribute("XPath",
                    Format(LoginPageObjects.LoginFormTextBoxXPath, "Username"), "placeholder");
                var usernameplaceholdermsg = usernameplaceholder == CommonMethods.Config["usernameplaceholder"]
                    ? "Placeholder should contain msg prompting for username."
                    : $"Placeholder should contain username {usernameplaceholder} in V2 app.";
                Console.Out.WriteLine(usernameplaceholdermsg);
                if (BrowserServices.IsElementPresent("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Password")))
                {
                    Console.Out.WriteLine("Password Textbox Should be present.");
                    Assert.Equals(BrowserServices.GetAttribute("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Password"), "placeholder"), CommonMethods.Config["passwordplaceholder"]);
                }
                else
                {
                    Assert.True(BrowserServices.IsElementPresent("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Pwd")), "Password Textbox Should be present.");
                    Assert.AreEqual(BrowserServices.GetAttribute("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Pwd"), "placeholder"), CommonMethods.Config["passwordplaceholderV2"]);
                    Console.Out.WriteLine("Password Label Should be changed to Pwd in V2 app.");
                }
                Assert.True(BrowserServices.IsElementPresent("CssSelector", LoginPageObjects.LoginButtonCssSelector), "Login button Should be present.");
                Assert.AreEqual(BrowserServices.GetElementText("CssSelector", LoginPageObjects.LoginButtonCssSelector), CommonMethods.Config["loginButtonText"], Format("Login button Should have text {0}", CommonMethods.Config["loginButtonText"]));
                //Opend Id locator changed              
                if (BrowserServices.IsElementPresent("CssSelector", Format(LoginPageObjects.OpenIdLoginCssSelector, 1)))
                {
                    Assert.AreEqual(CommonMethods.Config["twitter"], BrowserServices.GetAttribute("CssSelector", Format(LoginPageObjects.OpenIdLoginCssSelector, 1), "src"));
                    Console.Out.WriteLine("Twitter OpenId Login should be present.");
                }
                else
                {
                    Assert.AreEqual(CommonMethods.Config["twitter"], BrowserServices.GetAttribute("CssSelector", Format(LoginPageObjects.OpenIdLoginV2CssSelector, 1), "src"));
                    Console.Out.WriteLine("CssSelector for OpenIdLogin for twitter Should be changed.");
                }
                if (BrowserServices.IsElementPresent("CssSelector", Format(LoginPageObjects.OpenIdLoginCssSelector, 2)))
                {
                    Assert.AreEqual(CommonMethods.Config["facebook"], BrowserServices.GetAttribute("CssSelector", Format(LoginPageObjects.OpenIdLoginCssSelector, 2), "src"));
                    Console.Out.WriteLine("Facebook OpenId Login should be present.");
                }
                else
                {
                    Assert.AreEqual(CommonMethods.Config["facebook"], BrowserServices.GetAttribute("CssSelector", Format(LoginPageObjects.OpenIdLoginV2CssSelector, 2), "src"));
                    Console.Out.WriteLine("CssSelector for OpenIdLogin for facebook Should be changed.");
                }
                var linkedInmsg = BrowserServices.IsElementPresent("CssSelector", Format(LoginPageObjects.OpenIdLoginCssSelector, 3))
                    ? BrowserServices.GetAttribute("CssSelector", Format(LoginPageObjects.OpenIdLoginCssSelector, 3), "src")
                    : "LinkedIn OpenId Login Should be removed in V2 app.";
                Console.Out.WriteLine(linkedInmsg);
            }
            catch (Exception e)
            {
                BrowserServices.ScreenShot("Login_Verification_Shot");
                Console.Out.WriteLine(e);                
            }            
        }

        [Test, Category("Data Driven")]
        public void Verify_Login_Functionality()
        {
            try
            {
                //Verifying error message for no username and paswword
                CommonMethods.ClickLoginButton();
                //Message changed for V2
                if (BrowserServices.GetElementText("CssSelector", LoginPageObjects.ErrorMessageCssSelector) == CommonMethods.Config["usernamepasswordmissing"])
                {
                    Console.Out.WriteLine("Error message for username password missing should be present.");
                }
                else
                {
                    Assert.AreEqual(BrowserServices.GetElementText("CssSelector", LoginPageObjects.ErrorMessageCssSelector), CommonMethods.Config["usernamepasswordmissingV2"]);
                    Console.Out.WriteLine("Error message for username password missing should be changed for V2 app.");
                }
                //Verifying error message for no paswword
                BrowserServices.EnterValueInTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Username"), CommonMethods.Config["username"]);
                CommonMethods.ClickLoginButton(); ;
                Assert.AreEqual(BrowserServices.GetElementText("CssSelector", LoginPageObjects.ErrorMessageCssSelector), CommonMethods.Config["passwordmissing"]);
                //Password missing message is hidden because of the z-index
                if (BrowserServices.GetAttribute("CssSelector", LoginPageObjects.ErrorMessageCssSelector, "style").Contains("z-index: -1;"))
                {
                    Console.Out.WriteLine("Password missing message should be hidden because of z index in V2 app.");
                }
                //Verifying error message for no username
                BrowserServices.ClearTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Username"));
                //Password Label Changed to Pwd
                if (BrowserServices.IsElementPresent("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Password")))
                {
                    BrowserServices.EnterValueInTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Password"), CommonMethods.Config["password"]);                    
                }
                else
                {
                    BrowserServices.EnterValueInTextBox("XPath", Format(LoginPageObjects.LoginFormTextBoxXPath, "Pwd"), CommonMethods.Config["password"]);
                    Console.Out.WriteLine("Password label should be changed to Pwd in V2 app.");
                }
                CommonMethods.ClickLoginButton();
                Assert.AreEqual(BrowserServices.GetElementText("CssSelector", LoginPageObjects.ErrorMessageCssSelector), CommonMethods.Config["usernamemissing"]);
                CommonMethods.Login(CommonMethods.Config["username"], CommonMethods.Config["password"]);
                Assert.True(BrowserServices.IsElementPresent("CssSelector", DashboardPageObject.CompareExpenseCssSelector), "Compare Expense Link should be present after the login.");
            }
            catch (Exception e)
            {
                BrowserServices.ScreenShot("Login_Functionality_Shot");
                Console.Out.WriteLine(e);               
            }            
        }

        [Test, Category("Table Sort")]
        public void Verify_Table_Sort()
        {            
            try
            {
                CommonMethods.Login(CommonMethods.Config["username"], CommonMethods.Config["password"]);
                Assert.True(BrowserServices.IsElementPresent("CssSelector", DashboardPageObject.CompareExpenseCssSelector), "Compare Expense Link should be present after the login.");
                int row = CommonMethods.GetRowCountInGrid();
                List<string> oldstatusList = new List<string>();
                List<string> olddateList = new List<string>();
                List<string> olddescriptionList = new List<string>();
                List<string> oldcategoryList = new List<string>();
                List<string> oldamountList = new List<string>();
                List<Transaction> oldTransactionsList = new List<Transaction>();
                List<string> newstatusList = new List<string>();
                List<string> newdateList = new List<string>();
                List<string> newdescriptionList = new List<string>();
                List<string> newcategoryList = new List<string>();
                List<string> newamountList = new List<string>();
                List<Transaction> newTransactionsList = new List<Transaction>();
                string dateValue = "";
                ////Extracting values from transaction grid
                for (int i = 1; i <= row; i++)
                {
                    oldstatusList.Add(BrowserServices.GetElementText("CssSelector", Format(DashboardPageObject.StatusValueCssSelector, i)));
                    olddescriptionList.Add(BrowserServices.GetElementText("CssSelector", Format(DashboardPageObject.DescriptionValueCssSelector, i)));
                    oldcategoryList.Add(BrowserServices.GetElementText("CssSelector", Format(DashboardPageObject.CategoryValueCssSelector, i)));
                    oldamountList.Add(BrowserServices.GetElementText("CssSelector", Format(DashboardPageObject.AmountValueCssSelector, i)));
                    IList<IWebElement> dateList = BrowserServices.FindElements("CssSelector", Format(DashboardPageObject.DateValueCssSelector, i));
                    foreach (IWebElement date in dateList)
                    {
                        dateValue += date.Text;
                    }
                    olddateList.Add(dateValue);
                    dateValue = "";
                    Transaction oldTransaction = new Transaction(oldstatusList[i-1], olddateList[i-1], olddescriptionList[i-1], oldcategoryList[i-1], oldamountList[i-1]);
                    oldTransactionsList.Add(oldTransaction);
                }
                //Clicking the amount label fro sorting
                CommonMethods.ClickAmountLabel();
                //Extracting new values from transaction grid
                for (int i = 1; i <= row; i++)
                {
                    newstatusList.Add(BrowserServices.GetElementText("CssSelector", Format(DashboardPageObject.StatusValueCssSelector, i)));
                    newdescriptionList.Add(BrowserServices.GetElementText("CssSelector", Format(DashboardPageObject.DescriptionValueCssSelector, i)));
                    newcategoryList.Add(BrowserServices.GetElementText("CssSelector", Format(DashboardPageObject.CategoryValueCssSelector, i)));
                    newamountList.Add(BrowserServices.GetElementText("CssSelector", Format(DashboardPageObject.AmountValueCssSelector, i)));
                    IList<IWebElement> dateList = BrowserServices.FindElements("CssSelector", Format(DashboardPageObject.DateValueCssSelector, i));
                    foreach (IWebElement date in dateList)
                    {
                        dateValue += date.Text;
                    }
                    newdateList.Add(dateValue);
                    dateValue = "";
                    //Checking whether the amount value is sorted.
                    if (i > 1)
                    {
                        var amountI = newamountList[i - 2].Replace("USD", "").Replace(" ", "");
                        var amountII = newamountList[i - 1].Replace("USD", "").Replace(" ", "");
                        if (Convert.ToDecimal(amountI) < Convert.ToDecimal(amountII))
                        {
                            Console.Out.WriteLine("Amount is sorted.");
                        }
                        //Sorting is not working
                        else
                        {
                            Console.Out.WriteLine("Amount is not sorted in V2 app.");
                        }
                    }
                    Transaction newTransaction = new Transaction(newstatusList[i - 1], newdateList[i - 1], newdescriptionList[i - 1], newcategoryList[i - 1], newamountList[i - 1]);
                    newTransactionsList.Add(newTransaction);
                }
                //Verifying the new transactionList to the old TransactionList
                foreach (Transaction transaction in newTransactionsList)
                {
                    Assert.True(oldTransactionsList.Any(x=> x.Status == transaction.Status && x.Amount == transaction.Amount && x.Description == transaction.Description && x.Date == transaction.Date && x.Category == transaction.Category), "Transactions data Should be intact even after clicking on amount.");
                }
            }
            catch (Exception e)
            {
                BrowserServices.ScreenShot("Table_Sort_Shot");
                Console.Out.WriteLine(e);
            }            
        }

        [Test, Category("Canvas Chart")]
        public void Verify_Compare_Expenses_Chart()
        {            
            try
            {
                CommonMethods.Login(CommonMethods.Config["username"], CommonMethods.Config["password"]);
                Assert.True(BrowserServices.IsElementPresent("CssSelector", DashboardPageObject.CompareExpenseCssSelector), "Compare Expense Link should be present after the login.");
                //Click Compare Expenses
                CommonMethods.ClickCompareExpense();
                Console.Out.WriteLine(
                    "Chart test can't be performed since the chart is a single canvas element and the details can't be extracted.");
                //Click Show Data For Next Year
                CommonMethods.ClickShowDataForNextYear();
                Console.Out.WriteLine(
                    "The data for next year is added but test can't be performed since the chart is a single canvas element and the details can't be extracted.");                
            }
            catch (Exception e)
            {
                BrowserServices.ScreenShot("Canvas_Chart_Shot");
                Console.Out.WriteLine(e);
            }         
        }

        [Test, Category("Dynamic Content")]
        public void Verify_Dynamic_Content()
        {            
            try
            {
                CommonMethods.Login(CommonMethods.Config["username"], CommonMethods.Config["password"]);
                Assert.True(BrowserServices.IsElementPresent("CssSelector", DashboardPageObject.CompareExpenseCssSelector), "Compare Expense Link should be present after the login.");
                //Verifying for the Flash Sale gif
                //FlashSale Gif is not present in V2
                if (BrowserServices.IsElementPresent("CssSelector", Format(DashboardPageObject.FlashSalesCssSelector, "2")))
                {
                    Assert.AreEqual(BrowserServices.GetAttribute("CssSelector", Format(DashboardPageObject.FlashSalesCssSelector, "2"), "src"), CommonMethods.Config["flashsale1"]);
                }
                else
                {
                    Assert.False(BrowserServices.IsElementPresent("CssSelector", Format(DashboardPageObject.FlashSalesCssSelector, "2")), "Flash Sale gif is not present.");
                    Console.Out.WriteLine("Flash Sale gif should be removed in V2 app.");
                }
                //FlashSale2 Gif is changed in V2
                if (BrowserServices.GetAttribute("CssSelector", Format(DashboardPageObject.FlashSalesCssSelector, "4"), "src") == CommonMethods.Config["flashsale2"])
                {
                    Console.Out.WriteLine("Flash Sale2 gif should be present.");
                }
                else if (BrowserServices.GetAttribute("CssSelector", Format(DashboardPageObject.FlashSalesCssSelector, "4"), "src") == CommonMethods.Config["flashsale3"])
                {
                    Console.Out.WriteLine("Flash Sale gif should be changed in V2 app.");
                }                                
            }
            catch (Exception e)
            {
                BrowserServices.ScreenShot("Dynamic_Content_Shot");
                Console.Out.WriteLine(e);
            }         
        }

        #endregion              
    }
}
