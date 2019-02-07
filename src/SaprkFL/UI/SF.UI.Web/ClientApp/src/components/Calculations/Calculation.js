import React, { Component } from 'react';
import { connect } from 'react-redux';
import { calculateMonthlySalary, setCalculationType, calculateYearlySalary } from '../../actions/CalculationActions';
import CalculationForm from './Form/CalculationForm';
import CalculationResult from './Results/CalculationResult';
class Calculation extends Component {
    onSubmit = (formValues) => {
        if(this.props.calculationType ==="monthly"){
            this.props.calculateMonthlySalary(formValues);
        }
        else if(this.props.calculationType ==="yearly"){
            this.props.calculateYearlySalary(formValues);
        }
    };
    setCalculationType = (type)=>{
        this.props.setCalculationType(type);
    };
    render() {
        return (
            <div>
                <div className="row">
                    <div className="col-sm-2"></div>
                    <div className="col-sm-10 col-md-8 col-lg-6">
                        <h1 className="text-center">Kalkulacja</h1>
                        <p className="lead text-center">Oblicz wysokość wynagrodzenia dla jednoosobowej działalności gospodarczej.</p>
                    </div>
                </div>
                <div className="row">
                    <div className="col-sm-2"></div>
                    <div className="col-sm-10 col-md-8 col-lg-6 text-center">
                        <div className="btn-group btn-group-lg" role="group" aria-label="...">
                            <button type="button" onClick={()=>this.setCalculationType('monthly')} className="btn btn-info active">Miesięczna</button>
                            <button type="button" onClick={()=>this.setCalculationType('yearly')}  className="btn btn-info">Roczna</button>
                        </div>
                    </div>
                </div>
                <div className="row mt-2">
                    <div className="col">
                        <CalculationForm calculateSalary={this.onSubmit}/>
                    </div>
                </div>
                <div className="row mt-2">
                    <div className="col-sm-2"></div>
                    <div className="col-sm-10 col-md-8 col-lg-6 text-center">
                        <CalculationResult/>
                    </div>
                </div>
            </div>
        );
    }

};

const mapStateToProps = (state)=>{
    return {
        calculationType: state.calculation.calculationType
    }
}

export default connect(mapStateToProps,{calculateMonthlySalary, setCalculationType, calculateYearlySalary})(Calculation);
