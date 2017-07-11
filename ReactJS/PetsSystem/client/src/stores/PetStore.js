import { EventEmitter } from 'events'
import dispatcher from '../dispatcher'
import petActions from '../actions/PetActions'
import Data from '../data/Data'

class PetStore extends EventEmitter {
  create (pet) {
    Data
      .createPet(pet)
      .then(response => {
        this.emit(this.events.PET_CREATED, response)
      })
  }

  getAll (page) {
    Data
      .getAllPets(page)
      .then(response => {
        this.emit(this.events.PETS_LOADED, response)
      })
  }

  getById (id) {
    Data
      .getPetById(id)
      .then(response => {
        this.emit(this.events.PET_LOADED, response)
      })
  }

  handleAction (action) {
    switch (action.type) {
      case petActions.actionTypes.CREATE_PET:
        this.create(action.pet)
        break
      default:
        break
    }
  }
}

let petStore = new PetStore()
petStore.events = {
  PET_CREATED: 'pet_created',
  PETS_LOADED: 'pets_loaded',
  PET_LOADED: 'pet_loaded'
}

dispatcher.register(petStore.handleAction.bind(petStore))
export default petStore
