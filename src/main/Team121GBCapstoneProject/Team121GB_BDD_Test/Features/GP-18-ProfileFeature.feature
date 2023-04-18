@Cole
Feature: GP-14

A user would like to change their profile picture. Either they just made their account or would like to update their old one. 
Either way they would navigate to their profile page and click on a button somewhere around their profile 
and have it open up the file explorer and let them choose an image.


Background:
	Given the following users exist
	  | UserName   | Email                          | FirstName | LastName | Password   |
	  | TaliaK     | BDDTesting1@gmail.com          | Talia     | Knott    | Password1! |
	  | ZaydenC    | BDDTesting2@gmail.com          | Zayden    | Clark    | Password1! |
	  | DavilaH    | team121gigabytes@gmail.com     | Hareem    | Davila   | Password1! |
	And the following users do not exist
	  | UserName | Email               | FirstName | LastName | Password  |
	  | AndreC   | colea@example.com   | Andre     | Cole     | 0a9dfi3.a |
	  | JoannaV  | valdezJ@example.com | Joanna    | Valdez   | d9u(*dsF4 |

@LoggedIn
Scenario: Changing Profile Name
	Given I am a user with first name '<FirstName>'
	When I login
	And I navigate to the account preferences page
	Then I should see a form with a text box to edit my profile name and a submit button.
