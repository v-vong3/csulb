# Vue CLI Demo

## About

This project demonstrates how to scaffold a project using the Vue CLI v2.x (vue-cli) tool.  It is important to note that at the time of authoring this demo, the CLI is on the v2.x branch and not the v3.x branch as it was still in alpha stage.  Also, this demo utilizes command line

## Instructions

  1. Install the latest verions of node & npm
  2. Install the Vue CLI - [Installation Guide](https://vuejs.org/v2/guide/installation.html#CLI)

      ``` bash
      npm install -g vue-cli
      ```

  3. Create the project using the Vue CLI where _project-name_ is the your project

      ``` bash
      vue init webpack project-name
      ```

  4. Change the current directory to the _project-name_ directory

      ``` bash
      cd project-name-dir
      ```
  5. Install all dependiences

      ``` bash
      npm install
      ```

  6. Starting the project

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
```

For a detailed explanation on how things work, check out the [guide](http://vuejs-templates.github.io/webpack/) and [docs for vue-loader](http://vuejs.github.io/vue-loader).

## Directory Structure

More information can be found [here](https://vuejs-templates.github.io/webpack/structure.html)

## Development Tooling

All plugins are for the Visual Studio Code IDE

* eslint - Enforcing ES2015+ coding conventions
* tslint - Enforcing TypeScript coding conventions
* vetur - Vue specific tooling like syntax highlighting and autocomplete
* veturpack - Additional tooling for Vue

## Chrome Tooling

* Vue Dev Tools - Adds Vue tab to Chrome's DevTools for enhancing the debugging experience in Vue projects
