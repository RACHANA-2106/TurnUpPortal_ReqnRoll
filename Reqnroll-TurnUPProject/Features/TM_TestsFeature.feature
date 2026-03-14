Feature: TM_Tests

A short summary of the feature

@regression
Scenario: Create Time record with valid data
	Given Login to Turn UP portal successfully
	When I naviagte to Time and Material page
	And I create a Time record with valid data
	Then the record should be created successfully

Scenario Outline: edit existing time record with valid data
	Given Login to Turn UP portal successfully
	When I naviagte to Time and Material page
	And I update the '<Code>' and '<Description>' on an existing Time record
	Then the record should have the updated with '<Code>' and '<Description>'

Examples:
	| Code           | Description   |
	| Test-R1 Edited | Apple Desc 1  |
	| TA Job Ready   | Mango Desc 2  |
	| EditedRecord   | Orange Desc 3 |
	

Scenario: delete existing time record
	Given Login to Turn UP portal successfully
	When I naviagte to Time and Material page
	When I delete an existing record
	Then the record should not be present on the list of Time and Material table
