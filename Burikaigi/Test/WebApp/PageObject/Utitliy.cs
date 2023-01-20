using OpenQA.Selenium;
using Selenium.StandardControls;
using Selenium.StandardControls.PageObjectUtility;

namespace Test.WebApp.PageObject
{
    public static class Utitliy
    {
        public static void WaitForLoading(this IWebDriver driver)
        {
            try
            {
                driver.Until(() => driver.FindElement(By.CssSelector("div.backdrop[data-show] div.loading-box")),
                    TimeSpan.FromSeconds(1));
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }

            driver.Until(() =>
                    IsGone(driver, By.CssSelector("div.backdrop[data-show] div.loading-box")));
        }

        private static bool IsGone(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            return false;
        }

        public static string WaitForSuccess(this IWebDriver driver)
        {
            while (true)
            {
                Thread.Sleep(10);
                var msg = new MappingBase(driver).ByCssSelector("div[class='toaster toast-success']").Wait().Find().Text;
                if (string.IsNullOrEmpty(msg)) continue;
                return msg.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None).Last();
            }
        }

        public static void CloseSuccess(this IWebDriver driver)
        {
            var success = new MappingBase(driver).ByCssSelector("div[class='toaster toast-success']").Wait().Find();
            var button = new MappingBase(driver).ByCssSelector("div[class='toaster toast-success']").ByTagName("button").Wait().Find();
            button.Click();

            try
            {
                while (success.Displayed) Thread.Sleep(10);
            }
            catch { }
        }

        public static string WaitForError(this IWebDriver driver)
        {
            while (true)
            {
                Thread.Sleep(10);
                var msg = new MappingBase(driver).ByCssSelector("div[class='toaster toast-error']").Wait().Find().Text;
                if (string.IsNullOrEmpty(msg)) continue;
                return msg.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None).Last();
            }
        }
    }
}
