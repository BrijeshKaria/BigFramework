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
Given Embedeed app is running
Then Able to navigate app

