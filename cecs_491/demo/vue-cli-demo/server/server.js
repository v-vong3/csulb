const express = require('express')
const cookieParser = require('cookie-parser')
const cors = require('cors')

const app = express()
const secret = 'Shared Secret'

app.use(cookieParser(secret))

// Required for local cross domain testing
// Should be removed for production release
app.use(cors())

// Typically, an HTTP HEAD endpoint is ideal for checking server status
// but an HTTP GET endpoint is the easiest to test through any web browser
app.get('/', (req, res) => {
  res.send('Server is alive')
})

app.post('/signIn', (req, res) => {
  let twentyMinutesFromNow = 1200000
  let randSessionId = Math.random()

  res.cookie('auth_Cookie', randSessionId, {
    maxAge: twentyMinutesFromNow,
    httpOnly: true,
    signed: true
  })
  res.status(200).send('Sign in success')
})

app.post('/signOut', (req, res) => {
  res.clearCookie('auth_Cookie', {path: '/'})
  res.status(200).send('Sign out success')
})

// Note that the port is different from the Vue site's, which results in a cross domain
app.listen(8081, () => console.log('Server started: http://localhost:8081'))
