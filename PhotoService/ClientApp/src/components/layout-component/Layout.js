import React, { Component } from 'react';
import { Container } from 'reactstrap';
import Footer from './footer-component/footer';
import Navbar from './navbar-component/navbar';

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
      <div>
        <Navbar />
        <Container>
          {this.props.children}
        </Container>
        <Footer/>
      </div>
    );
  }
}
