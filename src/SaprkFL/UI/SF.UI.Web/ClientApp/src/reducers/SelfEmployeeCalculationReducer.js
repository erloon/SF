import {calculateSelfEmployeeSalaryType} from '../actions/SelfEmployeeCalculationActions'

const initialState = { selfEmployeeCalculation:0 };

export const selfEmployeeCalculationReducer = (state, action) => {
    state = state || initialState;
  
    if (action.type === calculateSelfEmployeeSalaryType) {
      debugger;
      return {
        ...state,
        selfEmployeeCalculation: action.payload,
      };
    }
  
    return state;
  };

  export const testReducer = (state,dispatch)=>{
    return [
      {title: "dssdsd", du:"11"},
      {title: "dssdsd", du:"11"},
      {title: "dssdsd", du:"11"}
    ];
  }