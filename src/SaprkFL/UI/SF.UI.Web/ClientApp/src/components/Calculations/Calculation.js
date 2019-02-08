import React, { Component } from 'react';
import { connect } from 'react-redux';
import { calculateMonthlySalary, setCalculationType, calculateYearlySalary } from '../../actions/CalculationActions';
import CalculationForm from './Form/CalculationForm';
import CalculatioMonthlynResult from './Results/CalculatioMonthlynResult';
import CalculationYearlyResult from './Results/CalculationYearlyResult'
class Calculation extends Component {

    onSubmit = (formValues) => {
        if(this.props.calculationType ==="monthly"){
            this.props.calculateMonthlySalary(formValues);
        }
        else if(this.props.calculationType ==="yearly"){
            this.props.calculateYearlySalary(formValues);
        }
    };
    
    sumInsuranceAmount = (insuranceContribution, sumInsurances) => {
        for (var el in insuranceContribution) {
            if (insuranceContribution.hasOwnProperty(el)) {
                sumInsurances += parseFloat(insuranceContribution[el]);
            }
        }
        return sumInsurances.toFixed(2);
    };

    
    renderPropertyNames = (property) => {
        switch (property[0]) {
            case 'netSalary':
                return "Wynagrodzenie netto:"
            case 'netSalaryEstimate':
                return "Zysk z faktury bez kosztów:"
            case 'grossSalary':
                return "Wynagrodzenie brutto:"
            case 'incomeCosts':
                return "Koszty netto:"
            case 'taxBase':
                return "Podstawa opodatkowania:"
            case 'vatAmount':
                return "VAT:"
            case 'healthInsurance':
                return "    Skladka zdrowotna:"
            case 'medicalInsurance':
                return "Składka chorobowa:"
            case 'disabilitiInsurance':
                return "Składka rentowa:"
            case 'retirementInsurance':
                return "Składka emerytalna:"
            case 'accidentInsurance':
                return "Składka wypakowa:"
            case 'laborFoundInsurance':
                return "Składka na Fundusz Pracy:"
            case 'taxAmount':
                return "Podatek dochodowy:"
            default:
                return "Błąd";
        }
    };

    setCalculationType = (type)=>{
        this.props.setCalculationType(type);
    };

    renderResult = ()=>{
        if(this.props.calculationType==="monthly")
            return <CalculatioMonthlynResult renderPropertyNames={this.renderPropertyNames} sumInsuranceAmount={this.sumInsuranceAmount}/>;
        return <CalculationYearlyResult renderPropertyNames={this.renderPropertyNames} sumInsuranceAmount={this.sumInsuranceAmount}/>
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
                            <button type="button" onClick={()=>this.setCalculationType('monthly')} className="btn btn-info">Miesięczna</button>
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
                    {this.renderResult()}
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
