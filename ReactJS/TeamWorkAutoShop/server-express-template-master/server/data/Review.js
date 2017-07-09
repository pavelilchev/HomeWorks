const mongoose = require('mongoose')

const REQUIRED_VALIDATION_MESSAGE = '{PATH} is required'
const REVIEW_MINLEN_MESSAGE = [4, 'The `{PATH}` should be at least ({MINLENGTH}) characters.']

let reviewSchema = new mongoose.Schema({
  text: { type: String, required: REQUIRED_VALIDATION_MESSAGE, minlength: REVIEW_MINLEN_MESSAGE },
  author: {type: mongoose.Schema.Types.ObjectId, ref: 'User'},
  date: {type: mongoose.Schema.Types.Date, default: Date.now()}
})

let Review = mongoose.model('Review', reviewSchema)

module.exports = Review
