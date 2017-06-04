const Meme = require('../models/Meme')

module.exports = {
  index: (req, res) => {
    let queryData = req.query
    let data = {}
    Meme.find({}).populate('tags', 'name').limit(3).then(function(memes) {
        data.memes = memes
        if (req.query.error) {
          data.error = req.query.error
        } else if (req.query.success) {
          data.success = req.query.success
        }

        res.render('home/index', data)
      })
  }
}
