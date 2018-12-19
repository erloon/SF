import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout/Layout';
import Home from './components/Home';
import SelfEmployeeCalculation from './components/Calculations/SelfEmployeeCalculation';

export default () => (
  <Layout>
    <Route path='/' render={()=><Home/>} exact />
    <Route path='/selfemployeecalculation' render={()=><SelfEmployeeCalculation/>} />
  </Layout>
);
