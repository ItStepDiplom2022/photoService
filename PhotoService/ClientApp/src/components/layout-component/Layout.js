import React, { useState } from 'react';
import { Route, Routes } from 'react-router';
import authService from '../../services/auth.service';
import { Home } from '../Home';
import LoginPage from '../login-page-component/login-page';
import SignupPage from '../signup-page-component/signup-page';
import VerificationPage from '../verification-page-component/verification-page';
import Footer from './footer-component/footer';
import Navbar from './navbar-component/navbar';

export default function Layout() {

  const images = [
    {
      id: 1,
      url: "https://source.unsplash.com/random/?tech,care",
      title: "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.",
    },
    {
      id: 2,
      url: "https://source.unsplash.com/random/?tech,studied",
      title: "Aenean commodo ligula eget dolor. Aenean massa.",
    },
    {
      id: 3,
      url: "https://source.unsplash.com/random/?tech,substance",
      title:
        "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
    },
    {
      id: 4,
      url: "https://source.unsplash.com/random/?tech,choose",
      title:
        "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.",
    },
    {
      id: 5,
      url: "https://source.unsplash.com/random/?tech,past",
      title: "Nulla consequat massa quis enim.",
    },
    {
      id: 6,
      url: "https://source.unsplash.com/random/?tech,lamp",
      title:
        "Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu.",
    },
    {
      id: 7,
      url: "https://source.unsplash.com/random/?tech,yet",
      title: "In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo.",
    },
    {
      id: 8,
      url: "https://source.unsplash.com/random/?tech,eight",
      title: "Nullam dictum felis eu pede mollis pretium.",
    },
    {
      id: 9,
      url: "https://source.unsplash.com/random/?tech,crew",
      title: "Integer tincidunt. Cras dapibus.",
    },
    {
      id: 10,
      url: "https://source.unsplash.com/random/?tech,event",
      title: "Vivamus elementum semper nisi.",
    },
    {
      id: 11,
      url: "https://source.unsplash.com/random/?tech,instrument",
      title: "Aenean vulputate eleifend tellus.",
    },
    {
      id: 12,
      url: "https://source.unsplash.com/random/?tech,practical",
      title:
        "Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim.",
    },
    {
      id: 13,
      url: "https://source.unsplash.com/random/?tech,pass",
      title: "Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus.",
    },
    {
      id: 14,
      url: "https://source.unsplash.com/random/?tech,bigger",
      title: "Phasellus viverra nulla ut metus varius laoreet.",
    },
    {
      id: 15,
      url: "https://source.unsplash.com/random/?tech,number",
      title: "Quisque rutrum. Aenean imperdiet.",
    },
    {
      id: 16,
      url: "https://source.unsplash.com/random/?tech,feature",
      title: "Etiam ultricies nisi vel augue.",
    },
    {
      id: 17,
      url: "https://source.unsplash.com/random/?tech,line",
      title: "Curabitur ullamcorper ultricies nisi. Nam eget dui.",
    },
    {
      id: 18,
      url: "https://source.unsplash.com/random/?tech,railroad",
      title: "Etiam rhoncus.",
    },
    {
      id: 19,
      url: "https://source.unsplash.com/random/?tech,pride",
      title:
        "Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum.",
    },
    {
      id: 20,
      url: "https://source.unsplash.com/random/?tech,too",
      title: "Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem.",
    },
    {
      id: 21,
      url: "https://source.unsplash.com/random/?tech,bottle",
      title: "Maecenas nec odio et ante tincidunt tempus.",
    },
    {
      id: 22,
      url: "https://source.unsplash.com/random/?tech,base",
      title: "Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante.",
    },
    {
      id: 23,
      url: "https://source.unsplash.com/random/?tech,cell",
      title: "Etiam sit amet orci eget eros faucibus tincidunt. Duis leo.",
    },
    {
      id: 24,
      url: "https://source.unsplash.com/random/?tech,bag",
      title: "Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna.",
    },
    {
      id: 25,
      url: "https://source.unsplash.com/random/?tech,card",
      title: "Sed consequat, leo eget bibendum sodales, augue velit cursus nunc.",
    },
  ];
  

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
        <Route exact path='/' element={<Home images={images}/>} />
      </Routes>
      <Footer />
    </div>
  );

}
