# AJAX Communication Demo

## Description

An example of how to make Asynchronous JavaScript and XML (AJAX) calls from client-side code to server-side code. All traffic is done on the localhost.

CORS is not needed since the traffic is not HTTPS.

## Directory

* back-end: Contains all code for the Express.js web service
* front-end: Contains all code for the web application

## Back-End Directions
1. ```sh 
   cd back-end
   ```
2. ```js
   npm install
   ```
3. ```sh 
   node server.js
   ```
   The server must be started for the AJAX call to work

## Front-End Directions
1. ```sh 
   cd back-end
   ```
2. ```js
   npm install
   ```
3. ```js 
   npm start
   ```