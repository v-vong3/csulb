const express = require('express')
const path = require('path')
const app = express()
const port = 3000

app.use(express.static('public'))
//app.get('/', (req, res) => res.sendFile(path.join(__dirname + '/index.html')))

app.listen(port, () => console.log(`Live on http:\/\/localhost:${port}`))