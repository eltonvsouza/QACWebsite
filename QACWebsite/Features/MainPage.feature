Feature: MainPage

Check the content on the main page

@Regression
@DataSource:ds_qac_website.xlsx @DataSet:MainPage
Scenario: BackgroundImage
	Given the website wrapper element exists
	When the background image block exists
	Then the background image <url> exists

@Regression
Scenario: BigText
	Given the website wrapper element exists
	When the background image block exists
	Then the big text is North America’s Largest Independent Software Quality Engineering Services Firm

@Regression
@DataSource:ds_qac_website.xlsx @DataSet:Menu
Scenario: MenuItem
	Given the mega menu wrapper exists
	When the <item> mega menu item exists
	Then the <subitem> sub menu item exists

@Navigation
@DataSource:ds_qac_website.xlsx @DataSet:MenuNavigation
Scenario: MenuNavigation
	Given the mega menu wrapper exists
	When the user mouse hover <item> and click on <subitem> Sub Menu option
	Then Check if <title> breadcrumbs exists
	And Check if <title> title page exists

@Search
Scenario: SearchContent
	Given the user clicks on search icon
	And type automation
	When click enter keyboard key
	Then Check the search result