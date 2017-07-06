import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import authorsActions from '../actions/AuthorsActions'
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

  deleteById (id) {
    return new Promise((resolve, reject) => {
      data
        .deleteAuthorById(id)
        .then(respone => {
          this.emit(this.events.AUTHOR_DELETED)
        })
    })
  }

  handleAction (action) {
    switch (action.type) {
      case authorsActions.types.DELETE:
        this.deleteById(action.id)
        break
      default:
        break
    }
  }
}

let authorsStore = new AuthorsStore()
authorsStore.events = {
  AUTHOR_DELETED: 'author_deleted'
}

dispatcher.register(authorsStore.handleAction.bind(authorsStore))
export default authorsStore
