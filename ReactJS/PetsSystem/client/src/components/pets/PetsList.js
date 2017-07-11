import React from 'react'
import PetPanel from './PetPanel'

export default class PetsList extends React.Component {
  render () {
    let pets = this.props.pets.map(p => {
      return (
        <PetPanel key={p.id} pet={p} />
      )
    })

    return (
      <div className='row'>
        {pets}
      </div>
    )
  }
}
