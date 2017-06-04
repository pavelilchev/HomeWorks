const mongoose = require('mongoose')

let productShema = new mongoose.Schema({
  name: { type: mongoose.Schema.Types.String, require: true },
  description: { type: mongoose.Schema.Types.String },
  price: {
    type: mongoose.Schema.Types.Number,
    min: 0,
    max: Number.MAX_VALUE,
    default: 0
  },
  image: { type: mongoose.Schema.Types.String },
  creator: {type: mongoose.Schema.Types.ObjectId, ref: 'User', required: true},
  buyer: {type: mongoose.Schema.Types.ObjectId, ref: 'User'},
  category: { type: mongoose.Schema.Types.ObjectId, ref: 'Category', required:true }
})

let Product = mongoose.model('Product', productShema)

module.exports = Product
