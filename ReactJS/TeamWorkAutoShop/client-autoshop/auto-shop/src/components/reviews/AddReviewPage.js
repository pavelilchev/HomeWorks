import React from 'react'
import AddReviewForm from './AddReviewForm'
import reviewsActions from '../../actions/ReviewsActions'
import reviewsStore from '../../stores/ReviewsStore'
import toastr from 'toastr'

export default class AddReviewPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      review: {
        text: ''
      },
      error: []
    }

    this.handleReviewAdded = this.handleReviewAdded.bind(this)
    reviewsStore.on(
      reviewsStore.events.REVIEW_ADDED,
      this.handleReviewAdded)
  }

  componentWillUnmount () {
    reviewsStore.removeListener(
      reviewsStore.events.REVIEW_ADDED,
      this.handleReviewAdded)
  }

  handleReviewAdded (data) {
    if (!data.success) {
      let error = []
      error.push(data.message)
      this.setState({error})
    } else {
      toastr.success(data.message)
      this.props.history.push('/reviews/all')
    }
  }

  handleInputChange (event) {
    let target = event.target
    let value = target.value
    let field = target.name
    let review = this.state.review
    review[field] = value
    this.setState({review})
  }

  handleSubmit (event) {
    event.preventDefault()
    let review = this.state.review
    let error = []
    if (!review.text || review.text.trim().length === 0) {
      error.push('Review text cannot be empty')
    }

    if (error.length > 0) {
      this.setState({error})
      return
    }

    reviewsActions.create(this.state.review)
  }

  render () {
    return (
      <div className='container'>
        <h2>Please Leave a review</h2>
        <p>
          Thank you for writing a review. We value feedback from our customers.
          <br /> Your review will help us to improve our service and help others learn about our business.
        </p>
        <AddReviewForm
          review={this.state.review}
          error={this.state.error}
          onChange={this.handleInputChange.bind(this)}
          onSubmit={this.handleSubmit.bind(this)} />
      </div>
    )
  }
}
