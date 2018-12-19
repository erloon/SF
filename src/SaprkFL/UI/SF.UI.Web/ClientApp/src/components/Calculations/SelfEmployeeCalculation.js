import React, { Component } from 'react'
import { Field, reduxForm } from 'redux-form'
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { CalculateSalary } from '../../actions/SelfEmployeeCalculationActions';
import { stat } from 'fs';

class SelfEmployeeCalculation extends Component {

    render() {

        console.log(this.props);
        return (

            <div className="row">
                <div className="col-3"></div>
                <div className="col-6 mt-4">
                    <p className="h3 text-center">Kalkulacja</p>
                    <p className="lead">
                        Oblicz wysokość wynagrodzenia dla dziłalności gospodarczej
                    </p>
                    <hr />
                    <form>
                        <div className="form-row">
                            <div className="form-group col">
                                <label htmlFor="salary">Wynagrodzenie</label>
                                <Field className="form-control" component="input" type="number" placeholder="Kwota na jaką wystawiasz fakturę" name="salary" />
                            </div>
                        </div>
                        <div className="form-group">
                            <div className="form-check">
                                <Field className="form-check-input" component="input" type="checkbox" name="isGross" />
                                <label className="form-check-label" htmlFor="isGross">z VAT?</label>
                            </div>
                        </div>
                        <div className="form-group">
                            <label htmlFor="vatAmmountDeduction">Odliczenie VAT</label>
                            <Field className="form-control" component="input" type="number" placeholder="Kwota VAT do odliczenia z faktur kosztowych" name="vatAmmountDeduction" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="incomeCosts">Koszty</label>
                            <Field className="form-control" component="input" type="number" placeholder="Koszty uzyskania przychodu netto" name="incomeCosts" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="previusMonthsIncomes">Przychody</label>
                            <Field className="form-control" component="input" type="number" placeholder="Przychód z poprzednich miesięcy netto" name="previusMonthsIncomes" />
                        </div>
                        <div className="form-group">
                            <div className="form-check ">
                                <Field className="form-check-input" component="input" type="checkbox" name="isMedicalInsurance" />
                                <label className="form-check-label" htmlFor="isMedicalInsurance">Ubezpieczenie zdrowotne?</label>
                            </div>
                        </div>
                        <div className="form-row">
                            <div className="form-group col">
                                <label htmlFor="accidentContributionPercentage">Składka wypadkowa (w %)</label>
                                <Field className="form-control" component="input" type="number" placeholder="minimalnie 1,67" name="accidentContributionPercentage" />
                            </div>
                            <div className="form-group col">
                                <label htmlFor="isReliefForSocialInsurance">Ulga przy składkach ZUS</label>
                                <Field className="custom-select" component="select" name="isReliefForSocialInsurance" >
                                    <option value="ff0000">Red</option>
                                </Field>
                            </div>
                            <div className="form-group col">
                                <label htmlFor="taxationForm">Forma opodatkowania</label>
                                <Field className="custom-select" component="select" name="taxationForm" >
                                    <option value="ff0000">Red</option>
                                </Field>
                            </div>
                        </div>

                        <hr />
                        <button type="button" className="btn btn-info" onClick={()=>this.props.calculate()} >Dalej</button>
                        <button type="submit" className="btn btn-success">Przelicz</button>
                    </form>
                </div>
                <div className="col-3"></div>
            </div >

        );
    }
}

const mapStateToProps = (state) => {

    return { data: state.testData ,
             calculationdata: state.selfEmployeeCalculation};
};

const mapDispatchToProps = (dispatch) => {
    return {
        calculate: bindActionCreators(CalculateSalary, dispatch)
    };
}

const SelfEmployeeCalculationLink = connect(
    mapStateToProps,
    mapDispatchToProps
)(SelfEmployeeCalculation);

export default reduxForm({
    form: 'selfEmployeeCalculation' // a unique identifier for this form
})(SelfEmployeeCalculationLink)
