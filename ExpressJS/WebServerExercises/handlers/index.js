const homeHandler = require('./home')
const staticHandler = require('./static-files')
const productsHandler = require('./images')
const headerHandler = require('./header')

module.exports =    handlers = [homeHandler, staticHandler, productsHandler,headerHandler]