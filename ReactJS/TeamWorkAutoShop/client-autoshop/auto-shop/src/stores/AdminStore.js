import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import adminActions from '../actions/AdminActions'
import Data from '../data/Data'

class AdminStore extends EventEmitter {
  login (user) {
    Data
      .loginUser(user)
      .then(respone => {
        this.emit(this.events.LOGGEDIN, respone)
      })
  }

  handleAction (action) {
    switch (action.type) {
      case adminActions.actionTypes.LOGIN:
        this.login(action.user)
        break
      default:
        break
    }
  }
}

let adminStore = new AdminStore()
adminStore.events = {
  SOME: 'some'
}

dispatcher.register(adminStore.handleAction.bind(adminStore))
export default adminStore
