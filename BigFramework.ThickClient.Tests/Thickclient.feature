Feature: Thickclient


@mytag
Scenario Outline: Add Person Details
	Given I have entered <firstname> into the firstname
	And I have entered <lastname> into the lastname
	Then the <fullname> appears in fullname
Examples: 
| firstname | lastname | fullname        |
| "Brijesh" | "Karia"  | "Brijesh Karia" |
| "Samir"   | "Sameja" | "Samir Sameja"  |
| "Anand"   | "Mishra" | "Anand Mishra"  |

Scenario: Clear Fields
When I click on Clear button
Then All Text Fields are cleared.


Scenario Outline: Update Person Details
	Given Update <firstname> into the firstname
	And Update <lastname> into the lastname
	Then the <fullname> is updated
Examples: 
| firstname | lastname | fullname        |
| "Brijesh" | "Karia"  | "Brijesh Karia" |
| "Samir"   | "Sameja" | "Samir Sameja"  |
| "Anand"   | "Mishra" | "Anand Mishra"  |


Scenario: Test Scroll
When I drag the scrollbar
Then Screen update


