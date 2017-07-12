import React from 'react'
import Review from './Review'

export default class ReviewsList extends React.Component {
  render () {
    let reviews = this.props.reviews.map(r => {
      return <Review key={r._id} review={r} />
    })

    if (reviews.length === 0) {
      reviews = <h2>No reviews at this time</h2>
    }

    return (
      <div className='container'>
        {reviews}
      </div>
    )
  }
}
