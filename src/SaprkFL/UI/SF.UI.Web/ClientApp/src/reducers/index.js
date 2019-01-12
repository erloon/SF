import { combineReducers } from 'redux';
import { reducer as formReducer } from 'redux-form';
import { routerReducer } from 'react-router-redux';
import SelfEmployeeCalculationReducer from './SelfEmployeeCalculationReducer';

export default combineReducers({
    selfEmployeeCalculation: SelfEmployeeCalculationReducer,
    routing: routerReducer,
    form: formReducer
});