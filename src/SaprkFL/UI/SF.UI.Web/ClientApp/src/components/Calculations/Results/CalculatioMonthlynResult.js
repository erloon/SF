import React from 'react'
import { connect } from 'react-redux';

class CalculatioMonthlynResult extends React.Component {

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
        sumInsurances = this.props.sumInsuranceAmount(insuranceContribution, sumInsurances);
        return this.renderSalaryPart("Składki ZUS", sumInsurances);
    };

    renderInsuranceContribution = (insuranceContribution) => {
        let insuranceParts = Object.entries(insuranceContribution);

        return insuranceParts.map(v => {
            let name = this.props.renderPropertyNames(v);
            let val = v[1];
            return this.renderSalaryPart(name, val);
        });
    };

    renderSalaryParts = (calculationResult) => {
        let result = Object.entries(calculationResult);
        delete result[7]; //insuranceContribution property
        return result.map(v => {
            let name = this.props.renderPropertyNames(v);
            let val = v[1];
            return this.renderSalaryPart(name, val);
        });
    };

    resultIsEmpty = () => {
        return Object.entries(this.props.calculationdata).length === 0 && this.props.calculationdata.constructor === Object;
    };

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
        calculationdata: state.calculation.calculationResult,
        dictionary: state.dictionary
    }

};

export default connect(mapStateToProps,null)(CalculatioMonthlynResult);