const mongoose = require('mongoose')
const Schema = mongoose.Schema

let imageShema = new Schema({
  url: { type: Schema.Types.String, required:true },
  creationDate: { type: Schema.Types.Date, default: Date.now },
  description: { type: Schema.Types.String, required:true },
  tags: [{ type: Schema.Types.ObjectId, ref: 'Tag' }]
});

let Image = mongoose.model('Image', imageShema)

module.exports = Image
