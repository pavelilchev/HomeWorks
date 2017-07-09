import React from 'react'

export default class Marker extends React.Component {
  render () {
    return (
      <div className='marker'>
        {this.props.text}
      </div>
    )
  }
}
