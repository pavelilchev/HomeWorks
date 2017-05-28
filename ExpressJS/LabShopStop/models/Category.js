const mongoose = require('mongoose')

let categoryShema = new mongoose.Schema({
    name: { type: mongoose.Schema.Types.String, required: true, unique: true },
    products: [ { type: mongoose.Schema.Types.ObjectId, ref: 'Product' } ]
})

let Category = mongoose.model('Category', categoryShema)

module.exports = Category