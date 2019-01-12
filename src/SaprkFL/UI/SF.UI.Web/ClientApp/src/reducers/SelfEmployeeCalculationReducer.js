import { CALCULATE_SELFEMPLOYEE_SALARY } from '../actions/types'

const initialState = { selfEmployeeCalculation: 0 };

export default (state = initialState, action) => {
  switch (action.type) {
    case CALCULATE_SELFEMPLOYEE_SALARY:
      return { ...state, selfEmployeeCalculation: action.payload }
    default:
      return state;
  }
};
