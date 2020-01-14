using System;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace Lab5.Driver
{
    public class DriverInstance
    {
        
        private static IWebDriver driver;

        private DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
