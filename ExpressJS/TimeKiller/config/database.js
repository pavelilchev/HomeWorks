const mongoose = require('mongoose')
const User = require('../models/user')

mongoose.Promise = global.Promise

module.exports = (settings) => {
  mongoose.connect(settings.db)
  let db = mongoose.connection

  db.once('open', err => {
    if (err) {
      throw err
    }

    console.log('MongoDB ready!')

    require('../models/Tag')
    require('../models/Meme')
    User.seedAdminUser()
  })

  db.on('error', err => console.log(`Database error: ${err}`))
}
