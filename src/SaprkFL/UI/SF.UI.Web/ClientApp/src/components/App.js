import React from 'react';
import { Route } from 'react-router';
import Layout from './Layout/Layout';
import Home from './Home';

import SelfEmployeeCalculation from './Calculations/SelfEmployeeCalculation';

const App = props => (
  <Layout>
    <Route path='/' render={() => <Home />} exact />
    <Route path='/selfemployeecalculation' render={() => <SelfEmployeeCalculation />} />
  </Layout>
);

export default App;
