import React from 'react';
import { Field, reduxForm } from 'redux-form';
import { connect } from 'react-redux';
import { getDictionaries } from "../../actions/DictionaryActions";

import CheckField from './Form/CheckField';
import NumberField from './Form/NumberField';
import HelpField from './Form/HelpField';
import SelectField from './Form/SelectField';
import CalculationFormSelectField from '../Calculations/Form/CalculationFormSelectField';

class MonthlyCalculator extends React.Component {

    onSubmit = (formValues) => {
        this.props.calculateSalary(formValues);
    };

    componentDidMount() {
        this.props.getDictionaries();
    };

    componentWillMount() {
        this.props.initialize({
            salary: 0,
            isGross: false,
            vatAmmountDeduction: 0,
            incomeCosts: 0,
            previousMonthsIncomes: 0,
            isMedicalInsurance: false,
            accidentContributionPercentage: 1.67,
            insuranceContributionForm: 1,
            taxationForm: 1
        });
    };

    renderOption = (values) => {
        return values.map(v => {
            return (
                <option value={v.value} key={v.value}>{v.name}</option>
            )
        });

    };

    render() {
        if (!this.props.dictionary) {
            return <div>Loading ... </div>
        }
        const { InsuranceContributionForm, TxationForm } = this.props.dictionary;
        return (
            <div className="row justify-content-center">
                <div className="col-md-9">
                    <form className="form-a contactForm" onSubmit={this.props.handleSubmit(this.onSubmit)}>
                        <div className="row">
                            <div className="col-md-12 mb-3">
                                <NumberField
                                    name="salary"
                                    min="0"
                                    help={<HelpField helpText="Kwota na jaką wystawiasz fakturę" />}
                                />
                                <CheckField name="isGross" description="Czy jest z VAT?" />
                            </div>

                        </div>
                        <div className="row">
                            <div className="col-md-6 mb-3">
                                <NumberField
                                    description="Odliczenie VAT"
                                    name="vatAmmountDeduction"
                                    min="0"
                                    help={<HelpField helpText="Kwota VAT do odliczenia z faktur kosztowych" />}
                                />
                            </div>
                            <div className="col-md-6 mb-3">
                                <NumberField
                                    description="Koszty"
                                    name="incomeCosts"
                                    min="0"
                                    help={<HelpField helpText="Koszty uzyskania przychodu netto" />}
                                />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-6 mb-3">
                                <NumberField
                                    description="Przychody"
                                    name="previousMonthsIncomes"
                                    min="0"
                                    help={<HelpField helpText="Przychód z poprzednich miesięcy netto" />}
                                />
                            </div>
                            <div className="col-md-6 mb-3">
                                <NumberField
                                    name="accidentContributionPercentage"
                                    min=".67"
                                    help={<HelpField helpText=" Składka wypadkowa minimalnie 1,67%" />}
                                />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-6 mb-3">
                                <SelectField
                                    name="insuranceContributionForm"
                                    help={<HelpField helpText="Ulga przy składkach ZUS" />}
                                    options={this.renderOption(InsuranceContributionForm)}
                                />
                            </div>
                            <div className="col-md-6 mb-3">
                                <SelectField
                                    name="taxationForm"
                                    help={<HelpField helpText="Forma opodatkowania" />}
                                    options={this.renderOption(TxationForm)}
                                />
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-md-6 mb-3">
                                <CheckField customClass="form-check form-check-middle" name="isMedicalInsurance" description="Opłacasz składka chorobową?" />
                            </div>
                        </div>
                        <div className="row text-center">
                            <div className="col">
                                <button type="submit" className="btn btn-a">Oblicz</button>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        );
    }
};
const mapStateToProps = (state) => {
    return {
        calculationdata: state.selfEmployeeCalculation,
        dictionary: state.dictionary,
        calculationType: state.calculation.calculationType,
        calculationFormData: state.form.MonthlyCalculatorForm
    };
};

const MonthlyCalculatorLink = connect(
    mapStateToProps,
    { getDictionaries }
)(MonthlyCalculator);

export default reduxForm({
    form: 'MonthlyCalculatorForm'
})(MonthlyCalculatorLink)