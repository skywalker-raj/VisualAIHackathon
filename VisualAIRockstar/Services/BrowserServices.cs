using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HackathonRockstar.Services
{
    public static class BrowserServices
    {
        #region Public properties

        public static readonly IWebDriver WebDriver = new ChromeDriver(@"Executables/");
        //new ChromeDriver("./");
        
        #endregion

        #region Base Methods

        //[SetUp]
        public static void Init(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
            WebDriver.Manage().Window.Maximize();
        }

        //[TearDown]
        public static void Dispose()
        {
            WebDriver.Quit();
        }

        #endregion

        #region Browser Services      

        public static void ScreenShot(string screenShotName)
        {
            if (WebDriver is ITakesScreenshot ssdriver)
            {
                var screenShot = ssdriver.GetScreenshot();
                screenShot.SaveAsFile(screenShotName, ScreenshotImageFormat.Png);
            }
        }

        public static IWebElement FindElement(string locator, string value)
        {
            try
            {
                IWebElement element;
                switch (locator)
                {
                    case "XPath":
                        element = WebDriver.FindElement(By.XPath(value));
                        break;
                    case "Id":
                        element = WebDriver.FindElement(By.Id(value));
                        break;
                    case "Name":
                        element = WebDriver.FindElement(By.Name(value));
                        break;
                    case "ClassName":
                        element = WebDriver.FindElement(By.ClassName(value));
                        break;
                    case "TagName":
                        element = WebDriver.FindElement(By.TagName(value));
                        break;
                    case "LinkText":
                        element = WebDriver.FindElement(By.LinkText(value));
                        break;
                    case "CssSelector":
                    default:
                        element = WebDriver.FindElement(By.CssSelector(value));
                        break;
                }
                return element;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
                return null;
            }
        }

        public static IList<IWebElement> FindElements(string locator, string value)
        {
            try
            {
                IList<IWebElement> element;
                switch (locator)
                {
                    case "XPath":
                        element = WebDriver.FindElements(By.XPath(value));
                        break;
                    case "Id":
                        element = WebDriver.FindElements(By.Id(value));
                        break;
                    case "Name":
                        element = WebDriver.FindElements(By.Name(value));
                        break;
                    case "ClassName":
                        element = WebDriver.FindElements(By.ClassName(value));
                        break;
                    case "TagName":
                        element = WebDriver.FindElements(By.TagName(value));
                        break;
                    case "LinkText":
                        element = WebDriver.FindElements(By.LinkText(value));
                        break;
                    case "CssSelector":
                    default:
                        element = WebDriver.FindElements(By.CssSelector(value));
                        break;
                }
                return element;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
                return null;
            }
        }

        public static bool IsElementPresent(string locator, string value)
        {
            try
            {
                IWebElement element;
                switch (locator)
                {
                    case "XPath":
                        element = WebDriver.FindElement(By.XPath(value));
                        break;
                    case "Id":
                        element = WebDriver.FindElement(By.Id(value));
                        break;
                    case "Name":
                        element = WebDriver.FindElement(By.Name(value));
                        break;
                    case "ClassName":
                        element = WebDriver.FindElement(By.ClassName(value));
                        break;
                    case "TagName":
                        element = WebDriver.FindElement(By.TagName(value));
                        break;
                    case "LinkText":
                        element = WebDriver.FindElement(By.LinkText(value));
                        break;
                    case "CssSelector":
                    default:
                        element = WebDriver.FindElement(By.CssSelector(value));
                        break;
                }

                if (element != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
                return false;
            }
        }

        public static bool IsElementEnabled(string locator, string value)
        {
            try
            {
                bool enabled;
                switch (locator)
                {
                    case "XPath":
                        enabled = WebDriver.FindElement(By.XPath(value)).Enabled;
                        break;
                    case "Id":
                        enabled = WebDriver.FindElement(By.Id(value)).Enabled;
                        break;
                    case "Name":
                        enabled = WebDriver.FindElement(By.Name(value)).Enabled;
                        break;
                    case "ClassName":
                        enabled = WebDriver.FindElement(By.ClassName(value)).Enabled;
                        break;
                    case "TagName":
                        enabled = WebDriver.FindElement(By.TagName(value)).Enabled;
                        break;
                    case "LinkText":
                        enabled = WebDriver.FindElement(By.LinkText(value)).Enabled;
                        break;
                    case "CssSelector":
                    default:
                        enabled = WebDriver.FindElement(By.CssSelector(value)).Enabled;
                        break;
                }
                return enabled;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
                return false;
            }
        }

        public static bool IsElementDisplayed(string locator, string value)
        {
            try
            {
                bool displayed;
                switch (locator)
                {
                    case "XPath":
                        displayed = WebDriver.FindElement(By.XPath(value)).Displayed;
                        break;
                    case "Id":
                        displayed = WebDriver.FindElement(By.Id(value)).Displayed;
                        break;
                    case "Name":
                        displayed = WebDriver.FindElement(By.Name(value)).Displayed;
                        break;
                    case "ClassName":
                        displayed = WebDriver.FindElement(By.ClassName(value)).Displayed;
                        break;
                    case "TagName":
                        displayed = WebDriver.FindElement(By.TagName(value)).Displayed;
                        break;
                    case "LinkText":
                        displayed = WebDriver.FindElement(By.LinkText(value)).Displayed;
                        break;
                    case "CssSelector":
                    default:
                        displayed = WebDriver.FindElement(By.CssSelector(value)).Displayed;
                        break;
                }
                return displayed;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
                return false;
            }
        }

        public static string GetElementText(string locator, string value)
        {
            IWebElement element = FindElement(locator, value);
            return element.Text;
        }

        public static string GetAttribute(string locator, string value, string attribute)
        {
            IWebElement element = FindElement(locator, value);
            return element.GetAttribute(attribute);
        }

        public static void ClearTextBox(string locator, string value)
        {
            FindElement(locator, value).Clear();
        }

        public static void EnterValueInTextBox(string locator, string value, string text)
        {
            FindElement(locator, value).SendKeys(text);
        }

        #endregion

    }
}
