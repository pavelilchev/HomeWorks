const mongoose = require('mongoose')
const Schema = mongoose.Schema

let tagShema = new Schema({
  name: { type: Schema.Types.String, required:true, unique:true },
  creationDate: { type: Schema.Types.Date, default: Date.now },
  images: [{ type: Schema.Types.ObjectId, ref: 'Image' }]
});

let Tag = mongoose.model('Tag', tagShema)

module.exports = Tag