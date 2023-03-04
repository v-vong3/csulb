# Nightwatch.js Demo

## Description

Provides examples of testing automation using [Nightwatch.js 2.0](https://nightwatchjs.org/)

Nightwatch allows for the automation of the following:

* End to End (E2E) testing
* Unit testing JavaScript
* Automating browser interactions

## What is Nightwatch?

Nightwatch is an abstraction layer on top of W3C WebDriver (specifically Selenium-Webdriver). This enables a developer to create a single test script that can target and run on multiple browsers.

It consist of a built-in assertion framework, programmatic APIs and a CLI test runner.  

[Nightwatch APIs](https://nightwatchjs.org/api)

### Supported Browser Engines

* Firefox (GeckoDriver)
* Chrome (ChromeDriver)
* Edge (EdgeDriver)
* Safari (SafariDriver)

## Directions

1. Install/update required node packages  
    ```npm install```

2. Run the demo  
    ```npm run test:nw```  

    Both the front-end UI and Nightwatch will be executed.  You can execute these components separately with the following commands:  

    ```npm run nw:front-end```  
    ```npm run nw```  
