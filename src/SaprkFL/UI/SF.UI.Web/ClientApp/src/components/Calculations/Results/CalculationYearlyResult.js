import React from 'react'
import { connect } from 'react-redux';

class CalculationYearlyResult extends React.Component {


    resultIsEmpty = () => {
        return Object.entries(this.props.calculationData).length === 0 && this.props.calculationData.constructor === Object;
    };

    renderRow = (rowData) => {
        debugger;
        let baseResults = Object.entries(rowData.result);
        let insuranceContribution = rowData.result.insuranceContribution;
        delete baseResults[7];

        let sumInsurances = 0;
        sumInsurances = this.props.sumInsuranceAmount(insuranceContribution, sumInsurances);
        return (
            <tr key={rowData.month}>
                <td>{this.props.dictionary.MonthNames[rowData.month-1]}</td>
                <td>{baseResults[0][1]}</td>
                <td>{baseResults[1][1]}</td>
                <td>{baseResults[2][1]}</td>
                <td>{baseResults[3][1]}</td>
                <td>{baseResults[4][1]}</td>
                <td>{baseResults[5][1]}</td>
                <td>{baseResults[6][1]}</td>
                <td>{sumInsurances}</td>
            </tr>
        )
    };

    renderRows = () => {
        let results = this.props.calculationData.monthlyResults;
        return results.map((rowData) => {
            return this.renderRow(rowData);
        });
    };


    render() {
        if (this.resultIsEmpty()) {
            return <div></div>
        }

        return (
            <div>
                <h2 className="text-center mb-3">Podsumowanie</h2>
                <table className="table table-borderless">
                    <tbody>
                        <tr>
                            <th>Suma wynagrodzenia netto:</th>
                            <th>{this.props.calculationData.netSalarySum}</th>
                        </tr>
                        <tr>
                            <th>Suma kosztów netto:</th>
                            <th>{this.props.calculationData.incomeCostsSum}</th>
                        </tr>
                    </tbody>
                </table>
                <table className="table table-sm">
                    <thead>
                        <tr>
                            <th scope="col">Miesiąc</th>
                            <th scope="col">Wynagrodzneie netto</th>
                            <th scope="col">Zysk z faktury</th>
                            <th scope="col">Wynagrodzenie brutto</th>
                            <th scope="col">Koszty uzyskania przychodu</th>
                            <th scope="col">Podstawa opodatkowania</th>
                            <th scope="col">Podatek dochodowy</th>
                            <th scope="col">Kwoat VAT</th>
                            <th scope="col">Składki ZUS</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderRows()}
                    </tbody>
                </table>
            </div>
        )
    }
};

const mapStateToProps = (state) => {
    return {
        calculationData: state.calculation.calculationResult,
        dictionary: state.dictionary
    }
};


export default connect(mapStateToProps, null)(CalculationYearlyResult);