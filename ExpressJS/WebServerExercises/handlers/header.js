const url = require('url')
const fs = require('fs')
const path = require('path')
const database = require('../config/database')
const qs = require('querystring')

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname
    if(req.pathname === '/' && req.method === 'GET'){
        let filePath = path.normalize(
            path.join(__dirname, '../views/home/index.html'))
    
    } else {
        return true
    }
}