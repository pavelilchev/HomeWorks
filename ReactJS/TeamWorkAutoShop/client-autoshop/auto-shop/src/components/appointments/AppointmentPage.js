import React from 'react'
import AppointmentForm from './AppointmentForm'
import appointmentActions from '../../actions/AppointmentActions'
import appointmentStore from '../../stores/AppointmentStore'
import toastr from 'toastr'

export default class AppointmentPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      appointment: {
        firstName: '',
        lastName: '',
        email: '',
        phone: '',
        reason: '',
        firstChoice: '',
        secondChoice: ''
      },
      errors: []
    }

    this.handleAppointmentAdded = this.handleAppointmentAdded.bind(this)
    appointmentStore.on(
      appointmentStore.events.APPOINTMENT_ADDED,
      this.handleAppointmentAdded)
  }

  componentWillUnmount () {
    appointmentStore.removeListener(
      appointmentStore.events.APPOINTMENT_ADDED,
      this.handleAppointmentAdded)
  }

  handleAppointmentAdded (data) {
    if (!data.success) {
      let errors = []
      if (data.errors.length > 0) {
        errors = data.errors
      } else {
        errors.push(data.message)
      }
      this.setState({errors})
    } else {
      toastr.success(data.message)
      this.props.history.push('/')
    }
  }

  handleInputChange (event) {
    let target = event.target
    let value = target.value
    let field = target.name
    let appointment = this.state.appointment
    appointment[field] = value
    this.setState({appointment})
  }

  handleSubmit (event) {
    event.preventDefault()

    let isValid = this.validateAppointmentForm()
    if (!isValid) {
      return
    }

    appointmentActions.create(this.state.appointment)
  }

  validateAppointmentForm () {
    let errors = []
    let appointment = this.state.appointment
    if (!appointment.firstName) {
      errors.push('Please enter your First name')
    }
    if (!appointment.lastName) {
      errors.push('Please enter your Last name')
    }
    if (!appointment.email) {
      errors.push('Please enter your Email')
    }
    let mailPattern = /(.+)@(.+){2,}\.(.+){2,}/
    if (!mailPattern.test(appointment.email)) {
      errors.push('Please provide valid email address')
    }
    if (!appointment.firstChoice || new Date(appointment.firstChoice) < Date.now()) {
      errors.push('Please select valid first date')
    }
    if (new Date(appointment.secondChoice) < Date.now()) {
      errors.push('Please select valid first date')
    }

    this.setState({errors})
    if (errors.length > 0) {
      return false
    }

    return true
  }

  render () {
    return (
      <div className='container'>
        <h2>Shedule an appointment</h2>
        <div className='row'>
          <div className='col-md-8'>
            <AppointmentForm
              errors={this.state.errors}
              onChange={this.handleInputChange.bind(this)}
              onSubmit={this.handleSubmit.bind(this)}
              appointment={this.state.appointment} />
          </div>
        </div>
      </div>
    )
  }
}
