# Bupa MOT History Checker
This document serves as the comprehensive technical guideline for the Bupa MOT History project, which is part of the interview process for developer role at Bupa. Here, you'll find a detailed breakdown of all requirements, points of emphasis, and expectations for this task.

## Project Overview
The government provide access to vehicle MOT history through an API. You can use it to retrieve vehicle make, model, colour, and MOT Test History including reasons for failure and advisory notices.
To request the MOT Test History for registration XX10ABC the following request will need to be made: -
https://beta.check-mot.service.gov.uk/trade/vehicles/mot-tests?registration=XX10ABC

The task is to create an application that accepts a registration number as a parameter. The application should then display the following information about the vehicle: -

 Make

 Model

 Colour

 MOT Expiry Date

 Mileage at last MOT

The user should be able to interact with this tool using a web frontend. For this test, we would like
you to develop a Blazor application using dotnet; you can spend as much or as little time on the
exercise as you like, as long as the following requirements have been met.

 You have completed the user story below.

 Your code should compile and run in one step.

 Your code should be uploaded to an accessible Git repository

# User Story
As a user running the application

I want to view a vehicle MOT Expiry date if I submit a registration number (e.g. XX10ABC)So that I know when to renew the MOT for this vehicle

# Acceptance criteria
Given the application prompts the user for a registration number
When the user submits a valid registration number
Then the make, model, colour, current MOT expiry date and Mileage at the last MOT are displayed

# Technical Requirements:
This document outlines the interaction between a front-end application and a set of microservices via an API Gateway. The primary functionality is to allow users to determine vehicle details and MOT history.

## Components
### Front-end Application:
A user interface that accepts car registration as inputs. It communicates with the backend services through the API Gateway.

### API Gateway :
Acts as the entry point for the front-end application to interact with the backend microservices. It routes requests to the appropriate services and aggregates results.

### Microservices:
### MOTCheckInternalService:
 Takes a car registration number and returns the car details such as Make, Model, Colour etc.

 
## Technology Stack
●	Core Technology: C# .NET 8

●	Rate Limiting: ASP.NET Core rate limiting middleware

●	Unit Testing: xUnit

●	SDKs/Libraries: MediatR, FluentValidation,FluentValidation.AspNetCore

●	Front End Framework : Blazor 8	

●	Documentation: Swagger


## Development Considerations
●	Coding Best Practices: Following SOLID principles, clean code practices.

●	Unit Tests: Including test cases for all functionalities

●	Documentation: Comprehensive documentation of code, architecture, and design decisions.

●	Scalability & Maintainability: Ensuring that the platform can handle growth and is easy to maintain.


# Architectural Patterns:
●	Implementing CQRS (Command Query Responsibility Segregation) 

●	Domain-driven design, Gateway pattern.

## High Level Architecture:


## Workflow
![image](https://github.com/zahmed28/BupaMOTChecker/assets/86317150/7d668ea2-93de-4eb4-b53a-7cd8f3a3ca94)



# Front End App Setup

1.Ensure you have .NET 8 installed on your system.

2.Open the folder BupaMOTCheckerUI.sln

3.Build BupaMOTCheckerUI.sln and Run 

4.Access the application by navigating to https://localhost:7192 in your web browser.
![image](https://github.com/zahmed28/BupaMOTChecker/assets/86317150/ef763d5f-9bf6-4bd7-aa36-3827627deddb)
![image](https://github.com/zahmed28/BupaMOTChecker/assets/86317150/b1ce0ecd-ad71-45b3-b97b-e2b128e943e3)

![image](https://github.com/zahmed28/BupaMOTChecker/assets/86317150/df7f4754-6c52-49e0-b546-62119da90974)



# Back-End Services Setup
1.Open Services folder and open Services.sln

2.Build Services.sln and Run

3.Open APIGateway folder and open APIGateway.sln

4.Build APIGateway solution and run
