import React from 'react'
import appointmentStore from '../../stores/AppointmentStore'
import reviewsStore from '../../stores/ReviewsStore'

import AppointmentSelect from './AppointmentSelect'
import AppoinmentsList from './AppoinmentsList'
import ReviewsSelect from './ReviewsSelect'
import ReviewsList from './ReviewsList'
import toastr from 'toastr'

export default class AdminPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      appointments: [],
      reviews: [],
      appointmentSelect: 'unconfirmed',
      reviewsSelect: 'all'
    }

    this.handleAppointmentsLoad = this.handleAppointmentsLoad.bind(this)
    this.loadAppointsment = this.loadAppointsment.bind(this)
    this.handleReviewsLoaded = this.handleReviewsLoaded.bind(this)
    this.handleReviewsDeleted = this.handleReviewsDeleted.bind(this)

    appointmentStore.on(
      appointmentStore.events.APPOINTMENTS_LOADED,
      this.handleAppointmentsLoad)

    appointmentStore.on(
      appointmentStore.events.APPOINTMENT_CONFIRMED,
      this.loadAppointsment
    )

    reviewsStore.on(
      reviewsStore.events.SELECTED_REVIEWS_LOADED,
      this.handleReviewsLoaded)

    reviewsStore.on(
      reviewsStore.events.REVIEW_DELETED,
      this.handleReviewsDeleted
    )
  }

  loadAppointsment () {
    appointmentStore.getAll(this.state.appointmentSelect)
  }

  loadReviews () {
    reviewsStore.getAll(this.state.reviewsSelect)
  }

  handleReviewsLoaded (data) {
    if (!data.success) {
      toastr.error(data.message)
    } else {
      let reviews = data.reviews
      let appointments = []
      this.setState({reviews, appointments})
    }
  }

  handleAppointmentsLoad (data) {
    if (!data.success) {
      toastr.error(data.message)
    } else {
      let reviews = []
      let appointments = data.appointsments
      this.setState({appointments, reviews})
    }
  }

  handleReviewsDeleted (data) {
    if (!data.success) {
      toastr.error(data.message)
    } else {
      toastr.success(data.message)
      this.loadReviews()
    }
  }

  componentWillUnmount () {
    appointmentStore.removeListener(
      appointmentStore.events.APPOINTMENTS_LOADED,
      this.handleAppointmentsLoad)

    appointmentStore.removeListener(
      appointmentStore.events.APPOINTMENT_CONFIRMED,
      this.loadAppointsment
    )

    reviewsStore.removeListener(
      reviewsStore.events.SELECTED_REVIEWS_LOADED,
      this.handleReviewsLoaded)

    reviewsStore.removeListener(
      reviewsStore.events.REVIEW_DELETED,
      this.handleReviewsDeleted
    )
  }

  handleApointmentSelect (event) {
    let target = event.target
    let value = target.value
    this.setState({appointmentSelect: value})
  }

  handleApointmentSelectSubmit (event) {
    event.preventDefault()
    this.loadAppointsment()
  }

  handleReviewsSelectSubmit (event) {
    event.preventDefault()
    this.loadReviews()
  }

  handleReviewsSelect (event) {
    let target = event.target
    let value = target.value
    this.setState({reviewsSelect: value})
  }

  render () {
    return (
      <div className='container admin-page'>
        <h2>Control Panel</h2>
        <AppointmentSelect onChange={this.handleApointmentSelect.bind(this)} onSubmit={this.handleApointmentSelectSubmit.bind(this)} />
        <ReviewsSelect onChange={this.handleReviewsSelect.bind(this)} onSubmit={this.handleReviewsSelectSubmit.bind(this)} />
        <AppoinmentsList appointments={this.state.appointments} />
        <ReviewsList reviews={this.state.reviews} />
      </div>
    )
  }
}
