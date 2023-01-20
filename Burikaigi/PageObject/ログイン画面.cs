using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;
using Selenium.StandardControls.TestAssistant.GeneratorToolKit;

namespace PageObject
{
    public class ログイン画面 : PageBase
    {
        IWebElement Lable_ユーザーID => ByText("ユーザーID").Wait().Find();
        IWebElement Label_パスワード => ByText("パスワード").Wait().Find();
        public IWebElement RememberMe => ByText("Remember me?").Wait().Find();
        public ButtonDriver ログイン => ByText("ログイン").Wait();
        public TextBoxDriver ユーザーID => Lable_ユーザーID.FindNext(By.TagName("input")).Wait();
        public TextBoxDriver パスワード => Label_パスワード.FindNext(By.TagName("input")).Wait();

        public ログイン画面(IWebDriver driver) : base(driver) { }

        public void Adminでログイン()
        {
            ユーザーID.Edit("admin");
            パスワード.Edit("Abcdefg123##");
            RememberMe.Click();
            ログイン.Click();
        }
    }

    public static class PageObjectExtensions
    {
        [PageObjectIdentify(TitleComapreType.Equals, "Login")]
        public static ログイン画面 Attachログイン画面(this IWebDriver driver)
        {
            driver.WaitForTitle(TitleComapreType.Equals, "Login");
            return new ログイン画面(driver);
        }
    }
}