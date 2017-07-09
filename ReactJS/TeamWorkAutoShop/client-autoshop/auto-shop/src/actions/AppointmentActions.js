import dispatcher from '../dispatcher.js'

let appointmentActions = {
  actionTypes: {
    CREATE: 'CREATE_APPOINTMENT'
  },
  create: (appointment) => {
    dispatcher.dispatch({
      type: appointmentActions.actionTypes.CREATE_APPOINTMENT,
      appointment: appointment
    })
  }
}

export default appointmentActions
