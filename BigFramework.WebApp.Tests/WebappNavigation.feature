Feature: WebappNavigation


@mytag
Scenario: Page Navigation
	Given I have WebApplication running
	When I click on about link
	Then content about works is displayed

