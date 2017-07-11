import React from 'react'
import Input from '../forms/Input'
import Select from '../forms/Select'
import SubmitInput from '../forms/SubmitInput'
import Error from '../common/Error'

export default class AddPetForm extends React.Component {
  render () {
    let pet = this.props.pet
    return (
      <form className='form-horizontal' onSubmit={this.props.onSubmit}>
        <Input
          name='name'
          placeholder='Name'
          value={pet.name}
          onChange={this.props.onChange} />
        <Input
          type='number'
          name='age'
          placeholder='Age'
          value={pet.age}
          onChange={this.props.onChange} />
        <Select
          name='type'
          placeholder='Type'
          options={['Cat', 'Dog', 'Other']}
          onChange={this.props.onChange} />
        <Input
          type='url'
          name='image'
          placeholder='Image'
          value={pet.image}
          onChange={this.props.onChange} />
        <Input
          name='breed'
          placeholder='Breed'
          value={pet.brees}
          onChange={this.props.onChange} />
        <SubmitInput value='Save' />
        <Error error={this.props.errors} />
      </form>
    )
  }
}
