using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class Index : PageBase
    {

        public Index(IWebDriver driver) : base(driver) { }
    }

    public static class IndexExtensions
    {
        [PageObjectIdentify(TitleComapreType.Equals, "Index")]
        public static Index AttachIndex(this IWebDriver driver)
        {
            driver.WaitForTitle(TitleComapreType.Equals, "Index");
            return new Index(driver);
        }
    }
}