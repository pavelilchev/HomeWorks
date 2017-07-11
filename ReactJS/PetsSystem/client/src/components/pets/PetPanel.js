import React from 'react'
import { Link } from 'react-router-dom'

export default class PetPanel extends React.Component {
  render () {
    let pet = this.props.pet
    return (
      <div className='col-md-4'>
        <h3>{pet.name}</h3>
        <p>
          <i>{pet.type}</i>
        </p>
        <Link to={`/pets/details/${pet.id}`} className='btn btn-primary'> Details
        </Link>
      </div>
    )
  }
}
