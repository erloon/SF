import React from 'react';
import Sidebar from './Sidebar';
import Navbar from './Navbar';

export default props => (
  <div className="wrapper">

   <Sidebar/>

    <div id="content">
      <Navbar/>
      {props.children}
    </div>
  </div>
);
