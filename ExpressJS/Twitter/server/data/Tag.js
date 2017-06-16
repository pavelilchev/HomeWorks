const mongoose = require('mongoose')
const Types = mongoose.Schema.Types
const VALIDATION_MESSAGE_REQUIRED = '{PATH} is required!'

let tagSchema = new mongoose.Schema({
  tag: { type: Types.String, required: VALIDATION_MESSAGE_REQUIRED, unique: true },
  tweets: [{ type: Types.ObjectId, ref: 'Tweet' }]
})

let Tag = mongoose.model('Tag', tagSchema)

module.exports = Tag
