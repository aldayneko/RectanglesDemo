Feature: Authentication

Scenario: [No authentication data]
	Given [I provided no authentication data]
	When [Search endpoint is called]
	Then [response is 401]

Scenario: [Wrong authentication data]
	Given [I provided wrong authentication data]
	When [Search endpoint is called]
	Then [response is 401]

Scenario: [Success authentication]
	Given [I provided valid authentication data]
	When [Search endpoint is called]
	Then [response is 200]
