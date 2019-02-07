Feature: Thickclient


@mytag
Scenario Outline: Add Person Details
	Given I have entered <firstname> into the firstname
	And I have entered <lastname> into the lastname
	Then the <fullname> appears in fullname
Examples: 
| firstname | lastname | fullname      |
| "Brijesh"   | "Karia"    | "Brijesh Karia" |
| "Samir"     | "Sameja"   | "Samir Sameja"  |
| "Anand"     | "Mishra"   | "Anand Mishra"  |

Scenario: Clear Fields
When I click on Clear button
Then All Text Fields are cleared.

Scenario: Embedded web app navigation
Given Embedded app is running
Then Able to navigate app

Scenario: Web App navigation in chrome
Given App is running in chrome
Then App navigation in chrome
