import React from 'react'

export default class Review extends React.Component {
  render () {
    let review = this.props.review
    return (
      <div className='single-review row'>
        <div className='col-sm-3 left-review'>
          <div>
            {review.author.username}
          </div>
          <div>
            {new Date(review.date).toLocaleDateString()}
          </div>
        </div>
        <div className='col-sm-9 right-review'>
          {review.text}
        </div>
      </div>
    )
  }
}
