import React from 'react'
import { connect } from 'react-redux';

class CalculationResult extends React.Component {

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
    renderSalaryPart = (name, val) => {
        return (
            <tr key={name + val}>
                <td colSpan="3" className="text-left">{name}</td>
                <td className="text-right">{val + ' zł'}</td>
            </tr>
        )
    };
    renderInsuranceContributionSum = (insuranceContribution) => {
        let sumInsurances = 0;
        sumInsurances = this.sumInsuranceAmount(insuranceContribution, sumInsurances);
        return this.renderSalaryPart("Składki ZUS", sumInsurances.toFixed(2));
    };
    renderInsuranceContribution = (insuranceContribution) => {
        let insuranceParts = Object.entries(insuranceContribution);

        return insuranceParts.map(v => {
            let name = this.renderPropertyNames(v);
            let val = v[1];
            return this.renderSalaryPart(name, val);
        });
    };
    renderSalaryParts = (calculationResult) => {
        let result = Object.entries(calculationResult);
        delete result[7]; //insuranceContribution property
        return result.map(v => {
            let name = this.renderPropertyNames(v);
            let val = v[1];
            return this.renderSalaryPart(name, val);
        });
    };

    resultIsEmpty = () => {
        return Object.entries(this.props.calculationdata).length === 0 && this.props.calculationdata.constructor === Object;
    };

    sumInsuranceAmount = (insuranceContribution, sumInsurances) => {
        for (var el in insuranceContribution) {
            if (insuranceContribution.hasOwnProperty(el)) {
                sumInsurances += parseFloat(insuranceContribution[el]);
            }
        }
        return sumInsurances;
    }

    render() {
        if (this.resultIsEmpty()) {
            return <div></div>
        }

        return (

            <div>
                <h2 className="text-center mb-3">Podsumowanie</h2>
                <table className="table table-borderless">
                    <thead>
                        <tr>
                            <th scope="col"></th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderSalaryParts(this.props.calculationdata)}
                        {this.renderInsuranceContributionSum(this.props.calculationdata.insuranceContribution)}
                        {this.renderInsuranceContribution(this.props.calculationdata.insuranceContribution)}
                    </tbody>
                </table>
            </div>
        );
    }
};

const mapStateToProps = (state) => {
    return {
        calculationdata: state.calculation.calculationResult
    }

};

export default connect(mapStateToProps, null)(CalculationResult);