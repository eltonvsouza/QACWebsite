using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace QACWebsite.PageObjects
{
    internal class MainPageObject
    {
        private readonly IWebDriver _webDriver;
        private static readonly string XPATH_BODY = "//div[@id='sb-site']";
        private static readonly string XPATH_BACKGROUND_IMAGE = "//div[@class='home-page-bg-img1-block']";
        private static readonly string XPATH_BIG_TEXT_ELEMENT = "//h1[@class='hp-h1']";
        private static readonly string XPATH_MEGA_MENU = "//ul[@id='mega-menu-primary']";
        private static readonly string XPATH_MENU_ITEM = XPATH_MEGA_MENU + "/li/a";
        private static readonly string XPATH_SUB_MENU_ITEM = XPATH_MEGA_MENU + "/li/ul[@class='mega-sub-menu']/li/a";
        private static readonly string XPATH_BREADCRUMBS = "//div[@class='breadcrumbs']";
        private static readonly string XPATH_TITLE_PAGE = "//article/div/div/div/h1";
        private static readonly string XPATH_TITLE_PAGE_2 = "//article/div/div/h1";
        private static readonly string XPATH_SEARCH_RESULT = "//div[@id='sb-site']/div/div/div/div/span[text()=\"Search results for 'automation'\"]";

        private IWebElement _bodyElement => _webDriver.FindElement(By.XPath(XPATH_BODY));
        private IWebElement _backgroundImageElement => _webDriver.FindElement(By.XPath(XPATH_BACKGROUND_IMAGE));
        private IWebElement _bigTextElement => _webDriver.FindElement(By.XPath(XPATH_BIG_TEXT_ELEMENT));
        private IWebElement _megaMenu => _webDriver.FindElement(By.XPath(XPATH_MENU_ITEM));
        private IWebElement _searchField=> _webDriver.FindElement(By.Id("s"));
        private IWebElement _searchResult=> _webDriver.FindElement(By.XPath(XPATH_SEARCH_RESULT));

        public MainPageObject(IWebDriver webDriver) => _webDriver = webDriver;

        public void CheckBodyExists() => _ = _bodyElement.Displayed;

        public void CheckBackgroundImageExists() => _ = _backgroundImageElement.Displayed;

        public string GetBackgroundImageCss()
        {
            var element = _backgroundImageElement;
            var cssValue = element.GetCssValue("background-image");
            return cssValue;
        }

        public string GetBigText()
        {
            var element = _bigTextElement;
            return element.Text;
        }

        public void CheckMegaMenuExists() => _ = _megaMenu.Displayed;

        public void CheckMenuItemExists(string item)
        {
            IWebElement menuItem = _webDriver.FindElement(By.XPath(XPATH_MENU_ITEM + "[text()='" + item + "']"));
            _ = menuItem.Displayed;
        }

        public void CheckSubMenuItemExists(string subItem)
        {
            List<String> options = new List<string>(subItem.Split(','));
            foreach (var item in options)
            {
                IWebElement menuItem = _webDriver.FindElement(By.XPath(XPATH_SUB_MENU_ITEM + "[text()='" + item + "']"));
                _ = menuItem.Displayed;
            }
        }

        public void HoverMenuItemClickSubMenuItem(string item, string subItem)
        {
            IWebElement menuItem = _webDriver.FindElement(By.XPath(XPATH_MENU_ITEM + "[text()='" + item + "']"));

            //WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            //IWebElement MenuItem = wait.Until(e => e.FindElement(By.XPath(XPATH_MENU_ITEM + "[text()='" + item + "']")));

            IWebElement element = _webDriver.FindElement(By.XPath(XPATH_SUB_MENU_ITEM + "[text()='" + subItem + "']"));
            Actions action = new Actions(_webDriver);

            action
                .MoveToElement(menuItem)
                .Perform();

            element.Click();
        }

        public void CheckBreadcrumbs(string breadCrumbs)
        {
            if (breadCrumbs != "Performance Engineering and Testing")
            {
                IWebElement element = _webDriver.FindElement(By.XPath(XPATH_BREADCRUMBS + "/span[text()='" + breadCrumbs + "']"));
                _ = element.Displayed;
            }
        }

        public void CheckTitlePage(string title)
        {
            IWebElement element;

            if (title == "Performance Engineering and Testing")
            {
                element = _webDriver.FindElement(By.XPath(XPATH_TITLE_PAGE_2 + "[text()='" + title + "']"));
                
            }
            else
            {
                element = _webDriver.FindElement(By.XPath(XPATH_TITLE_PAGE + "[text()='" + title + "']"));
            }
            _ = element.Displayed;
        }

        public void ClickOnSearchIcon() => _searchField.Click();

        public void TypeWordToSearch(string word) => _searchField.SendKeys(word);
        public void ClickEnterKey() => _searchField.SendKeys(Keys.Return);
        public void CheckSearchResult()
        {
            IWebElement element = _searchResult;
            _ = element.Displayed;
        }
    }
}
