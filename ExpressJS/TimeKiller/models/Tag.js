const mongoose = require('mongoose')
const REQUIRED_VALIDATION_MESSAGE = '{PATH} is required'

let tagShema = new mongoose.Schema({
  name: {type: mongoose.Schema.Types.String, required: REQUIRED_VALIDATION_MESSAGE, unique: true},
  memes: [{type: mongoose.Schema.Types.ObjectId, ref: 'Meme'}]
})

let Tag = mongoose.model('Tag', tagShema)

module.exports = Tag