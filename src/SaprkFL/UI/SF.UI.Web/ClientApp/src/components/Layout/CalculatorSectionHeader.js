import React from 'react';

class CalculatorSectionHeader extends React.Component {
    render() {
        return (
            <div className="title-calculator-wrap d-flex justify-content-center">
                <div className="title-box">
                    <h2 className="title-a">{this.props.title}</h2>
                </div>
            </div>
        );
    }
};

export default CalculatorSectionHeader;