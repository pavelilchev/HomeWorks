import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import booksActions from '../actions/BooksActions'
import data from '../data/Data'

class BooksStore extends EventEmitter {
  getAll () {
    return new Promise((resolve, reject) => {
      data
        .allBooks()
        .then(respone => {
          resolve(respone)
        })
    })
  }

  getById (id) {
    return new Promise((resolve, reject) => {
      data
        .getBookById(id)
        .then(respone => {
          resolve(respone)
        })
    })
  }

  getByAuthorName (authorName) {
    return new Promise((resolve, reject) => {
      data
        .getBooksByAuthorName(authorName)
        .then(respone => {
          resolve(respone)
        })
    })
  }

  deleteById (id) {
    return new Promise((resolve, reject) => {
      data
        .deleteBookById(id)
        .then(respone => {
          this.emit('book_deleted')
        })
    })
  }

  handleAction (action) {
    switch (action.type) {
      case booksActions.actionTypes.DELETE:
        this.deleteById(action.id)
        break
      default:
        break
    }
  }
}

let booksStore = new BooksStore()
booksStore.events = {
  BOOK_DELETED: 'book_deleted'
}

dispatcher.register(booksStore.handleAction.bind(booksStore))
export default booksStore
