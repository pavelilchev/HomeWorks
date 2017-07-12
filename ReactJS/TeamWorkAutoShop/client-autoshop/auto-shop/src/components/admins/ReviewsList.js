import React from 'react'
import ReviewPanel from './ReviewPanel'

export default class ReviewsList extends React.Component {
  render () {
    let reviews = this.props.reviews.map(review => {
      return <ReviewPanel key={review._id} review={review} />
    })

    return (
      <div className='row'>
        {reviews}
      </div>
    )
  }
}
