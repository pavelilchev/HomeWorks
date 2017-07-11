import React from 'react'
import petStore from '../../stores/PetStore'

export default class PetDetailsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      pet: {
        name: '',
        age: '',
        type: '',
        image: '',
        breed: ''
      }
    }

    this.handlePetLoad = this.handlePetLoad.bind(this)
    petStore.on(
      petStore.events.PET_LOADED,
      this.handlePetLoad)
  }

  handlePetLoad (pet) {
    this.setState({pet})
  }

  componentWillUnmount () {
    petStore.removeListener(
      petStore.events.PET_LOADED,
      this.handlePetLoad)
  }

  componentDidMount () {
    let id = this.props.match.params.id
    petStore.getById(id)
  }

  render () {
    let pet = this.state.pet
    return (
      <div className='container'>
        <div className='row'>
          <div className='col-md-6'>
            <h3>{pet.name}</h3>
            <p>
              {pet.type}
            </p>
            <p>
              Age:
              {pet.age}
            </p>
            <p>
              Breed:
              {pet.breed || 'undefined'}
            </p>
            <img src={pet.image} alt={pet.type} className='img-responsive' />
          </div>
        </div>
      </div>
    )
  }
}
