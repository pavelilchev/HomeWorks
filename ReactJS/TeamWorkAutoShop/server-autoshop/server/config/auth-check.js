const jwt = require('jsonwebtoken')
const User = require('mongoose').model('User')
const secret = 's3cret str1ng'

module.exports = {
  isAuthorize: (req, res, next) => {
    if (!req.headers.authorization) {
      return res.status(401).end()
    }

    const token = req.headers.authorization.split(' ')[1]

    return jwt.verify(token, secret, (err, decoded) => {
      if (err) { return res.status(401).end() }

      const userId = decoded.sub

      User.findById(userId)
        .then(user => {
          if (!user) {
            return res.status(401).end()
          }

          req.user = user

          return next()
        })
    })
  },
  isInRole: (role) => {
    return (req, res, next) => {
      if (!req.headers.authorization) {
        return res.status(401).end()
      }

      const token = req.headers.authorization.split(' ')[1]

      return jwt.verify(token, secret, (err, decoded) => {
        if (err) { return res.status(401).end() }

        const userId = decoded.sub

        User.findById(userId)
          .then(user => {
            if (!user) {
              return res.status(401).end()
            }

            req.user = user
            if (user.roles.indexOf(role) < 0) {
              return res.status(401).end()
            }

            return next()
          })
      })
    }
  }
}
