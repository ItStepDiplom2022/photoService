import React, { useState } from 'react';
import { Route, Routes } from 'react-router';
import authService from '../../services/auth.service';
import { Home } from '../Home';
import ImageAddingPage from '../image-adding-page-component/image-adding-page';
import ImageDetailsPage from '../image-details-page-component/image-details-page';
import LoginPage from '../login-page-component/login-page';
import SignupPage from '../signup-page-component/signup-page';
import VerificationPage from '../verification-page-component/verification-page';
import Footer from './footer-component/footer';
import Navbar from './navbar-component/navbar';

export default function Layout() {
  

  const [isLoggedIn, setIsLogged] = useState(authService.isLoggedIn())

  const onLoggedChange = () => {
    setIsLogged(authService.isLoggedIn())
  }

  return (
    <div>
      <Navbar isLoggedIn={isLoggedIn} onLoggedChange={onLoggedChange} />
      <Routes>
        <Route exact path='/login' element={<LoginPage onLoggedChange={onLoggedChange} />} />
        <Route exact path='/signup' element={<SignupPage onLoggedChange={onLoggedChange} />} />
        <Route exact path='/verify' element={<VerificationPage />} />
        <Route exact path='/image/:id' element={<ImageDetailsPage/>}/>
        <Route exact path='/image/add' element={<ImageAddingPage/>}/>
        <Route exact path='/' element={<Home/>} />
      </Routes>
      <Footer />
    </div>
  );

}
