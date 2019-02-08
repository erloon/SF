import { CALCULATE_MONTHLY_SALARY, SET_CALCULATION_TYPE, CALCULATE_YEARLY_SALARY } from './types'
import calculation from '../apis/calculation'

export const calculateMonthlySalary = (formValues) => {
    return async (dispatch, getState) => {
        const response = await calculation.post('/api/Calculations/SelfEmployeeCalculation', { ...formValues });
        dispatch({ type: CALCULATE_MONTHLY_SALARY, payload: response.data });
    };
}

export const calculateYearlySalary = (formValues) => {
    return async (dispatch, getState) => {
        const response = await calculation.post('/api/Calculations/YearlySelfEmployeeCalculation', { ...formValues });
        dispatch({ type: CALCULATE_YEARLY_SALARY, payload: response.data });
    };

}

export const setCalculationType = (type)=>{
    return {
        type: SET_CALCULATION_TYPE,
        payload: type
    }
}