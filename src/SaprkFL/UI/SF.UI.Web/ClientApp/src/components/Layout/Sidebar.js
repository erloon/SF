import React from 'react'
import { connect } from 'react-redux';
import { Link } from 'react-router-dom'

class Sidebar extends React.Component {

    render() {
        return (
            <nav id="sidebar" className={this.props.sidebarCss} >
                <div className="sidebar-header">
                    <h3>SparkFreelancer</h3>
                </div>

                <ul className="list-unstyled components">
                    <li>
                        <Link to="/">Home</Link>
                    </li>
                    <li>
                        <Link to="/selfemployeecalculation">Kalkulacja</Link>
                    </li>
                    <li className="active">
                        <a href="#homeSubmenu" data-toggle="collapse" aria-expanded="false" className="dropdown-toggle">Finanse</a>
                        <ul className="collapse list-unstyled" id="homeSubmenu">
                            <li>
                                <Link to="">Przychody</Link>
                            </li>
                            <li>
                                <Link to="">Koszty</Link>
                            </li>
                        </ul>
                    </li>
                </ul>
            </nav>
        )
    };
};

const mapStateToProps = state => {
    return { sidebarCss: state.layout.sidebarCss };
}
export default connect(mapStateToProps, null)(Sidebar);