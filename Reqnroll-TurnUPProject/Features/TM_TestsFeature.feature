Feature: TM_Tests

A short summary of the feature

@regression
Scenario: Create Time record with valid data
	Given Login to Turn UP portal successfully
	When I naviagte to Time and Material page
	When I create a Time record with valid data
	Then the record should be created successfully
