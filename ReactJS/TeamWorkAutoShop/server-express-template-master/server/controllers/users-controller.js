const encryption = require('../utilities/encryption')
const User = require('mongoose').model('User')
const jwt = require('jsonwebtoken')

module.exports = {
  registerPost: (req, res) => {
    let reqUser = req.body
    const validationResult = validateSignupForm(req.body)
    if (!validationResult.success) {
      return res.status(200).json({
        success: false,
        message: validationResult.message,
        errors: validationResult.errors
      })
    }

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
        return res.status(200).json({
          success: true,
          message: 'You have successfully signed up! Now you should be able to log in.'
        })
      })
      .catch(error => {
        let err = error.message
        if (err.indexOf('E11000') > -1) {
          err = 'Username already exist'
        }
        return res.status(200).json({
          success: false,
          message: err,
          errors: error.errors
        })
      })
  },
  loginPost: (req, res) => {
    let reqUser = req.body
    const validationResult = validateLoginForm(reqUser)
    if (!validationResult.success) {
      return res.status(200).json({
        success: false,
        message: validationResult.message,
        errors: validationResult.errors
      })
    }

    User.findOne({ username: reqUser.username })
      .then(user => {
        if (!user || !user.authenticate(reqUser.password)) {
          return res.status(200).json({
            success: false,
            message: 'Invalid user data'
          })
        }

        const payload = {
          sub: user._id
        }

        const token = jwt.sign(payload, 's3cret str1ng')
        const data = {
          username: user.username,
          userId: user._id
        }

        req.logIn(user, (err) => {
          if (err) {
            return res.status(200).json({
              success: false,
              message: err
            })
          }

          return res.status(200).json({
            success: true,
            message: 'You have successfully logged in!',
            token,
            user: data
          })
        })
      })
      .catch(error => {
        return res.status(200).json({
          success: false,
          message: error
        })
      })
  },
  logout: (req, res) => {
    req.logout()
    return res.status(200).json({
      success: true,
      message: 'You have successfully logged out!'
    })
  }
}

function validateSignupForm (payload) {
  const errors = {}
  let isFormValid = true
  let message = ''

  if (!payload || typeof payload.password !== 'string' || payload.password.trim().length < 4) {
    isFormValid = false
    errors.password = 'Password must have at least 4 characters.'
  }

  if (!payload || typeof payload.username !== 'string' || payload.username.trim().length === 0) {
    isFormValid = false
    errors.name = 'Please provide your username.'
  }

  if (!payload || typeof payload.username !== 'string' || payload.username.trim().length < 4 || payload.username.trim().length > 30) {
    isFormValid = false
    errors.name = 'Username must be between 4 and 30 characters.'
  }

  if (!payload || typeof payload.firstName !== 'string' || payload.firstName.trim().length === 0) {
    isFormValid = false
    errors.name = 'Please provide your First name.'
  }

  if (!payload || typeof payload.lastName !== 'string' || payload.lastName.trim().length === 0) {
    isFormValid = false
    errors.name = 'Please provide your Last name.'
  }

  if (!isFormValid) {
    message = 'Check the form for errors.'
  }

  return {
    success: isFormValid,
    message: message,
    errors: errors
  }
}

function validateLoginForm (payload) {
  const errors = {}
  let isFormValid = true
  let message = ''

  if (!payload || typeof payload.username !== 'string' || payload.username.trim().length === 0) {
    isFormValid = false
    errors.email = 'Please provide your username.'
  }

  if (!payload || typeof payload.password !== 'string' || payload.password.trim().length === 0) {
    isFormValid = false
    errors.password = 'Please provide your password.'
  }

  if (!isFormValid) {
    message = 'Check the form for errors.'
  }

  return {
    success: isFormValid,
    message: message,
    errors: errors
  }
}
