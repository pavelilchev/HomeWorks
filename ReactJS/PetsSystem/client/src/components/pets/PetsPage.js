import React from 'react'
import petStore from '../../stores/PetStore'
import PetsList from './PetsList'

export default class PetsPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      pets: [],
      page: 1
    }

    this.handlePetsLoad = this.handlePetsLoad.bind(this)
    petStore.on(
      petStore.events.PETS_LOADED,
      this.handlePetsLoad)
  }

  componentWillUnmount () {
    petStore.removeListener(
      petStore.events.PETS_LOADED,
      this.handlePetsLoad)
  }

  handlePetsLoad (pets) {
    this.setState({pets})
  }

  componentDidMount () {
    this.loadPets(this.state.page)
  }

  loadPets (page) {
    petStore.getAll(page)
  }

  handlePagination (event) {
    event.preventDefault()

    let target = event.target
    let value = target.value
    let page = this.state.page
    if (value === 'Prev') {
      page = page - 1
    } else {
      page = page + 1
    }

    this.setState({page})
    this.loadPets(page)
  }

  render () {
    return (
      <div className='container'>
        <PetsList pets={this.state.pets} />
        <button onClick={this.handlePagination.bind(this)} value='Prev' className='pagination'>
          Prev
        </button>
        <button onClick={this.handlePagination.bind(this)} value='Next' className='pagination'>
          Next
        </button>
      </div>
    )
  }
}
