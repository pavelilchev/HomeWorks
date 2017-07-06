import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import booksActions from '../actions/BooksActions'
import data from '../data/Data'

class AuthorsStore extends EventEmitter {
  getAll () {
    return new Promise((resolve, reject) => {
      data
        .allAuthors()
        .then(respone => {
          resolve(respone)
        })
    })
  }

  getById (id) {
    return new Promise((resolve, reject) => {
      data
        .getAuthorById(id)
        .then(respone => {
          resolve(respone)
        })
    })
  }

  handleAction (action) {
    switch (action.type) {
      case booksActions.actionTypes.GET_ALL:
        this.getAll()
        break
      default:
        break
    }
  }
}

let authorsStore = new AuthorsStore()
authorsStore.events = {
  ALL: 'all'
}

dispatcher.register(authorsStore.handleAction.bind(authorsStore))
export default authorsStore
