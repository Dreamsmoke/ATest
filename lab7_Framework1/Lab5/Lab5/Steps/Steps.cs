using System;
using OpenQA.Selenium;

namespace Lab5.Steps
{
    public class Steps
    {
        public IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginBooking(string username, string password)
        {
            Page.LoginPage loginPage = new Page.LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);
        }

        public string GetLoggedInUserName()
        {
            Page.LoginPage loginPage = new Page.LoginPage(driver);
            return loginPage.GetLoggedInUserName();
        }
        
        public void SearchingError(string incorrect_city)
        {
            Page.StartPage startPage = new Page.StartPage(driver);
            startPage.OpenPage();
            startPage.Searching(incorrect_city);
        }

        public string SearchIncorrectCity()
        {
            Page.StartPage startPage = new Page.StartPage(driver);
            return startPage.ErrorMessageSearch();
        }
    }
}
