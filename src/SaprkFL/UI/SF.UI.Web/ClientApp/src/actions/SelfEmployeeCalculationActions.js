export const calculateSelfEmployeeSalaryType = "CALCULATE_SELFEMPLOYEE_SALARY";

export const actionCreators = {
    calculateSelfEmployeeSalary: selfEmployeeCalculation => async (dispatch, getState) => {
        debugger;

        return {
            type: "CALCULATE_SELFEMPLOYEE_SALARY",
            payload: "565656565"
        };
    }

};

export const CalculateSalary = data=>{
    return {
        type: "CALCULATE_SELFEMPLOYEE_SALARY",
        payload: "565656565"
    };
}