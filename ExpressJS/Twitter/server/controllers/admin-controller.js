const mongoose = require('mongoose')
const User = mongoose.model('User')

module.exports = {
  all: (req, res) => {
    User.find({'roles': 'Admin'})
    .then(users => {
      res.render('admin/all', { users: users })
    })
  }
}
