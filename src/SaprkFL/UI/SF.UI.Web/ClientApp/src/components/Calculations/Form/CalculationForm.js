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
        let values = this.generateValues(formValues);
        this.props.calculateSalary(values);
    };

    generateValues = (formValues) => {
        if (this.isYearlyFormNeeded()) {
            const yearlyValues = {
                isGross: formValues.isGross,
                accidentContributionPercentage: formValues.accidentContributionPercentage,
                isMedicalInsurance: formValues.isMedicalInsurance,
                taxationForm: formValues.taxationForm,
                insuranceContributionForm: formValues.insuranceContributionForm,
                monthlyBalanceSheetData: this.RenderMonthlySheetData(formValues)
            };
            return yearlyValues;
        }
        return formValues;
    };

    RenderMonthlySheetData = (formValues) => {
        let values = Object.entries(formValues);
        let monthlySalaries = values.filter((value) => {

            return value[0].includes("salary-");
        })
        let result = [];
        monthlySalaries.map((value) => {

            result.push({
                month: value[0].replace("salary-",""),
                salary: value[1],

            })
        });
        return result;
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

    createYearlyInputForm = () => {
        return this.props.dictionary.MonthNumbers.map(month => {
            return <CalculationFormNumberField key={month} label={this.props.dictionary.MonthNames[month - 1] + ":"} name={"salary-" + month} min="0" />
        });
    };

    isYearlyFormNeeded = () => {
        if (this.props.calculationFormData) {
            if (this.props.calculationFormData.values.differentMonthlySalary)
                return true;
        }
        return false;
    };

    renderYearlyInputForm = () => {
        if (this.isYearlyFormNeeded() && this.isYearlyCalculationType() ) {
            return this.createYearlyInputForm();
        }
        return;

    };

    isYearlyCalculationType = ()=>{
        return this.props.calculationType === 'yearly';
    };

    renderDifferentMonthlySalary = () => {
        if (this.isYearlyCalculationType()) {
            return (
                <React.Fragment>
                    <CalculationFormCheckField label="Wszystkie kwoty z VAT" name="isGross" />
                    <CalculationFormCheckField key="differentMonthlySalary" label="Wynagrodzenie jest inne w pozostałych miesiącach?" name="differentMonthlySalary" />
                </React.Fragment>
                )
            }
    };

    renderDifferentMonthlySalaryField = ()=>{
        if(!this.isYearlyCalculationType()){
            return (
                    <React.Fragment>
                        <CalculationFormNumberField label="Wynagrodzenie" name="salary" min="0" helpText="Kwota na jaką wystawiasz fakturę" />
                        <CalculationFormCheckField label="z VAT?" name="isGross" />
                    </React.Fragment>
                    )
        }
    };

    render() {
        if (!this.props.dictionary) {
            return <div>Loading ... </div>
        }
        const { InsuranceContributionForm, TxationForm } = this.props.dictionary;
        return (
            <form onSubmit={this.props.handleSubmit(this.onSubmit)}>
                {this.renderDifferentMonthlySalaryField()}
                
               
                <CalculationFormNumberField label="Odliczenie VAT" name="vatAmmountDeduction" min="0" helpText="Kwota VAT do odliczenia z faktur kosztowych" />
                <CalculationFormNumberField label="Koszty" name="incomeCosts" min="0" helpText="Koszty uzyskania przychodu netto" />
                <CalculationFormNumberField label="Przychody" name="previousMonthsIncomes" min="0" helpText="Przychód z poprzednich miesięcy netto" />
                <CalculationFormCheckField label="Składka chorobowa?" name="isMedicalInsurance" />
                <CalculationFormNumberField label="Składka wypadkowa" name="accidentContributionPercentage" min=".67" helpText="minimalnie 1,67%" />
                <CalculationFormSelectField label="Ulga przy składkach ZUS" name="insuranceContributionForm" options={this.renderOption(InsuranceContributionForm)} />
                <CalculationFormSelectField label="Forma opodatkowania" name="taxationForm" options={this.renderOption(TxationForm)} />
                {this.renderDifferentMonthlySalary()}
                {this.renderYearlyInputForm()}
                <CalculationFormSubmit description="Przelicz" />
            </form>
        )
    };
};

const mapStateToProps = (state) => {
    return {
        calculationdata: state.selfEmployeeCalculation,
        dictionary: state.dictionary,
        calculationType: state.calculation.calculationType,
        calculationFormData: state.form.calculationForm
    };
};

const CalculationFormLink = connect(
    mapStateToProps,
    { getDictionaries }
)(CalculationForm);

export default reduxForm({
    form: 'calculationForm'
})(CalculationFormLink)