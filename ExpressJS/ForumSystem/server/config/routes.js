const controllers = require('../controllers')
const auth = require('./auth')

module.exports = (app) => {
  app.get('/', controllers.home.index)
  app.get('/about', auth.isAuthenticated, controllers.home.about)

  app.get('/users/register', controllers.users.registerGet)
  app.post('/users/register', controllers.users.registerPost)
  app.get('/users/login', controllers.users.loginGet)
  app.post('/users/login', controllers.users.loginPost)
  app.post('/users/logout', auth.isAuthenticated, controllers.users.logout)
  app.get('/users/profile/:username', auth.isAuthenticated, controllers.users.profile)

  app.post('/comments/add', auth.isAuthenticated, controllers.comments.addComment)

  app.get('/posts/add', auth.isAuthenticated, controllers.posts.addGet)
  app.post('/posts/add', auth.isAuthenticated, controllers.posts.addPost)
  app.get('/posts/list', controllers.posts.list)
  app.get('/posts/:id/:title', controllers.posts.postGet)
  app.get('/posts/like/post/:id', auth.isAuthenticated, controllers.posts.like)
  app.get('/posts/dislike/post/:id', auth.isAuthenticated, controllers.posts.dislike)

  app.get('/admins/add', auth.isInRole('Admin'), controllers.admins.addGet)
  app.post('/admins/add', auth.isInRole('Admin'), controllers.admins.addPost)
  app.get('/admins/all', auth.isInRole('Admin'), controllers.admins.all)
  app.get('/admins/delete/comment/:id', auth.isInRole('Admin'), controllers.admins.deleteComment)
  app.get('/admins/delete/post/:id', auth.isInRole('Admin'), controllers.admins.deletePost)
  app.get('/admins/edit/post/:id', auth.isInRole('Admin'), controllers.admins.editPostGet)
  app.post('/admins/edit/post/:id', auth.isInRole('Admin'), controllers.admins.editPostPost)

  app.all('*', (req, res) => {
    res.status(404)
    res.send('404 Not Found!')
    res.end()
  })
}
