import React from 'react';
import { Route } from 'react-router';
import BaseLayout from './components/Layout/BaseLayout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';

export default () => (
  <BaseLayout>npm
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
  </BaseLayout>
);
