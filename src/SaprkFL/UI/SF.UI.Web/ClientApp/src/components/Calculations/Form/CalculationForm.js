import React, { Component } from 'react';
import { reduxForm } from 'redux-form';
import { connect } from 'react-redux';
import { getDictionaries } from "../../../actions/DictionaryActions";

import CalculationFormNumberField from './CalculationFormNumberField';
import CalculationFormCheckField from './CalculationFormCheckField';
import CalculationFormSelectField from './CalculationFormSelectField';
import CalculationFormSubmit from './CalculationFormSubmit';



class CalculationForm extends Component {
    onSubmit = (formValues) => {
        this.props.calculateSalary(formValues);
    }
    componentDidMount() {
        this.props.getDictionaries();
    }
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
    }
    renderOption = (values) => {
        return values.map(v => {
            return (
                <option value={v.value} key={v.value}>{v.name}</option>
            )
        });

    }

    render() {
        if (!this.props.calculationDictionary) {
            return <div>Loading ... </div>
        }
        const { InsuranceContributionForm, TxationForm } = this.props.calculationDictionary;
        return (
            <form onSubmit={this.props.handleSubmit(this.onSubmit)}>
                <CalculationFormNumberField label="Wynagrodzenie" name="salary" min="0" helpText="Kwota na jaką wystawiasz fakturę" />
                <CalculationFormCheckField label="z VAT?" name="isGross" />
                <CalculationFormNumberField label="Odliczenie VAT" name="vatAmmountDeduction" min="0" helpText="Kwota VAT do odliczenia z faktur kosztowych" />
                <CalculationFormNumberField label="Koszty" name="incomeCosts" min="0" helpText="Koszty uzyskania przychodu netto" />
                <CalculationFormNumberField label="Przychody" name="previousMonthsIncomes" min="0" helpText="Przychód z poprzednich miesięcy netto" />
                <CalculationFormCheckField label="Składka chorobowa?" name="isMedicalInsurance" />
                <CalculationFormNumberField label="Składka wypadkowa" name="accidentContributionPercentage" min=".67" helpText="minimalnie 1,67%" />
                <CalculationFormSelectField label="Ulga przy składkach ZUS" name="insuranceContributionForm" options={this.renderOption(InsuranceContributionForm)} />
                <CalculationFormSelectField label="Forma opodatkowania" name="taxationForm" options={this.renderOption(TxationForm)} />
                <CalculationFormCheckField label="Wynagrodzenie jest inne w pozostałych miesiącach?" name="differentMonthlySalary" />
                <CalculationFormSubmit description="Przelicz"/>
            </form>
        )
    }
}

const mapStateToProps = (state) => {
    return {
        calculationdata: state.selfEmployeeCalculation,
        calculationDictionary: state.calculationDictionary,
        calculationType: state.calculation.calculationType
    };
};

const CalculationFormLink = connect(
    mapStateToProps,
    { getDictionaries }
)(CalculationForm);

export default reduxForm({
    form: 'calculationForm'
})(CalculationFormLink)