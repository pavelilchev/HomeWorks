const Meme = require('../models/Meme')
const Tag = require('../models/Tag')

module.exports = {
  addGet: (req, res) => {
    res.render('meme/add')
  },
  addPost: (req, res) => {
    let memeReq = req.body

    let meme = {
      title: memeReq.title,
      image: '\\' + req.file.path
    }
    let tags = memeReq.tags.split(',').map(t => t.trim())
    Meme.create(meme).then((newMeme) => {
      let tagsPromises = []
      for (let tag of tags) {
        tagsPromises.push(getTagByName(tag))
      }

      Promise.all(tagsPromises).then(allTags => {
        for (let t of allTags) {
          newMeme.tags.push(t._id)
          t.memes.push(newMeme._id)
          t.save()
        }

        newMeme.save(() => {
          res.redirect(`/?success=${encodeURIComponent('Meme added!')}`)
        })
      })
    })
  },
  allGet: (req, res) => {
    Meme.find({}).populate('tags', 'name').then(function (memes) {
      let data = {}
      data.memes = memes
      data.counter = 0
      res.render('meme/all', data)
    })
  },
  byTagGet: (req, res) => {
    Tag.findById(req.params.tag).then(tag => {
      if(!tag){
        res.redirect('/?error=No such tag')
        return
      }

      Meme.find({tags: tag._id}).populate('tags').then(memes => {
        if(!memes){
           res.redirect(`/?success=${encodeURIComponent('No memes found!')}`)
           return
        }
        let data = {}
        data.memes = memes
        res.render('meme/hashtag', data)
      })
    })
  }
}

function getTagByName (tagName) {
  return new Promise((resolve, reject) => {
    Tag.findOne({name: tagName}).then(tag => {
      if (tag) {
        resolve(tag)
      }

      Tag.create({name: tagName}).then(newTag => {
        resolve(newTag)
      })
    })
  })
}
