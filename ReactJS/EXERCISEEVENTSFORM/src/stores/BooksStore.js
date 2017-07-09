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
          this.emit(this.events.BOOK_DELETED)
        })
    })
  }

  add (book) {
    data
        .addBook(book)
        .then(respone => {
          this.emit(this.events.BOOK_ADDED, respone)
        })
  }

  handleAction (action) {
    switch (action.type) {
      case booksActions.actionTypes.DELETE:
        this.deleteById(action.id)
        break
      case booksActions.actionTypes.ADD:
        this.add(action.book)
        break
      default:
        break
    }
  }
}

let booksStore = new BooksStore()
booksStore.events = {
  BOOK_DELETED: 'book_deleted',
  BOOK_ADDED: 'book_added'
}

dispatcher.register(booksStore.handleAction.bind(booksStore))
export default booksStore
