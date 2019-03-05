import React, { Fragment } from 'react'
import Header from './Content/Header';
import Calculator from './Calculator/Calculator';

class Home extends React.Component {
    render() {
        return (
            <Fragment>
                <Header/>
                <Calculator/>
            </Fragment>

        );
    }
};

export default Home;