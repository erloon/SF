import React from 'react';
import { Field } from 'redux-form';

const NumberField = ({ description, name, min, help }) =>
    <React.Fragment>
        <Field
            placeholder={description}
            className="form-control"
            component="input"
            type="number"
            name={name}
            min={min}
            aria-describedby={name + 'Help'}
        />
        {help}
    </React.Fragment>


export default NumberField;