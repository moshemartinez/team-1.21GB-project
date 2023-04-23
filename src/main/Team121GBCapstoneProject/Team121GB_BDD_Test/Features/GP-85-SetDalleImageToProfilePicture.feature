@Nathaniel
Feature: GP-85-SetDalleImageToProfilePicture

**As a user, I would like the ability to set my AI generated image as my profile picture in the app so that  I don't have to manually upload my image.**

This user story is about stream lining the experience users have when they user our apps Dalle image generator service. The version this feature improves on
makes a user have to download the image and then manualy upload the image. This user story combines those steps into a single button click.


@notLoggedIn
Scenario: A visitor cannot access the Dalle Image generation page
	Given I am not logged in
	And I am on the home page
	And I attempt to access the image generator page,
	Then I should be ask to login before accessing the page.

@LoggedIn
Scenario: A logged in user can access the Dalle Image generation page and enter a prompt
	Given I am a logged in user
	And I am on the home page
	And I navigate to the image generator page
	Then I should see a counter telling me how many image credits I have
	And I input a prompt
	And click the Generate Image Button my credits will decrease by 1

@LoggedIn
Scenario: A logged in user can access the Dalle Image generation page but if they have no credits they cannot generate an image
	Given I am a logged in user on the image generator page
	And I have no image credits left
	And I try and generate an image
	Then I will be told that I can't generate any more images

@LoggedIn
Scenario: A logged in user can access the Dalle Image generation page and set their profile image to the Dalle generated image
	Given I am a logged in user on the image generator page
	And I've generated an image
	When I click the button for setting it as my profile picture
	Then my profile picture will be updated to display the new profile image

@LoggedIn
Scenario: A logged in user can access the Dalle Image generation page but there was an error and they are notified
	Given I am a logged in user on the image generator page
	And I've enterred a prompt
	But the image generation failed
	Then I should be notified that something went wrong.