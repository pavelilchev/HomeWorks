const crypto = require('crypto')

module.exports = {
  generateSalt: function() {
    return crypto.randomBytes(128).toString('base64')
  },
  generateHashedPassword: function(salt, pwd) {
    return crypto.createHmac('sha256', salt).update(pwd).digest('hex')
  }
}