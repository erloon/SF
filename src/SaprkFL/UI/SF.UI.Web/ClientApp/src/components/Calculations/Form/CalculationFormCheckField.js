import React from 'react';
import { Field } from 'redux-form';

const CalculationFormCheckField = ({label, name}) =>
<div className="form-group row">
    <div className="col-sm-2"></div>
    <div className="col-sm-10 col-md-8 col-lg-6">
        <div className="form-check">
            <Field 
                className="form-check-input" 
                component="input" 
                type="checkbox" 
                name={name} />
            <label className="form-check-label" htmlFor={name}>{label}</label>
        </div>
    </div>
</div>


export default CalculationFormCheckField;