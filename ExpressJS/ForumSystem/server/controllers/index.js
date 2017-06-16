const home = require('./home-controller')
const users = require('./users-controller')
const posts = require('./posts-controller')
const comments = require('./comments-controller')
const admins = require('./admins-controller')

module.exports = {
  home: home,
  users: users,
  posts: posts,
  comments: comments,
  admins: admins
}
