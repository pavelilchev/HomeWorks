const Tweet = require('../data/Tweet')
const MAX_TWEET_COUNT = 100

module.exports = {
  index: (req, res) => {
    Tweet
      .find()
      .populate('tags author')
      .sort('-createdOn')
      .limit(MAX_TWEET_COUNT)
      .then(tweets => {
        res.render('home/index', {tweets: tweets})
      })
      .catch(error => {
        console.log(error)
      })
  }
}
