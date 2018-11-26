# Puppeteer DEMO

## About

This demo showcases how to utilize Puppeteer for performing web application testing, specifically automating UI testing or end-to-end (E2E) testing.
The code will attempt to navigate to four sites with the first being a bogus site.  If the navigation is successful, a PDF of the current page will be created and stored under the `pdfs` directory.  All page loads will be logged in the terminal.

Similar technologies are CasperJS, WebDriverIO and Selenium WebDriver (Selenuim 2.0).

## Puppeteer Tool

Puppeteer is a wrapper around Chromium (Open-Sourced version of Chrome).  It provides a set of APIs for programmatically performing any type of operation on a web browser like navigating to a web page or interacting with the DOM.

## Instructions

Navigate to root directory of the project in the Terminal and then run the following commands:

>npm install  
>npm start

## Requirements

* Must have NodeJS 8+
* Must allow read/write access to `pdfs` directory