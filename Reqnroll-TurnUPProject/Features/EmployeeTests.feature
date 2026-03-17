Feature: Feature1

A short summary of the feature

@Regression
Scenario: Create Employee record with valid data
	Given Login to the Turn UP portal successfully
	When I naviagte to Employees page
	And I create a Employee record with valid data
	Then the employee record should be created successfully

Scenario Outline: edit existing time record with valid data
	Given Login to the Turn UP portal successfully
	When I naviagte to Employees page
	And I update the '<EmployeeName>' and '<EmpUsername>' on an existing Employee record
	Then the record should be the updated with '<EmployeeName>' and '<EmpUsername>'

Examples:
	| EmployeeName    | EmpUsername       |
	| Johnothan Clark | TestDescription01 |
	| Nick Hamilton   | TestDescription02 |
	| Matt Henry      | TestDescription03 |

Scenario: delete existing Employee record
	Given Login to Turn UP portal successfully
	When I naviagte to Employees page
	When I delete an existing Employee record
	Then the record should not be present on the list of Employee table