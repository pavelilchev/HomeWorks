const controllers = require('../controllers')
const auth = require('./auth')
const multer = require('multer')
let upload = multer({dest: './public/memes'})

module.exports = (app) => {
  app.get('/', controllers.home.index)

  app.get('/user/register', controllers.user.registerGet)
  app.post('/user/register', controllers.user.registerPost)
  app.get('/user/login', controllers.user.loginGet)
  app.post('/user/login', controllers.user.loginPost)
  app.get('/user/logout',auth.isAuthenticated,  controllers.user.logout)

  app.get('/meme/add', auth.isAuthenticated, controllers.meme.addGet)
  app.post('/meme/add', auth.isAuthenticated, upload.single('image'), controllers.meme.addPost)
  app.get('/meme/all',  controllers.meme.allGet)
  app.get('/meme/hashtag/:tag',  controllers.meme.byTagGet)
  app.get('/meme/cp', auth.isInRole('Admin'), controllers.meme.cpGet)
  app.get('/meme/remove/:id', auth.isInRole('Admin'), controllers.meme.removeGet)
  app.post('/meme/remove/:id', auth.isInRole('Admin'), controllers.meme.removePost)

  app.all('*', (req, res) => {
    res.status(404)
    res.send('404 Not Found!')
    res.end()
  })
}
