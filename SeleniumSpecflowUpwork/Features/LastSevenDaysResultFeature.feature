Feature: LastSevenDaysResultFeature
	Validate the result section only show last results from last 7 days only

@mytag
Scenario: show last results from last 7 days only
	Given User is navigated to Oddsking Website
	And Click on result button
	When User selects date range of last seven days
	Then results of last seven days are displayed