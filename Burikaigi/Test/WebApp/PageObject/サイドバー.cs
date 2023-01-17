using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace Test.WebApp.PageObject
{
    public class サイドバー : ComponentBase
    {
        public AnchorDriver Home => ByText("Home").Wait();
        public AnchorDriver 魚 => ByText("魚").Wait();
        public AnchorDriver Logout => ByText("Logout").Wait();

        public サイドバー(IWebElement element) : base(element) { }
        public static implicit operator サイドバー(ElementFinder finder) => finder.Find<サイドバー>();
    }

    public static class サイドバーExtensions
    {
        [ComponentObjectIdentify]
        public static サイドバー サイドバー(this IWebDriver driver)
            => new MappingBase(driver).ByCssSelector("div[class='sidebar']").Wait();
    }
}