const mongoose = require('mongoose')

let categoryShema = new mongoose.Schema({
    name: { type: mongoose.Schema.Types.String, required: true, unique: true },
    creator: {type: mongoose.Schema.Types.ObjectId, ref: 'User', required:true},
    products: [ { type: mongoose.Schema.Types.ObjectId, ref: 'Product' } ]
})

let Category = mongoose.model('Category', categoryShema)

module.exports = Category