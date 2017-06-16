const mongoose = require('mongoose')
const encryption = require('../utilities/encryption')

const REQUIRED_VALIDATION_MESSAGE = '{PATH} is required'
const USERNAME_MINLEN_MESSAGE = [4, 'The `{PATH}` should be at least ({MINLENGTH}) characters.']
const USERNAME_MAXLEN_MESSAGE = [30, 'The `{PATH}` cannot be more than ({MAXLENGTH}) characters.']

let userSchema = new mongoose.Schema({
  username: { type: String, required: REQUIRED_VALIDATION_MESSAGE, unique: true, minlength: USERNAME_MINLEN_MESSAGE, maxlength: USERNAME_MAXLEN_MESSAGE },
  firstName: { type: String, required: REQUIRED_VALIDATION_MESSAGE },
  lastName: { type: String, required: REQUIRED_VALIDATION_MESSAGE },
  salt: String,
  hashedPass: String,
  roles: [String]
})

userSchema.method({
  authenticate: function (password) {
    return encryption.generateHashedPassword(this.salt, password) === this.hashedPass
  }
})

let User = mongoose.model('User', userSchema)

module.exports = User
module.exports.seedAdminUser = () => {
  User.find({}).then(users => {
    if (users.length > 0) return

    let salt = encryption.generateSalt()
    let hashedPass = encryption.generateHashedPassword(salt, '123456')

    User.create({
      username: 'Admin',
      firstName: 'Admin',
      lastName: 'Admin',
      salt: salt,
      hashedPass: hashedPass,
      roles: ['Admin']
    })
  })
}
