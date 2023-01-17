using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace Test.WebApp.PageObject
{
    public class 魚一覧のリスト一行 : ComponentBase
    {
        public IWebElement 名前 => ByXPath("td[1]").Wait().Find();
        public IWebElement 網 => ByXPath("td[2]").Wait().Find();
        public IWebElement 目 => ByXPath("td[3]").Wait().Find();
        public IWebElement 科 => ByXPath("td[4]").Wait().Find();
        public IWebElement 属 => ByXPath("td[5]").Wait().Find();
        public IWebElement 生息環境 => ByXPath("td[6]").Wait().Find();
        public IWebElement 食性 => ByXPath("td[7]").Wait().Find();
        public IWebElement 星 => ByXPath("td[8]").Wait().Find();
        public ButtonDriver 編集 => ByXPath("td[9]").ByTagName("button").Wait();

        public 魚一覧のリスト一行(IWebElement element) : base(element) { }
        public static implicit operator 魚一覧のリスト一行(ElementFinder finder) => finder.Find<魚一覧のリスト一行>();
    }
}