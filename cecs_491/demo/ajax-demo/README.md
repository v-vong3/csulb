# AJAX Communication Demo

## Description

An example of how to make Asynchronous JavaScript and XML (AJAX) calls from client-side code to server-side code. All traffic is done on the localhost.

## CORS

By default, some browsers are more strict than others when it comes to preflight CORS requests (i.e., Google Chrome and Microsoft Edge). To ensure that the demo works for stricter browsers, CORS was explicitly enabled between the front-end (localhost:3000) and the back-end (localhost:8080). 


## Directory

* back-end: Contains all code for running Express.js, which acts as the host for the web service endpoints
* front-end: Contains all code for the client-side web application including the AJAX code

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
   cd front-end
   ```
2. ```js
   npm install
   ```
3. ```js 
   npm start
   ```

  **Windows Users**: You may need to install lite-server as a global npm tool or use npx to execute it locally. 
