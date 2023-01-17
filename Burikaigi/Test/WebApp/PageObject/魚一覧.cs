using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace Test.WebApp.PageObject
{
    public class 魚一覧 : PageBase
    {
        LabelDriver Label_名前 => ByText("label", "名前").Wait();
        LabelDriver Label_網 => ByText("label", "綱").Wait();
        LabelDriver Label_目 => ByText("label", "目").Wait();
        LabelDriver Label_科 => ByText("label", "科").Wait();
        LabelDriver Label_属 => ByText("label", "属").Wait();
        LabelDriver Label_星 => ByText("label", "星").Wait();
        public ButtonDriver 検索 => ByText("検索").Wait();
        public ButtonDriver 新規登録 => ByText("新規登録").Wait();
        public TextBoxDriver 名前 => Label_名前.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 網 => Label_網.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 目 => Label_目.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 科 => Label_科.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 属 => Label_属.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 星 => Label_星.FindNext(By.TagName("input")).Wait();
        public ItemsControlDriver<魚一覧のリスト一行> テーブル => ByTagName("tbody").Wait();

        public 魚一覧(IWebDriver driver) : base(driver) { }
    }

    public static class 魚一覧Extensions
    {
        [PageObjectIdentify(TitleComapreType.Equals, "魚一覧")]
        public static 魚一覧 Attach魚一覧(this IWebDriver driver)
        {
            driver.WaitForTitle(TitleComapreType.Equals, "魚一覧");
            return new 魚一覧(driver);
        }
    }
}