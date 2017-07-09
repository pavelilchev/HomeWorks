const controllers = require('../controllers')
const authCheck = require('./auth-check')

module.exports = (app) => {
  app.post('/users/register', controllers.users.registerPost)
  app.post('/users/login', controllers.users.loginPost)
  app.post('/users/logout', authCheck.isAuthorize, controllers.users.logout)

  app.get('/reviews/all', controllers.reviews.all)
  app.post('/reviews/add', authCheck.isAuthorize, controllers.reviews.add)
  app.get('/reviews/count', controllers.reviews.count)

  app.all('*', (req, res) => {
    res.status(404).end()
  })
}
