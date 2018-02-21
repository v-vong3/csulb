# Redis Demo

## About

This project showcases the use of **Redis**, an in-memory Key-Value NoSQL data store, and **ioredis**, a Redis client for the **NodeJS** ecosystem.  The demo runs against a local Redis server under the default settings (127.0.0.1:6379).  Consequently, this demo will not work if you do not have both Node and the Redis server installed.

If you are not familiar with Node or NPM (especially, what the package.json file is) please review these topics first.

## Getting Start

Clone the repo and run the following commands

``` bash
# Installs all dependencies found in package.json
npm install

# Starts the demo
npm start
```

## Directory Structure

* src - Folder containing all source code
  * index.js - Actual source code of the demo.  Nested Promise structure to ensure synchronous output.
  * flatIndex.js - A code-flattend version of index.js.  Use for code comprehension only.  This file contains _expected_ code given the output.

* localbin - Folder containing babel registered files referenced for local development
  * dev - The main entry point for demo (no extension for file on purpose)

* dist - Temporary folder that will get generated when demo is started.  The repo will not have this folder present until "npm start" is executed
  * index - The babel-transpiled version fo index.js (no extension for file on purpose)

* .babelrc - babel 6 configurations

* .editorconfig - editor configuration for storing formating settings

* package.json - npm file for storing dependency information

## Ecosystem Dependencies (Install In Order)

1. NodeJS

    To install **NodeJS**, refer to their [site](https://nodejs.org/en/)

    To install via [homebrew](https://brew.sh/), use the following commands:

    ``` bash
    brew update

    brew install node
    ```

2. npm

    **npm** is automatically installed with **NodeJS**, but you can update it with the following command:

    ``` bash
    # Installs the latest version of npm globally
    # Globally means the 'npm' command is available everywhere in working directory
    npm install npm@latest -g
    ```

3. Redis (redis-server & redis-cli)

    To install **Redis**, refer to their [quick start guide](https://redis.io/topics/quickstart)

    To install via [homebrew](https://brew.sh/), use the following commands:

    ``` bash
    brew update

    brew install redis
    ```

    To run the Redis server:

    ``` bash
    # Starts the Redis server.  Press Control-C to stop/terminal
    redis-server /usr/local/etc/redis.conf
    ```

    To run the Redis CLI:

    ``` bash
    # Runs the Redis CLI so that you can interact with Redis manually in a bash shell
    redis-cli
    ```

    I would recommend that you create aliases in your .bashrc file for the above Redis commands to speed up development with Redis.

4. ioredis

   To install **ioredis**, refer to their [quick start](https://github.com/luin/ioredis#quick-start)

   To install via [npm](https://docs.npmjs.com/getting-started/installing-node#installing-npm-from-the-nodejs-site), use the following command:

    ``` bash
    # Installs ioredis npm package
    npm install ioredis
    ```

## Important

Note that for the **NodeJS** ecosystem, the two most popular Redis clients are **node_redis** and **ioredis**.  As of the time of this writting, the maintainers of both projects have decided to consolidate their efforts and converge code bases going forward.  Therefore, use of either client should be fine as the APIs will most likely have parity.
