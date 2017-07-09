import React from 'react'
import Input from '../common/forms/Input'
import SubmitInput from '../common/forms/SubmitInput'
import Error from '../common/Error'

export default class BookForm extends React.Component {
  render () {
    let book = this.props.book

    return (
      <form className='form-horizontal' onSubmit={this.props.onSubmit}>
        <Input
          name='title'
          placeholder='Title'
          value={book.title}
          onChange={this.props.onChange} />
        <Input
          name='author'
          placeholder='Author'
          value={book.author}
          onChange={this.props.onChange} />
        <Input
          type='date'
          name='date'
          placeholder='Date'
          value={book.date}
          onChange={this.props.onChange} />
        <Input
          type='url'
          name='img'
          placeholder='Image'
          value={book.img}
          onChange={this.props.onChange} />
        <Input
          name='description'
          placeholder='Description'
          value={book.description}
          onChange={this.props.onChange} />
        <Input
          type='number'
          name='price'
          placeholder='Price'
          value={book.price}
          onChange={this.props.onChange} />
        <SubmitInput
          value='Submit' />
        <Error error={this.props.errors} />
      </form>
    )
  }
}
