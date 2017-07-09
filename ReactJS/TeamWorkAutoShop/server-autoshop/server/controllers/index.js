const users = require('./users-controller')
const reviews = require('./reviews-controller')
const appointment = require('./appointment-controller')

module.exports = {
  users: users,
  reviews: reviews,
  appointment: appointment
}
