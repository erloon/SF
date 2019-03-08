import React from 'react';
import { Field } from 'redux-form';

const SelectField = ({name, options,help}) =>
    <React.Fragment>
            <Field
                className="form-control"
                component="select"
                name={name} >
                {options}
            </Field>
            {help}
    </React.Fragment>

    export default SelectField;