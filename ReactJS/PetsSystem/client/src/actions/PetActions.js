import dispatcher from '../dispatcher.js'

let petActions = {
  actionTypes: {
    CREATE_PET: 'CREATE_PET'
  },
  create: (pet) => {
    dispatcher.dispatch({
      type: petActions.actionTypes.CREATE_PET,
      pet: pet
    })
  }
}

export default petActions
