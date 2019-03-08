import React from 'react';
import { Field } from 'redux-form';

class CheckField extends React.Component {
    render() {
        const { customClass, name, description } = this.props;
        const cssClass = customClass ? customClass : "form-check";
        return (
            <div className={cssClass}>
                <Field
                    className="form-check-input"
                    component="input"
                    type="checkbox"
                    name={name} />
                <label className="form-check-label" htmlFor={name}>{description}</label></div>
        );
    }
};

export default CheckField;