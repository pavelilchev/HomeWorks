const mongoose = require('mongoose')
const REQUIRED_VALIDATION_MESSAGE = '{PATH} is required'

let memeSchema = new mongoose.Schema({
  title: {type: mongoose.Schema.Types.String, required: REQUIRED_VALIDATION_MESSAGE},
  image: {type: mongoose.Schema.Types.String, required: REQUIRED_VALIDATION_MESSAGE},
  tags: [{type: mongoose.Schema.Types.ObjectId, ref: 'Tag'}]
})

let Meme = mongoose.model('Meme', memeSchema)

module.exports = Meme