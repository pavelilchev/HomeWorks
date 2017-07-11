import React from 'react'
import AddPetForm from './AddPetForm'
import FormHelper from '../forms/FormHelper'
import petActions from '../../actions/PetActions'
import petStore from '../../stores/PetStore'
import ErrorHelper from '../../utils/ErrorHelper'
import toastr from 'toastr'

export default class AddPetPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      pet: {
        name: '',
        age: '',
        type: '',
        image: '',
        breed: ''
      },
      errors: []
    }

    this.handlePetCreated = this.handlePetCreated.bind(this)
    petStore.on(
      petStore.events.PET_CREATED,
      this.handlePetCreated)
  }

  handlePetCreated (data) {
    if (!data.success) {
      let errors = ErrorHelper.parse(data.errors)
      this.setState({errors})
      return
    }

    toastr.success(data.message)
    this.props.history.push('/')
  }

  componentWillUnmount () {
    petStore.removeListener(
      petStore.events.PET_CREATED,
      this.handlePetCreated)
  }

  handleSubmit (event) {
    event.preventDefault()
    let isValid = this.validateAddPetForm()
    if (!isValid) {
      return
    }

    petActions.create(this.state.pet)
  }

  handleInputChange (event) {
    FormHelper.handleInputChange.bind(this)(event, 'pet')
  }

  validateAddPetForm () {
    let pet = this.state.pet
    let errors = []
    let isValid = true
    if (typeof pet.name !== 'string' || pet.name.length < 3) {
      errors.push('Name must be more than 3 symbols.')
    }

    if (typeof pet.image !== 'string' || pet.image.length === 0) {
      errors.push('Image URL is required.')
    }

    if (!pet.age || pet.age < 0) {
      errors.push('Age must be a positive number.')
    }

    if (typeof pet.type !== 'string' || (pet.type !== 'Cat' && pet.type !== 'Dog' && pet.type !== 'Other')) {
      errors.push('Type must be Cat, Dog or Other.')
    }

    if (errors.length > 0) {
      this.setState({errors})
      isValid = false
    }

    return isValid
  }

  render () {
    return (
      <div className='container'>
        <div className='row'>
          <div className='col-md-6'>
            <h2>Add new Pet</h2>
            <AddPetForm
              errors={this.state.errors}
              pet={this.state.pet}
              onChange={this.handleInputChange.bind(this)}
              onSubmit={this.handleSubmit.bind(this)} />
          </div>
        </div>
      </div>
    )
  }
}
