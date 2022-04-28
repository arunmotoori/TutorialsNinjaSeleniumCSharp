Feature: Search

Searching of Products should be possible

Scenario: Search for a valid product
	Given I visit the website as a guest user
	When I enter valid product into the search box 
	And I click on search button
	Then I should see the product in the search results
