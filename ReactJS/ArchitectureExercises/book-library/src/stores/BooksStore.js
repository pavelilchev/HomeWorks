import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'

import Data from '../database/Data'

class BooksStore extends EventEmitter {
  constructor () {
    super()

    this.books = []
    this.getAll()
  }

  createTodo (title) {
    const id = this.todos.length + 1
    this.todos.push({
      id,
      title,
      completed: false
    })

    this.emit('change')
  }

  getAll () {
    return new Promise((resolve, reject) => {
      Data.allBooks()
        .then(books => {
          this.books = books
          resolve(books)
        })
        .catch(err => {
          reject(err)
        })
    })
  }

  handleAction (action) {
    switch (action.type) {
      case 'GET_ALL':
        this.getAll()
        break
      default:
        break
    }
  }
}

let booksStore = new BooksStore()

dispatcher.register(booksStore.handleAction.bind(booksStore))

export default booksStore
