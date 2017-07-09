import React from 'react'
import appointmentActions from '../../actions/AppointmentActions'

export default class AppointmentPanel extends React.Component {
  handleConformation (event) {
    event.preventDefault()
    let id = this.props.appointment._id
    appointmentActions.confirm(id)
  }

  render () {
    let appointment = this.props.appointment
    let name = `Name: ${appointment.firstName} ${appointment.lastName}`
    let confirm = appointment.confirmed
      ? (<p className='msg msg-success'>
           Confirmed
         </p>)
      : (
      <div className='row'>
        <div className='col-xs-12 col-centered'>
          <button className='btn btn-primary' onClick={this.handleConformation.bind(this)}>
            Confirm
          </button>
        </div>
      </div>)
    return (
      <div className='single-appointment'>
        <div className='row'>
          <div className='col-sm-4'>
            {name}
          </div>
          <div className='col-sm-4'>
            Email:
            {appointment.email}
          </div>
          <div className='col-sm-4'>
            Phone:
            {appointment.phone}
          </div>
        </div>
        <div className='row'>
          <div className='col-sm-4'>
            Reason:
            {appointment.reason}
          </div>
          <div className='col-sm-4'>
            First Date:
            {new Date(appointment.firstChoice).toLocaleDateString()}
          </div>
          <div className='col-sm-4'>
            Second Date:
            {new Date(appointment.secondChoice).toLocaleDateString()}
          </div>
        </div>
        {confirm}
      </div>
    )
  }
}
