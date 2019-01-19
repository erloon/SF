import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { toggleSidebar } from '../../actions/LayoutActions'

class Navbar extends React.Component {
    onClickSidebar(e) {
        const css = (this.props.sidebarCss === 'active') ? '' : 'active';
        this.props.toggleSidebar(css);
    };
    render() {
        return (
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container-fluid">
                    <button type="button" id="sidebarCollapse" className={`navbar-btn ${this.props.sidebarCss}`} onClick={this.onClickSidebar.bind(this)}>
                        <span></span>
                        <span></span>
                        <span></span>
                    </button>
                    <button className="btn btn-dark d-inline-block d-lg-none ml-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="nav navbar-nav ml-auto">
                            <li className="nav-item active">
                                <Link className="nav-link" to="/contact">Kontakt</Link>
                            </li>
                            <li className="nav-item active">
                                <a className="nav-link" href="https://github.com/erloon/SF">Github</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        )
    };
};

const mapStateToProps = state => {
    return { sidebarCss: state.layout.sidebarCss };
}
export default connect(mapStateToProps, { toggleSidebar })(Navbar);