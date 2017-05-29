const Tag = require('./models/tag.js')
const Image = require('./models/image.js')
const database = require('./config/database.config')

function getAllTags () {
  return Tag.find()
}

let saveImage = function (data) {
  getAllTags().then((tags) => {
    let imgTags = []
    let imgTagsId = []
    let promises = []
    for (let tag of data.tags) {
      var currentTag = null
      for (let existingTag of tags) {
        if (existingTag.name === tag) {
          currentTag = existingTag
          break
        }
      }

      if (!currentTag) {
        let p = saveTag({name: tag})
        promises.push(p)
      } else {
        imgTagsId.push(currentTag._id)
        imgTags.push(currentTag)
      }
    }

    Promise.all(promises)
      .then((savedTags) => {
        for (let tag of savedTags) {
          imgTagsId.push(tag._id)
          imgTags.push(tag)
        }

        data.tags = imgTags
        let newImage = new Image(data)
        newImage.save((err, savedImage) => {
          for (let tag of imgTags) {
            if (!tag.images.includes(savedImage._id)) {
              tag.images.push(savedImage._id)
              tag.save()
            }
          }
        })
      })
      .catch((error) => {
        console.log(error)
      })
  })
}

let saveTag = function (data) {
  let tag = new Tag(data)
  return new Promise((resolve, reject) => {
    tag.save((err, savedTag) => {
      if (err) {
        reject(err)
      }

      resolve(savedTag)
    })
  })
}

let findByTag = (searched) => {
  return new Promise((resolve, reject) => {
    Image
      .find({})
      .populate({
        path: 'tags',
        match: { tagName: searched}
      })
      .sort({ creationDate: -1 })
      .exec((err, imgs) => {
        if (err) {
          reject(err)
        }

        resolve(imgs)
      })
  })
}

let filter = (data) => {
  let after = data.after
  let before = data.before
  let limit = data.results || 10

  return new Promise((resolve, reject) => {
    Image
      .find({ 
        creatianDate : { $gte: after, $lte: before }
      })
      .limit(limit)
      .exec((err, imgs) => {
        if (err) {
          reject(err)
        }

        resolve(imgs)
      })
  })
}

module.exports = {
  saveImage: saveImage,
  saveTag: saveTag,
  findByTag: findByTag,
  filter: filter
}
