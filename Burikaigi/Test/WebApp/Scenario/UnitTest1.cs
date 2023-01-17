using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.WebApp.PageObject;

namespace Test.WebApp.Scenario
{
    public class UnitTest1
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://burikaigi2023r.azurewebsites.net/";
        }

        [TearDown]
        public void TearDown() => _driver.Dispose();

        [Test]
        public void Test1()
        {
            var pageObject = _driver.Attachログイン画面();
            pageObject.ユーザーID.Edit("admin");
            pageObject.パスワード.Edit("Abcdefg123##");
            pageObject.ログイン.Click();
        }
    }
}