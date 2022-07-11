import React from 'react';
import Footer from './footer-component/footer';
import Navbar from './navbar-component/navbar';

export default function Layout (props) {

    return (
      <div>
        <Navbar />
          {props.children}
        <Footer/>
      </div>
    );

}
