const mongoose = require('mongoose')
const Types = mongoose.Schema.Types
const VALIDATION_MESSAGE_REQUIRED = '{PATH} is required!'
const TWEET_MAXLEN_MESSAGE = [140, 'The `{PATH}` (`{VALUE}`) exceeds the maximum allowed length ({MAXLENGTH}).']

let tweetSchema = new mongoose.Schema({
  tweet: { type: Types.String, required: VALIDATION_MESSAGE_REQUIRED, maxlength: TWEET_MAXLEN_MESSAGE },
  author: { type: Types.ObjectId, ref: 'User' },
  createdOn: { type: Types.Date, default: Date.now() },
  tags: [{ type: Types.ObjectId, ref: 'Tag' }]
})

let Tweet = mongoose.model('Tweet', tweetSchema)

module.exports = Tweet
