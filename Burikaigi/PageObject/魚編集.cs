using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class 魚編集 : PageBase
    {
        LabelDriver Label_名前 => ByText("名前").Wait();
        LabelDriver Label_網 => ByText("綱").Wait();
        LabelDriver Label_目 => ByText("目").Wait();
        LabelDriver Label_科 => ByText("科").Wait();
        LabelDriver Label_属 => ByText("属").Wait();
        LabelDriver Label_生息環境 => ByText("生息環境").Wait();
        LabelDriver Label_食性 => ByText("食性").Wait();
        LabelDriver Label_星 => ByText("星").Wait();
        public TextBoxDriver 名前 => Label_名前.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 網 => Label_網.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 目 => Label_目.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 科 => Label_科.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 属 => Label_属.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 生息環境 => Label_生息環境.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 食性 => Label_食性.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver 星 => Label_星.FindNext(By.TagName("input")).Wait();
        public ButtonDriver 戻る => ByText("戻る").Wait();
        public ButtonDriver 確定 => ByText("確定").Wait();
        public ButtonDriver 削除 => ByText("削除").Wait();

        public 魚編集(IWebDriver driver) : base(driver) { }
    }

    public static class 魚詳細Extensions
    {
        [PageObjectIdentify(TitleComapreType.Equals, "魚編集")]
        public static 魚編集 Attach魚編集(this IWebDriver driver)
        {
            driver.WaitForTitle(TitleComapreType.Equals, "魚編集");
            return new 魚編集(driver);
        }
    }
}