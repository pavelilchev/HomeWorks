class FormHelper {
  static handleInputChange (event, stateField) {
    let target = event.target
    let value = target.value
    let field = target.name
    let state = this.state[stateField]
    state[field] = value
    this.setState({[stateField]: state})
  }
}

export default FormHelper
