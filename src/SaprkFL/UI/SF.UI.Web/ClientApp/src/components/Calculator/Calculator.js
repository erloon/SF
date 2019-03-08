import React from 'react';
import CalculatorSectionHeader from '../Layout/SectionHeader';
import { connect } from 'react-redux';
import MonthlyCalculator from './MonthlyCalculator';

import { calculateMonthlySalary, setCalculationType, calculateYearlySalary } from '../../actions/CalculationActions';

class Calculator extends React.Component {

    onSubmit = (formValues) => {
        if(this.props.calculationType ==="monthly"){
            this.props.calculateMonthlySalary(formValues);
        }
        else if(this.props.calculationType ==="yearly"){
            this.props.calculateYearlySalary(formValues);
        }
    };

    render() {
        return (
            <div className="container">
                <section className="section-services section-t8 section-form">
                    <div className="container">
                        <div className="row">
                            <div className="col-md-12">
                                <CalculatorSectionHeader css="title-calculator-wrap" title="Kalkulator" />
                            </div>
                        </div>
                        <MonthlyCalculator calculateSalary={this.onSubmit}/>
                    </div>
                </section>
            </div>
        );
    }
};

const mapStateToProps = (state)=>{
    return {
        calculationType: state.calculation.calculationType
    }
}

export default connect(mapStateToProps,{calculateMonthlySalary, setCalculationType, calculateYearlySalary})(Calculator);