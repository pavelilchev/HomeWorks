import React from 'react'

export default class HomeReview extends React.Component {
  render () {
    let review = this.props.review
    return (
      review.text.length === 0
      ? null
      : (
        <div className='home-reviews'>
          <div className='container'>
            <div className='col-md-8 col-md-offset-2 quotes'>
              <h2>What our clients says</h2>
              <h4><i>from</i> <b>{review.author.firstName} {review.author.lastName}</b></h4>
              <p>
                {review.text}
              </p>
              <div className={`home-review-rating review-rating-${review.rating}`} />
            </div>
          </div>
        </div>)
    )
  }
}
