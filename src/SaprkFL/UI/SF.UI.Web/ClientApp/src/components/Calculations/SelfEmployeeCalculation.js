import React, { Component } from 'react'
import { Field, reduxForm } from 'redux-form'
import { connect } from 'react-redux';
import { calculateSalary } from '../../actions/SelfEmployeeCalculationActions';
import { getDictionaries } from "../../actions/DictionaryActions";

class SelfEmployeeCalculation extends Component {
    onSubmit = (formValues) => {
        this.props.calculateSalary(formValues)
    }
    componentDidMount() {
        this.props.getDictionaries();
    }
    componentWillMount(){
        this.props.initialize({
            salary: 0,
            isGross: false,
            vatAmmountDeduction: 0,
            incomeCosts: 0,
            previusMonthsIncomes: 0,
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
            <div>
                <h1 className="text-center">Kalkulacja</h1>
                <p className="lead text-center">Oblicz wysokość wynagrodzenia dla jednoosobowej działalności gospodarczej.</p>
                <form onSubmit={this.props.handleSubmit(this.onSubmit)}>
                    <div className="form-group row">
                        <label className="col-sm-2 col-form-label" htmlFor="salary">Wynagrodzenie</label>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <Field 
                                className="form-control" 
                                component="input" 
                                type="number" 
                                name="salary"
                                min="0"
                                aria-describedby="salaryHelp"
                                />
                                <small id="salaryHelp" class="form-text text-muted">Kwota na jaką wystawiasz fakturę</small>
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2"></div>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <div className="form-check">
                                <Field className="form-check-input" component="input" type="checkbox" name="isGross" />
                                <label className="form-check-label" htmlFor="isGross">z VAT?</label>
                            </div>
                        </div>
                    </div>
                    <div className="form-group row">
                        <label htmlFor="vatAmmountDeduction" className="col-sm-2 col-form-label">Odliczenie VAT</label>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <Field 
                                className="form-control" 
                                component="input" 
                                type="number" 
                                min="0"
                                name="vatAmmountDeduction" 
                                aria-describedby="vatAmmountDeductionHelp"
                                />
                            <small id="vatAmmountDeductionHelp" class="form-text text-muted">Kwota VAT do odliczenia z faktur kosztowych</small>
                        </div>
                    </div>
                    <div className="form-group row">
                        <label htmlFor="incomeCosts" className="col-sm-2 col-form-label">Koszty</label>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <Field 
                                className="form-control" 
                                component="input" 
                                type="number" 
                                min="0"
                                name="incomeCosts"
                                aria-describedby="incomeCostsHelp"
                                />
                            <small id="incomeCostsHelp" class="form-text text-muted">Koszty uzyskania przychodu netto</small>           
                        </div>
                    </div>
                    <div className="form-group row">
                        <label htmlFor="previusMonthsIncomes" className="col-sm-2 col-form-label">Przychody</label>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <Field 
                                className="form-control" 
                                component="input" 
                                type="number" 
                                min="0"
                                name="previusMonthsIncomes" 
                                aria-describedby="previusMonthsIncomesHelp"
                                />
                            <small id="incomeCostsHelp" class="form-text text-muted">Przychód z poprzednich miesięcy netto</small>  
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2"></div>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <div className="form-check">
                                <Field className="form-check-input" component="input" type="checkbox" name="isMedicalInsurance" />
                                <label className="form-check-label" htmlFor="isMedicalInsurance">Ubezpieczenie zdrowotne?</label>
                            </div>
                        </div>
                    </div>
                    <div className="form-group row">
                        <label htmlFor="accidentContributionPercentage" className="col-sm-2 col-form-label">Składka wypadkowa</label>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <Field 
                                className="form-control" 
                                component="input" 
                                type="number" 
                                min="1.67"
                                name="accidentContributionPercentage" 
                                aria-describedby="accidentContributionPercentageHelp"
                                />
                            <small id="accidentContributionPercentageHelp" class="form-text text-muted">minimalnie 1,67%</small>
                        </div>
                    </div>
                    <div className="form-group row">
                        <label htmlFor="insuranceContributionForm" className="col-sm-2 col-form-label">Ulga przy składkach ZUS</label>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <Field className="custom-select" component="select" name="insuranceContributionForm" >
                                {this.renderOption(InsuranceContributionForm)}
                            </Field>
                        </div>
                    </div>
                    <div className="form-group row">
                        <label htmlFor="taxationForm" className="col-sm-2 col-form-label">Forma opodatkowania</label>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <Field className="custom-select" component="select" name="taxationForm" >
                                {this.renderOption(TxationForm)}
                            </Field>
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2"></div>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <div className="form-check">
                                <Field className="form-check-input" component="input" type="checkbox" name="differentMonthlySalary" />
                                <label className="form-check-label" htmlFor="differentMonthlySalary">Wynagrodzenie jest inne w pozostałych miesiącach</label>
                            </div>
                        </div>
                    </div>
                    <div className="form-group row">
                        <div className="col-sm-2"></div>
                        <div className="col-sm-10 col-md-8 col-lg-6">
                            <button type="submit" className="btn btn-info btn-sm btn-block active">Przelicz dla miesiąca</button>
                            <button type="button" className="btn btn-secondary btn-sm btn-block active">Przelicz dla roku</button>
                        </div>
                    </div>

                </form>

            </div>
        );
    }

}
const mapStateToProps = (state) => {
    return {
        calculationdata: state.selfEmployeeCalculation,
        calculationDictionary: state.calculationDictionary    };
};

const SelfEmployeeCalculationLink = connect(
    mapStateToProps,
    { calculateSalary, getDictionaries }
)(SelfEmployeeCalculation);

export default reduxForm({
    form: 'selfEmployeeCalculation',
    enableReinitialize : true
})(SelfEmployeeCalculationLink)
