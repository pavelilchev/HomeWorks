const mongoose = require('mongoose')

const REQUIRED_VALIDATION_MESSAGE = '{PATH} is required'
const REVIEW_MINLEN_MESSAGE = [4, 'The `{PATH}` should be at least ({MINLENGTH}) characters.']

let reviewSchema = new mongoose.Schema({
  text: { type: String, required: REQUIRED_VALIDATION_MESSAGE, minlength: REVIEW_MINLEN_MESSAGE },
  author: {type: mongoose.Schema.Types.ObjectId, ref: 'User'},
  rating: {type: Number, required: REQUIRED_VALIDATION_MESSAGE, min: 1, max: 5},
  date: {type: mongoose.Schema.Types.Date, default: Date.now()},
  published: { type: Boolean, default: true }
})

let Review = mongoose.model('Review', reviewSchema)

module.exports = Review
