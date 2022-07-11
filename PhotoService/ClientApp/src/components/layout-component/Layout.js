import React from 'react';
import { Container } from 'reactstrap';
import Footer from './footer-component/footer';
import Navbar from './navbar-component/navbar';

export default function Layout (props) {

    return (
      <div>
        <Navbar />
        <Container>
          {props.children}
        </Container>
        <Footer/>
      </div>
    );

}
