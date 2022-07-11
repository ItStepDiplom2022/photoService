import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { Home } from './components/Home';
import Layout from './components/layout-component/Layout';
import LoginPage from './components/login-page-component/login-page';
import SignupPage from './components/signup-page-component/signup-page';

import './custom.css'

export default function App() {

  return (
    <Layout>
      <Routes>
        <Route exact path='/login' element={<LoginPage />} />
        <Route exact path='/signup' element={<SignupPage />} />
        <Route exact path='/' element={<Home />} />
      </Routes>
    </Layout>
  );
}
