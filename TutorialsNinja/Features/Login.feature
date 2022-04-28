Feature: Login

User should be able to login to the account with proper credentials

Scenario Outline: Login with valid credentials
	Given I visit the website as a non-registered user
	And I navigate to Login page
	When I enter <username> username and <password> password
	And I click on Login button
	Then I should get loggedin
Examples: 
	| username               | password |
	| amotooricap9@gmail.com | 12345    |
	| amotooricap5@gmail.com | 12345    |
	| amotooricap1@gmail.com | 12345    |

