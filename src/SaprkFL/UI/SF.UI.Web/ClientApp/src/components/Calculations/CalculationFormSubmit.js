import React from 'react';
import { Field } from 'redux-form';

const CalculationFormSubmit = ({ description }) =>
    <div className="form-group row">
        <div className="col-sm-2"></div>
        <div className="col-sm-10 col-md-8 col-lg-6">
            <button type="submit" className="btn btn-info btn-sm btn-block active">{description}</button>
        </div>
    </div>

export default CalculationFormSubmit;