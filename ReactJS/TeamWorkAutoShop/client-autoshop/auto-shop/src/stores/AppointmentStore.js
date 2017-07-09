import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import Data from '../data/Data'
import appointmentActions from '../actions/AppointmentActions'

class AppointmentStore extends EventEmitter {
  create (appointment) {
    Data
      .addAppointment(appointment)
      .then(response => {
        this.emit(this.events.APPOINTMENT_ADDED, response)
      })
  }

  getAll (option) {
    Data
      .getAllAppointments(option)
      .then(response => {
        this.emit(this.events.APPOINTMENTS_LOADED, response)
      })
  }

  confirm (id) {
    Data
      .confirmAppointment(id)
      .then(response => {
        this.emit(this.events.APPOINTMENT_CONFIRMED, response)
      })
  }

  handleAction (action) {
    switch (action.type) {
      case appointmentActions.actionTypes.APPOINTMENT_ADDED:
        this.create(action.appointment)
        break
      case appointmentActions.actionTypes.CONFIRM_APPOINTMENT:
        this.confirm(action.id)
        break
      default:
        break
    }
  }
}

let appointmentStore = new AppointmentStore()
appointmentStore.events = {
  APPOINTMENT_ADDED: 'appointment_added',
  APPOINTMENTS_LOADED: 'appointments_loaded',
  APPOINTMENT_CONFIRMED: 'aapointmen_confirmed'
}

dispatcher.register(appointmentStore.handleAction.bind(appointmentStore))
export default appointmentStore
