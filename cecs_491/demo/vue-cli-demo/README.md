# Vue CLI Demo

## About

This project demonstrates how to scaffold a project using the Vue CLI v2.x (vue-cli) tool.  It is important to note that at the time of authoring this demo, the CLI is on the v2.x branch and not the v3.x branch as it was still in alpha stage.  Also, this demo assumes knowledge of nodeJS and npm.  If you need information regarding these topics, then I suggest reviewing the _vs-code-demo_.

## Instructions

  1. Install the latest verions of node & npm
  2. Install the Vue CLI - [Installation Guide](https://vuejs.org/v2/guide/installation.html#CLI)

      ``` bash
      npm install -g vue-cli
      ```

  3. Create the project using the Vue CLI where _project-name_ is the your project

      If you did not create a project directory, the Vue CLI will do so for you.

      ``` bash
      vue init webpack project-name
      ```

  4. Change the current directory to the _project-name_ directory if you are not already in it

      ``` bash
      cd project-name-dir
      ```

  5. Install useful dependencies for building complex applications

      ``` bash
      npm install --save vuex
      npm install --save axios
      npm install --save moment
      ```

  6. If using Express as a backend, install express as a dependency

      ``` bash
      npm install --save express
      ```

  7. Install all project dependiences locally

      ``` bash
      npm install
      ```

  8. Starting the project

      ``` bash
      npm run dev
      ```
      or
      ``` bash
      npm start
      ```

## Run options created by Vue CLI

``` bash
# install dependencies
npm install

# serve with hot reload at localhost:8080
npm run dev

# build for production with minification
npm run build

# build for production and view the bundle analyzer report
npm run build --report

# run unit tests
npm run unit

# run e2e tests
npm run e2e

# run all tests
npm test

# custom scripts created for use with pm2
npm run vue # for running webpack-dev-server with pm2
npm run server # for running express with pm2
npm run both # Command to run both 'vue' & 'server' at same time
```

For a detailed explanation on how things work, check out the [guide](http://vuejs-templates.github.io/webpack/) and [docs for vue-loader](http://vuejs.github.io/vue-loader).

## Directory Structure

The majority of the project structure comes straight from the Vue CLI. The only difference are the addition of the following:

* ./tsconfig.json - TypeScript support
* ./static/site.css - Demonstrates use of global styles that are not touched by webpack during builds
* ./components/shared - Placeholder directory for containing common components across pages
* ./server - Placeholder directory for server-side code (Express/node)

For more information on the "vanilla" project structure, go [here](https://vuejs-templates.github.io/webpack/structure.html)

## Recommended Development Tooling

### Node

* pm2 (Process Manager 2) - Manage multiple processes in node (AGPL-3.0 license)
* nodemon - Alternative to pm2 if you want software that is *MIT* licensed
* lite-server - Easy to use development HTTP server if you don't want to use webpack
* http-server - Production grade HTTP server

### Visual Studio Code

* eslint - Enforcing ES2015+ coding conventions
* tslint - Enforcing TypeScript coding conventions
* vetur - Vue specific tooling like syntax highlighting and autocomplete
* veturpack - Additional tooling for Vue

### Chrome Tooling

* Vue Dev Tools - Adds Vue tab to Chrome's DevTools for enhancing the debugging experience in Vue projects
* Postman - REST client for testing API endpoints
