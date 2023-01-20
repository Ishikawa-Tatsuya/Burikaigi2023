using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test.WebApp.PageObject;

namespace Test.WebApp.Scenario
{
    public class UnitTest1
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup() => _driver = new ChromeDriver();

        [TearDown]
        public void TearDown() => _driver.Dispose();

        [Test]
        public void 検索()
        {
            _driver.Url = "https://burikaigi2023w.azurewebsites.net/";

            var ログイン画面 = _driver.Attachログイン画面();
            ログイン画面.ユーザーID.Edit("admin");
            ログイン画面.パスワード.Edit("Abcdefg123##");
            ログイン画面.RememberMe.Click();
            ログイン画面.ログイン.Click();

            _driver.サイドバー().魚.Click();

            var 魚一覧 = _driver.Attach魚一覧();
            魚一覧.科.Edit("タイ");
            魚一覧.検索.Click();

            //TODO くるくる待ち

            魚一覧.テーブル.Count.Is(2);
            魚一覧.テーブル.GetItem(0).名前.Text.Is("クロダイ");
            魚一覧.テーブル.GetItem(0).網.Text.Is("条鰭");
            魚一覧.テーブル.GetItem(0).目.Text.Is("スズキ");
            魚一覧.テーブル.GetItem(0).科.Text.Is("タイ");
            魚一覧.テーブル.GetItem(0).属.Text.Is("クロダイ");
            魚一覧.テーブル.GetItem(0).生息環境.Text.Is("汽水域から水深50m以浅の沿岸域の藻場や岩礁、砂泥底");
            魚一覧.テーブル.GetItem(0).食性.Text.Is("甲殻類、多毛類、軟体動物、海藻、小魚など");
            魚一覧.テーブル.GetItem(0).星.Text.Is("★★");
            魚一覧.テーブル.GetItem(0).編集.Text.Is("");
            魚一覧.テーブル.GetItem(1).名前.Text.Is("マダイ");
            魚一覧.テーブル.GetItem(1).網.Text.Is("条鰭");
            魚一覧.テーブル.GetItem(1).目.Text.Is("スズキ");
            魚一覧.テーブル.GetItem(1).科.Text.Is("タイ");
            魚一覧.テーブル.GetItem(1).属.Text.Is("マダイ");
            魚一覧.テーブル.GetItem(1).生息環境.Text.Is("大陸棚");
            魚一覧.テーブル.GetItem(1).食性.Text.Is("甲殻類、多毛類、軟体動物、小魚など");
            魚一覧.テーブル.GetItem(1).星.Text.Is("★★★");
        }

        [Test]
        public void 追加()
        {
            //データ削除→クラスわけてiniでやる

            _driver.Url = "https://burikaigi2023r.azurewebsites.net/";

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

            var 魚一覧1 = _driver.Attach魚一覧();
            魚一覧.テーブル.Count.Is(1);
        }

        //TODO ★で失敗してエラー表示が出るテスト
    }
}