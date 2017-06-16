const controllers = require('../controllers')
const auth = require('./auth')

module.exports = (app) => {
  app.get('/', controllers.home.index)

  app.get('/users/register', controllers.users.registerGet)
  app.post('/users/register', controllers.users.registerPost)
  app.get('/users/login', controllers.users.loginGet)
  app.post('/users/login', controllers.users.loginPost)
  app.post('/users/logout', auth.isAuthenticated, controllers.users.logout)
  app.get('/profile/:username', auth.isAuthenticated, controllers.users.profile)

  app.get('/tweet', auth.isAuthenticated, controllers.tweets.addGet)
  app.post('/tweet', auth.isAuthenticated, controllers.tweets.addPost)

  app.get('/tag/:tagName', controllers.tweets.tagsGet)

  app.get('/admin/all', auth.isInRole('Admin'), controllers.admin.all)

  app.all('*', (req, res) => {
    res.status(404)
    res.send('404 Not Found!')
    res.end()
  })
}
