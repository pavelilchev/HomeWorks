import React from 'react'

export default class HomeReview extends React.Component {
  render () {
    let review = this.props.review
    return (
      <div className='home-reviews'>
        <div className='container'>
          <div className='col-md-8 col-md-offset-2 quotes'>
            <h2>What our clients says</h2>
            <h4><i>from {review.author.username}</i></h4>
            <p>
              {review.text}
            </p>
          </div>
        </div>
      </div>
    )
  }
}
