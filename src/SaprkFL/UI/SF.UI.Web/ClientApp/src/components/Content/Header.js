import React, { Fragment } from 'react';

class Header extends React.Component {
    render() {
        return (
            <Fragment>
                <div className="jumbotron jumbotron-fluid">
                    <div className="container">
                    </div>
                </div>
                <div className="container header__text text-center">
                    <blockquote className="blockquote">
                        <p className="mb-0">Jesteś freelancerem? Chciałbyś wiedzieć ile wypracujesz zysku wystawiając fakturę VAT? Dobrze trafiłeś ;)</p>
                    </blockquote>
                    <h1 className="display-8">Oblicz swoje wynagrodzenie</h1>
                    <h1 className="display-6">Kalkulator B2B</h1>
                    <button type="button" className="btn btn-a">Liczymy...</button>
                </div>
            </Fragment>
        );
    }
};

export default Header;