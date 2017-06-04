const express = require('express')
const cookieParser = require('cookie-parser')
const bodyParser = require('body-parser')
const session = require('express-session')
const passport = require('passport')

module.exports = (app) => {
  app.set('views', './views')
  app.set('view engine', 'pug')
  app.use(cookieParser())
  app.use(bodyParser.urlencoded({ extended: true }))
  app.use(session({
    secret: 'neshto-taino!@#$%',
    resave: false,
    saveUninitialized: false
  }))
  app.use(passport.initialize())
  app.use(passport.session())

  app.use((req, res, next) => {
    if (req.user) {
      res.locals.user = req.user
    }

    next()
  })

  app.use((req, res, next) => {
    if (req.url.startsWith('/public')) {
      req.url = req.url.replace('/public', '')
    }

    next()
  }, express.static('public'))

  console.log('Express ready!')
}
