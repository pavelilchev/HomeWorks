import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import data from '../data/Data'

class CommentStore extends EventEmitter {
  getByBookId (id) {
    return new Promise((resolve, reject) => {
      data
        .getCommentsByBookId(id)
        .then(respone => {
          resolve(respone)
        })
    })
  }

  handleAction (action) {
    switch (action.type) {
      default:
        break
    }
  }
}

let commentStore = new CommentStore()
commentStore.events = {
  ALL: 'all'
}

dispatcher.register(commentStore.handleAction.bind(commentStore))
export default commentStore
