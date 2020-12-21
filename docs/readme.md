# User stories editor
...as a simple software

## About
Simple Unity Tools that helps developing features.

## Features
- Save UserStories as ScriptableObjects.
- Use JSON to export and import data.

## Config
It uses constant in class Settings

## Objects

### UserStory
It defines part of app / software, that is considered. For example we can consider game, where we want to implement save system. What should happen if game is saved. Also it has *reason* part, as user should include what makes issue important.

#### Request
**What user wants to do.**
Defines question or proposition, that is given by user to dev team.

`I want to save a game.`

#### WhyRequested
**Why user wants that.**
Defines reason, why user ask for particular feature or solution within it.

`...to continue from the point I finished last time.`

#### Answer
**What should've been done to solve the issue risen by user.**
Defines the solution, that dev team suggests.

`You can save progress by using save / load, quick save or after achieving checkpoint set by level designer.`

### UserCategory
Defines category, that we can group **UserStory** into.

### UserContainer
Defines group of user stories under one **UserCategory**.

## Used libraries
- Json.Net