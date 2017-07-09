const controllers = require('../controllers')
const authCheck = require('./auth-check')

module.exports = (app) => {
  app.post('/users/register', controllers.users.registerPost)
  app.post('/users/login', controllers.users.loginPost)
  app.post('/users/logout', authCheck.isAuthorize, controllers.users.logout)

  app.get('/reviews/all', controllers.reviews.all)
  app.post('/reviews/add', authCheck.isAuthorize, controllers.reviews.add)
  app.get('/reviews/count', controllers.reviews.count)

  app.post('/appointment/add', controllers.appointment.add)
  app.post('/appointment/all', authCheck.isInRole('Admin'), controllers.appointment.all)
  app.post('/appointment/confirm', authCheck.isInRole('Admin'), controllers.appointment.confirm)

  app.all('*', (req, res) => {
    res.status(404).end()
  })
}
