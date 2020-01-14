using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading.Tasks;

namespace Lab5.Page
{
    public class StartPage : AbstractPage
    {
        private const string BASE_URL = "https://ru.trip.com/hotels/list?city=undefined&checkin=2019/12/27&checkout=2019/12/28&optionId=undefined&crn=1&adult=1&children=0&searchBoxArg=t&travelPurpose=0&ctm_ref=ix_sb_dl&domestic=1";

        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "hotelsCity")]
        private IWebElement searchField;

        [FindsBy(How = How.XPath, Using = @"//*[@id='ibu_hotel_container']/..//div[1]/h3")]
        private IWebElement errorMessage;        

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Start Page opened");            
        }

        public void Searching(string city)
        {
            searchField.SendKeys(city + Keys.Enter);
        }

        public string ErrorMessageSearch()
        {
            return errorMessage.Text.ToString().Replace("\r", "").Replace("\n", "");
        }
    }
}
