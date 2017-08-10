import React from 'react'
import ReviewEditForm from './ReviewEditForm'
import reviewsActions from '../../actions/ReviewsActions'
import reviewsStore from '../../stores/ReviewsStore'
import FormHelper from '../forms/FormHelper'
import toast from 'toastr'

export default class ReviewEditPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      review: {
        text: '',
        rating: '',
        published: '',
        author: {
          firstName: '',
          lastName: ''
        }
      },
      errors: []
    }

    this.handleReviewLoad = this.handleReviewLoad.bind(this)
    this.handleReviewEdited = this.handleReviewEdited.bind(this)
    reviewsStore.on(
      reviewsStore.events.REVIEW_LOADED,
      this.handleReviewLoad)

    reviewsStore.on(
      reviewsStore.events.REVIEW_EDITED,
      this.handleReviewEdited)
  }

  handleReviewLoad (data) {
    if (!data.success) {
      toast.error(data.message)
    } else {
      let review = data.review
      this.setState({review})
    }
  }

  handleReviewEdited (data) {
    if (!data.success) {
      toast.error(data.message)
    } else {
      toast.success(data.message)
      let review = data.review
      this.setState({review})
    }
  }

  componentDidMount () {
    let id = this.props.match.params.id
    reviewsActions.getById(id)
  }

  componentWillUnmount () {
    reviewsStore.removeListener(
      reviewsStore.events.REVIEW_LOADED,
      this.handleReviewLoad)

    reviewsStore.removeListener(
      reviewsStore.events.REVIEW_EDITED,
      this.handleReviewEdited)
  }

  handleInputChange (event) {
    FormHelper.handleInputChange.bind(this)(event, 'review')
  }

  handleReviewSave (event) {
    event.preventDefault()
    let review = this.state.review
    reviewsActions.editReview(review)
  }

  render () {
    return (
      <div className='container'>
        <h2>Edit review</h2>
        <ReviewEditForm
          review={this.state.review}
          errors={this.state.errors}
          onChange={this.handleInputChange.bind(this)}
          onSubmit={this.handleReviewSave.bind(this)} />
      </div>
    )
  }
}
