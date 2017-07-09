import dispatcher from '../dispatcher.js'

let appointmentActions = {
  actionTypes: {
    CREATE: 'CREATE_APPOINTMENT',
    CONFIRM_APPOINTMENT: 'CONFIRM_APPOINTMENT'
  },
  create: (appointment) => {
    dispatcher.dispatch({
      type: appointmentActions.actionTypes.CREATE_APPOINTMENT,
      appointment: appointment
    })
  },
  confirm: (id) => {
    dispatcher.dispatch({
      type: appointmentActions.actionTypes.CONFIRM_APPOINTMENT,
      id: id
    })
  }
}

export default appointmentActions
