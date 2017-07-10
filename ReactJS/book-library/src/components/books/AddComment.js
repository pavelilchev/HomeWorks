import React from 'react'
import Input from '../common/forms/Input'
import SubmitInput from '../common/forms/SubmitInput'

export default class AddComment extends React.Component {
  render () {
    let comment = this.props.comment
    return (
      <form className='form-horizontal' onSubmit={this.props.onSubmit}>
        <Input
          name='text'
          placeholder='Comment'
          value={comment.text}
          onChange={this.props.onChange} />
        <SubmitInput
          value='Add Comment' />
      </form>
    )
  }
}
