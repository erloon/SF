import React from 'react';
import Navigation from '../Layout/Navigation';

export default props => (
  <div>
    <Navigation />
    <div>
      {props.children}
    </div>
  </div>
);
