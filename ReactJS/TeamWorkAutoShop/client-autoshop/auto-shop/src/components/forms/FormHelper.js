class FormHelper {
  static handleInputChange (event, stateField) {
    let target = event.target
    let value = target.value
    if (target.type === 'checkbox') {
      value = event.target.checked
    }
    let field = target.name
    let state = this.state[stateField]
    state[field] = value
    this.setState({[stateField]: state})
  }
}

export default FormHelper
