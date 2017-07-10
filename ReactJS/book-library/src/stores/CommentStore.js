import { EventEmitter } from 'events'
import commentsActions from '../actions/CommentsActions'
import dispatcher from '../dispatcher'
import data from '../data/Data'

class CommentStore extends EventEmitter {
  getByBookId (bookId) {
    return new Promise((resolve, reject) => {
      data
        .getCommentsByBookId(bookId)
        .then(respone => {
          resolve(respone)
        })
    })
  }

  deleteById (id) {
    return new Promise((resolve, reject) => {
      data
        .deleteCommentById(id)
        .then(respone => {
          this.emit(this.events.COMMENT_DELETED)
        })
    })
  }

  add (comment, bookId) {
    return new Promise((resolve, reject) => {
      data
        .addComment(comment, bookId)
        .then(respone => {
          this.emit(this.events.COMMENT_ADDED, respone)
        })
    })
  }

  handleAction (action) {
    switch (action.type) {
      case commentsActions.types.DELETE_COMMENT:
        this.deleteById(action.id)
        break
      case commentsActions.types.ADD_COMMENT:
        this.add(action.comment, action.bookId)
        break
      default:
        break
    }
  }
}

let commentStore = new CommentStore()
commentStore.events = {
  COMMENT_DELETED: 'comment_deleted',
  COMMENT_ADDED: 'comment_added'
}

dispatcher.register(commentStore.handleAction.bind(commentStore))
export default commentStore
