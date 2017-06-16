const Tweet = require('../data/Tweet')
const Tag = require('../data/Tag')
const errorHandler = require('../utilities/error-handler')
const MAX_TWEET_COUNT = 100

module.exports = {
  addGet: (req, res) => {
    res.render('tweets/add')
  },
  addPost: (req, res) => {
    let tweetReq = req.body

    let tags = getTags(tweetReq.tweet)
    let tagPromises = []
    for (let tag of tags) {
      tagPromises.push(getTagId(tag))
    }

    Promise.all(tagPromises)
      .then(dbTags => {
        let tweet = {
          tweet: tweetReq.tweet,
          author: req.user,
          createdOn: Date.now()
        }

        Tweet.create(tweet)
          .then(tweet => {
            for (let tag of dbTags) {
              tweet.tags.push(tag._id)
              tag.tweets.push(tweet._id)
              tag.save()
            }

            tweet.save()
              .then(t => {
                res.redirect('/')
              })
          })
          .catch(error => {
            res.locals.globalError = errorHandler.handleMongooseError(error)
            res.render('tweets/add', {tweet: tweetReq})
          })
      })
  },
  tagsGet: (req, res) => {
    let tagName = req.params.tagName
    Tag.findOne({ 'tag': tagName })
      .then(tag => {
        if (!tag) {
          res.sendStatus(404)
          return
        }

        Tweet.find({ tags: tag._id })
          .sort('-createdOn')
          .limit(MAX_TWEET_COUNT)
          .then(tweets => {
            res.render('tweets/tags', { tweets: tweets, tagName: tagName })
          })
      })
  }
}

function getTagId (tag) {
  tag = tag.toLowerCase()
  return new Promise((resolve, reject) => {
    Tag
      .findOne({ tag: tag })
      .then(t => {
        if (!t) {
          Tag.create({tag: tag})
            .then(createdTag => {
              resolve(createdTag)
            })
            .catch(error => {
              reject(error)
            })
        } else {
          resolve(t)
        }
      })
      .catch(error => {
        reject(error)
      })
  })
}

function getTags (text) {
  let words = text.split(/[ .,!?]+/)
  let tags = []
  for (let word of words) {
    if (word.lastIndexOf('#') === 0) {
      tags.push(word.substr(1))
    }
  }

  return tags
}
