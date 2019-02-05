import React from 'react';
import { Field } from 'redux-form';

const CalculationFormNumberField = ({ label, name, min, helpText }) =>
    <div className="form-group row">
        <label className="col-sm-2 col-form-label" htmlFor={name}>{label}</label>
        <div className="col-sm-10 col-md-8 col-lg-6">
            <Field
                className="form-control"
                component="input"
                type="number"
                name={name}
                min={min}
                aria-describedby={name + 'Help'}
            />
            <small id={name + 'Help'} className="form-text text-muted">{helpText}</small>
        </div>
    </div>


export default CalculationFormNumberField;