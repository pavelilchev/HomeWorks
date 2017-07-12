import React from 'react'
import reviewsActions from '../../actions/ReviewsActions'
import { Link } from 'react-router-dom'

export default class ReviewPanel extends React.Component {
  handleEdit (event) {
    event.preventDefault()
  }

  handleDelete (event) {
    event.preventDefault()
    reviewsActions.deleteById(this.props.review._id)
  }

  render () {
    let review = this.props.review
    return (
      <div className='col-md-4'>
        <div className='admin-single-review'>
          <div>
            Author:
            {review.author.username}
          </div>
          <div>
            {new Date(review.date).toLocaleDateString()}
          </div>
          <div>
            Rating:
            {review.rating}
          </div>
          <div>
            {review.text}
          </div>
          <div>
            <Link to={`/reviews/edit/${this.props.review._id}`} className='btn btn-primary'> Edit
            </Link>
            <button className='btn btn-danger' onClick={this.handleDelete.bind(this)}>
              Delete
            </button>
          </div>
        </div>
      </div>
    )
  }
}
