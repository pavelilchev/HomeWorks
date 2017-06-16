const encryption = require('../utilities/encryption')
const errorHandler = require('../utilities/error-handler')
const mongoose = require('mongoose')
const User = mongoose.model('User')
const Tweet = mongoose.model('Tweet')

module.exports = {
  registerGet: (req, res) => {
    res.render('users/register')
  },
  registerPost: (req, res) => {
    let reqUser = req.body
    // Add validations!

    let salt = encryption.generateSalt()
    let hashedPassword = encryption.generateHashedPassword(salt, reqUser.password)

    User.create({
      username: reqUser.username,
      firstName: reqUser.firstName,
      lastName: reqUser.lastName,
      salt: salt,
      hashedPass: hashedPassword
    })
      .then(user => {
        req.logIn(user, (err, user) => {
          if (err) {
            res.locals.globalError = err
            res.render('users/register', user)
          }

          res.redirect('/')
        })
      })
      .catch(error => {
        res.locals.globalError = errorHandler.handleMongooseError(error)
        res.render('users/register', {user: reqUser})
      })
  },
  loginGet: (req, res) => {
    res.render('users/login')
  },
  loginPost: (req, res) => {
    let reqUser = req.body
    User.findOne({ username: reqUser.username }).then(user => {
      if (!user) {
        res.locals.globalError = 'Invalid user data'
        res.render('users/login')
        return
      }

      if (!user.authenticate(reqUser.password)) {
        res.locals.globalError = 'Invalid user data'
        res.render('users/login')
        return
      }

      req.logIn(user, (err, user) => {
        if (err) {
          res.locals.globalError = err
          res.render('users/login')
        }

        res.redirect('/')
      })
    })
  },
  logout: (req, res) => {
    req.logout()
    res.redirect('/')
  },
  profile: (req, res) => {
    let username = req.params.username
    if (req.user.username !== username) {
      res.sendStatus(401)
      return
    }

    User.findOne({'username': username})
      .then(user => {
        if (!user) {
          res.sendStatus(404)
          return
        }

        Tweet.find({'author': user._id})
          .then(tweets => {
            res.render('users/profile', { tweets: tweets })
          })
      })
  }
}
