using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Lab5.Page
{
    public class LoginPage : AbstractPage
    {
        private const string BASE_URL = "https://ru.trip.com/account/signin?curr=RUB&language=RU&locale=ru_ru&backurl=https%3A%2F%2Fru.trip.com%2Fhotels%2Flist%3Fcity%3Dundefined%26checkin%3D2019%2F12%2F27%26checkout%3D2019%2F12%2F28%26optionId%3Dundefined%26crn%3D1%26adult%3D1%26children%3D0%26searchBoxArg%3Dt%26travelPurpose%3D0%26ctm_ref%3Dix_sb_dl%26domestic%3D1";

        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement inputPassword;

        [FindsBy(How = How.Id, Using = "btnSubmitData")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.Id, Using = "account_order")]
        private IWebElement personLink;

        [FindsBy(How = How.XPath, Using = "//*[@id='account_order_list']/ul/li[4]/a")]
        private IWebElement linkSettings;

        [FindsBy(How = How.Id, Using = "oldemail")]
        private IWebElement userEmail;

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Login Page opened");
        }

        public void Login(string username, string password)
        {
            
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            personLink.Click();
            //driver.Navigate().GoToUrl("https://ru.trip.com/membersinfo/profile/"); 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            linkSettings.Click();
        }
        
        public string GetLoggedInUserName()
        {
            var v = userEmail.Text;
            return userEmail.Text;
        }
    }
}
