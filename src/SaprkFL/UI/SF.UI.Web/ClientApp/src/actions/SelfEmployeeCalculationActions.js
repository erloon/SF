import { CALCULATE_SELFEMPLOYEE_SALARY } from '../actions/types'
import calculation from '../apis/calculation'

export const calculateSalary = (formValues) => {
    return async (dispatch, getState) => {
        debugger;
        //const { userId } = getState().auth;
        const response = await calculation.post('/api/Calculations/SelfEmployeeCalculation', { ...formValues });
        dispatch({ type: CALCULATE_SELFEMPLOYEE_SALARY, payload: response.data });
    };

}