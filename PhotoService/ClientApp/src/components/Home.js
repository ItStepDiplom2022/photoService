import React, { Component } from 'react';
import Gallery from './gallery-component/gallery';

export class Home extends Component {


  render() {
    return (
      <div>
        <Gallery images={this.props.images}/>
      </div>
    );
  }
}
