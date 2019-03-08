import React from 'react';

const HelpField = ({ helpText, id }) =>
    <small id={id} className="form-text text-muted">{helpText}</small>

export default HelpField;