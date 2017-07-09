import React from 'react'
import SubmitInput from '../forms/SubmitInput'
import Error from '../common/Error'

export default class AddReviewForm extends React.Component {
  render () {
    let review = this.props.review
    return (
      <div className='row'>
        <div className='col-md-12 col-centered'>
          <form className='form-horizontal' onSubmit={this.props.onSubmit}>
            <textarea
              cols='60'
              rows='4'
              name='text'
              placeholder='Text'
              value={review.text}
              onChange={this.props.onChange} />
            <SubmitInput value='Add review' />
            <Error error={this.props.error} />
          </form>
        </div>
      </div>
    )
  }
}
