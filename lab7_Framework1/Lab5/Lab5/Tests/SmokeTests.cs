using NUnit.Framework;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using Lab5.Driver;
using System.Drawing.Imaging;

namespace Lab5.Tests
{
    [TestFixture]
    public class SmokeTests
    {
        private IWebDriver Driver = DriverInstance.GetInstance();
        private Steps.Steps steps = new Steps.Steps();
        private static string USERNAME = StringUtils.DataStringUsername;
        private static string PASSWORD = StringUtils.DataStringPassword;
        private static string INCORRECT_CITY = StringUtils.DataStringIncorrectCity;
        private static string EERROR_TEXT = StringUtils.DataStringError;


        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void OneCanLoginBooking()
        {
            Logger.InitLogger();
            try
            {
                steps.LoginBooking(USERNAME, PASSWORD);                
                Assert.AreEqual(USERNAME, steps.GetLoggedInUserName());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);

                var screenshot = Driver.TakeScreenshot();
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }

        [Test]
        public void EnterIncorrecCity()
        {
            Logger.InitLogger();
            try
            {                
                steps.SearchingError(INCORRECT_CITY);
                Assert.AreEqual(EERROR_TEXT.Replace("\\r", "").Replace("\\n", ""), steps.SearchIncorrectCity());
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
                var screenshot = Driver.TakeScreenshot(); 
                var filePath = "D:\\" + DateTime.Now.ToString("dd_MM_yy_HH_mm_ss") + ".png";
                screenshot.SaveAsFile(filePath);
                throw ex;
            }
        }
    }
}
