import React from 'react'
import AppointmentPanel from './AppointmentPanel'

export default class AppoinmentsList extends React.Component {
  render () {
    let appointments = this.props.appointments.map(a => {
      return <AppointmentPanel key={a._id} appointment={a} />
    })
    return (
      <div>
        {appointments}
      </div>
    )
  }
}
