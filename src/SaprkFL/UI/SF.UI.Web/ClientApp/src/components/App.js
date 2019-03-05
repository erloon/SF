import React from 'react';
import { Route } from 'react-router';
import Layout from './Layout/Layout';
import Home from './Home';
import Calculator from './Calculator/Calculator';

import Calculation from './Calculations/Calculation';
import Contact from './Contact';

const App = props => (
  <Layout>
    <Route path='/' render={() => <Home />} exact />
    <Route path='/Calculator' render={() => <Calculator />} exact />
    <Route path='/Contact' render={() => <Contact />} exact />
  </Layout>

  // <Layout>
  //   <Route path='/' render={() => <Home />} exact />
  //   <Route path='/contact' render={() => <Contact />} exact />
  //   <Route path='/Calculation' render={() => <Calculation />} />
  // </Layout>
);

export default App;
