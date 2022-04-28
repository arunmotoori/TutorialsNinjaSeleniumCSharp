Feature: Register

User should be able to create an account in the application

Scenario: Register an account with valid details by filling all the fields
	Given I visit the website
	And I navigate to Register Account page
	When I enter valid details into the fields
		| firstname | lastname | telephone    | password |
		| arun      | motoori  | 1234567890   | 12345  |
	And I select yes for subscription
	And I select Privacy Policy
	And I click on Continue button
	Then Account should be created

Scenario: Register an account with valid details by filling only mandatory fields
	Given I visit the website
	And I navigate to Register Account page
	When I enter valid details into the fields
		| firstname | lastname | telephone    | password |
		| arun      | motoori  | 1234567890   | 12345  |
	And I select Privacy Policy
	And I click on Continue button
	Then Account should be created

Scenario: Register an account with providing any fields
	Given I visit the website
	And I navigate to Register Account page
	When I select Privacy Policy
	And I click on Continue button
	Then Account should not be created
	And Proper warning messages should be displayed