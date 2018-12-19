import React from 'react';
// import { Col, Grid, Row } from 'react-bootstrap';
import NavMenu from './NavMenu';

export default props => (
  <div>
    <header>
      <NavMenu />
    </header>

    <main className="container-fluid">
      {props.children}
    </main>

    <footer></footer>
  </div>
);
