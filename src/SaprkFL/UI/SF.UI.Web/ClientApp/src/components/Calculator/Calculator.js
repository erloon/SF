import React from 'react';
import SectionHeader from '../Layout/SectionHeader';

class Calculator extends React.Component {
    render() {
        return (
            <div className="container">
                <section className="section-services section-t8">
                    <div className="container">
                        <div className="row">
                            <div className="col-md-12">
                                <SectionHeader title="Kalkulator" />
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        );
    }
};

export default Calculator;