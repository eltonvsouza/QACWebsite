using BoDi;
using NUnit.Framework;
using QACWebsite.Drivers;
using QACWebsite.PageObjects;
using QACWebsite.Support;

namespace QACWebsite.StepDefinitions
{
    [Binding]
    public class MainPageStepDefinitions
    {
        private readonly MainPageObject _mainPageObject;

        public MainPageStepDefinitions(ObjectContainer testThreadContainer) => _mainPageObject = new MainPageObject(testThreadContainer.BaseContainer.Resolve<BrowserDriver>().Current);

        [Given(@"the website wrapper element exists")]
        public void GivenTheWebsiteWrapperElementExists() => _mainPageObject.CheckBodyExists();

        [When(@"the background image block exists")]
        public void WhenTheBackgroundImageBlockExists() => _mainPageObject.CheckBackgroundImageExists();

        [Then(@"the background image (.*) exists")]
        public async void ThenTheBackgroundImageUrlExists(string url)
        {
            await ApiCall.RunAsync();


            var cssValue = _mainPageObject.GetBackgroundImageCss();
            Assert.True(cssValue.Contains(url));
        }

        [Then(@"the big text is (.*)")]
        public void ThenTheBigTextIs(string text)
        {
            var element = _mainPageObject.GetBigText();
            Assert.True(text.Equals(element));
        }

        /*
         * Menu Item and sub item
         */

        [Given(@"the mega menu wrapper exists")]
        public void GivenTheMegaMenuWrapperExists() => _mainPageObject.CheckMegaMenuExists();

        [When(@"the (.*) mega menu item exists")]
        public void WhenTheItemMegaMenuItemExists(string item) => _mainPageObject.CheckMenuItemExists(item);

        [Then(@"the (.*) sub menu item exists")]
        public void ThenTheSubitemSubMenuItemExists(string subItem) => _mainPageObject.CheckSubMenuItemExists(subItem);

        /*
         * Menu Navigation
         */

        [When(@"the user mouse hover (.*) and click on (.*) Sub Menu option")]
        public void WhenTheUserMouseHoverItemAndClickOnSubMenuOption(string item, string subItem) => _mainPageObject.HoverMenuItemClickSubMenuItem(item, subItem);

        [Then(@"Check if (.*) breadcrumbs exists")]
        public void ThenCheckIfItemBreadcrumbsExists(string subItem) => _mainPageObject.CheckBreadcrumbs(subItem);

        [Then(@"Check if (.*) title page exists")]
        public void ThenCheckIfItemTitlePageExists(string title) => _mainPageObject.CheckTitlePage(title);

        /*
         * Search
         */

        [Given(@"the user clicks on search icon")]
        public void GivenTheUserClicksOnSearchIcon() => _mainPageObject.ClickOnSearchIcon();

        //[When(@"the user type (.*)")]
        //public void WhenTheUserTypeAutomation(string word) => _mainPageObject.TypeWordToSearch(word);

        //[Then(@"click enter keyboard key")]
        //public void ThenClickEnterKeyboardKey() => _mainPageObject.ClickEnterKey();

        [Given(@"type (.*)")]
        public void GivenTypeAutomation(string word) => _mainPageObject.TypeWordToSearch(word);

        [When(@"click enter keyboard key")]
        public void WhenClickEnterKeyboardKey() => _mainPageObject.ClickEnterKey();

        [Then(@"Check the search result")]
        public void ThenCheckTheSearchResult() => _mainPageObject.CheckSearchResult();


    }
}
