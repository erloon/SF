import { combineReducers } from 'redux';
import { reducer as formReducer } from 'redux-form';
import { routerReducer } from 'react-router-redux';
import selfEmployeeCalculationReducer from './SelfEmployeeCalculationReducer';
import layoutReducer from './LayoutReducer';

export default combineReducers({
    selfEmployeeCalculation: selfEmployeeCalculationReducer,
    routing: routerReducer,
    form: formReducer,
    layout : layoutReducer
});