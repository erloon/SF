import React from 'react'
import { connect } from 'react-redux';

class MonthlyResult extends React.Component {
    render() {
        return (
            <div class="list-group">
                <a href="#" className="list-group-item list-group-item-action flex-column align-items-start active">
                    <div className="d-flex w-100 justify-content-between">
                        <h5 className="mb-1">List group item heading</h5>
                        <small>3 days ago</small>
                    </div>
                    <p className="mb-1">Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.</p>
                    <small>Donec id elit non mi porta.</small>
                </a>
            </div>
        )
    }
}

export default connect(null, null)(MonthlyResult);