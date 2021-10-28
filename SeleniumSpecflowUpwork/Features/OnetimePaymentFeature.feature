Feature: OnetimePaymentFeature
	Validate the Payment is Made Successfully onetime

@mytag
Scenario: Successful onetime payment
	Given User is navigated to Payment Link
	And Click on Onetime button
	When user Enter Message Description
	When user Enter Payee and Card Details and Click Pay
	Then Payment Success Message is Displayed