import React from 'react'

export default class AppointmentPanel extends React.Component {
  render () {
    let appointment = this.props.appointment
    let name = `Name: ${appointment.firstName} ${appointment.lastName}`
    let confirm = appointment.isConfirmed
      ? null
      : (
      <div className='row'>
        <div className='col-sm-4'>
          <button className='btn btn-primary'>
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
