import React from 'react'
import adminStore from '../../stores/AdminStore'
import adminActions from '../../actions/AdminActions'
import appointmentStore from '../../stores/AppointmentStore'
import AppointmentSelect from './AppointmentSelect'
import AppoinmentsList from './AppoinmentsList'
import toastr from 'toastr'

export default class AdminPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      appointments: [],
      reviews: [],
      appointmentSelect: 'unconfirmed'
    }

    this.handleAppointmentsLoad = this.handleAppointmentsLoad.bind(this)
    appointmentStore.on(
      appointmentStore.events.APPOINTMENTS_LOADED,
      this.handleAppointmentsLoad)
  }

  handleAppointmentsLoad (data) {
    if (!data.success) {
      toastr.error(data.message)
    } else {
      let appointments = data.appointsments
      this.setState({appointments})
    }
  }

  componentWillUnmount () {
    appointmentStore.removeListener(
      appointmentStore.events.APPOINTMENTS_LOADED,
      this.handleAppointmentsLoad)
  }

  handleApointmentSelect (event) {
    let target = event.target
    let value = target.value
    this.setState({appointmentSelect: value})
  }

  handleApointmentSelectSubmit (event) {
    event.preventDefault()
    appointmentStore.getAll(this.state.appointmentSelect)
  }

  render () {
    return (
      <div className='container admin-page'>
        <h2>Control Panel</h2>
        <AppointmentSelect onChange={this.handleApointmentSelect.bind(this)} onSubmit={this.handleApointmentSelectSubmit.bind(this)} />
        <AppoinmentsList appointments={this.state.appointments} />
      </div>
    )
  }
}
