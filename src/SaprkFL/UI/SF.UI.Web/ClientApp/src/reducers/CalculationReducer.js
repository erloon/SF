import { CALCULATE_MONTHLY_SALARY, SET_CALCULATION_TYPE, CALCULATE_YEARLY_SALARY } from '../actions/types'

const initialState = { calculationResult: {}, calculationType:'monthly' };

export default (state = initialState, action) => {
  switch (action.type) {
    case CALCULATE_MONTHLY_SALARY:
      return { ...state, calculationResult: action.payload }
    case CALCULATE_YEARLY_SALARY:
      return { ...state, calculationResult: action.payload }
    case SET_CALCULATION_TYPE:
      return { ...state, calculationType: action.payload }
    default:
      return state;
  }
};
