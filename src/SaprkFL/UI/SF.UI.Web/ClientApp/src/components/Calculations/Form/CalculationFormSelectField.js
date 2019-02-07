import React from 'react';
import { Field } from 'redux-form';

const CalculationFormSelectField  = ({label, name, options}) =>
                        <div className="form-group row">
                            <label htmlFor={name} className="col-sm-2 col-form-label">{label}</label>
                            <div className="col-sm-10 col-md-8 col-lg-6">
                                <Field 
                                    className="form-control" 
                                    component="select" 
                                    name={name} >
                                        {options}
                                </Field>
                            </div>
                        </div>

export default CalculationFormSelectField;