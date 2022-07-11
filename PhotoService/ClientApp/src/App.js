import React from 'react';
import { Route } from 'react-router';
import { Home } from './components/Home';
import Layout from './components/layout-component/Layout';

import './custom.css'

export default function App () {

    return (
      <Layout>
        <Route exact path='/' component={Home} />
      </Layout>
    );
}
