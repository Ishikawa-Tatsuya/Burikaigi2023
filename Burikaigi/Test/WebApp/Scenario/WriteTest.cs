using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.WebApp.PageObject;

namespace Test.WebApp.Scenario
{
    public class WriteTest
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();

            using (var context = DataUtility.CreateWriteDbContext())
            {
                context.魚.RemoveRange(context.魚);
            }
        }

        [TearDown]
        public void TearDown() => _driver.Dispose();

        [Test]
        public void 追加()
        {
            _driver.Url = "https://burikaigi2023w.azurewebsites.net/";

            var ログイン画面 = _driver.Attachログイン画面();
            ログイン画面.Adminでログイン();

            _driver.サイドバー().魚.Click();
            var 魚一覧 = _driver.Attach魚一覧();
            魚一覧.新規登録.Click();
            var 魚編集 = _driver.Attach魚編集();
            魚編集.名前.Edit("サンマ");
            魚編集.網.Edit("条鰭");
            魚編集.目.Edit("ダツ");
            魚編集.科.Edit("サンマ");
            魚編集.属.Edit("サンマ");
            魚編集.生息環境.Edit("北太平洋の亜熱帯海域の北側から亜寒帯海域 の南側までの全域");
            魚編集.食性.Edit("生まれた直後から肉食性");
            魚編集.星.Edit("★★★★★");
            魚編集.確定.Click();

            _driver.WaitForSuccess();

            var 魚一覧1 = _driver.Attach魚一覧();
            魚一覧1.テーブル.Count.Is(1);
        }
    }
}
