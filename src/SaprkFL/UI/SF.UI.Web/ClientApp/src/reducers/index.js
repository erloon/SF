import { combineReducers } from 'redux';
import { reducer as formReducer } from 'redux-form';
import { routerReducer } from 'react-router-redux';
import calculationReducer from './CalculationReducer';
import layoutReducer from './LayoutReducer';
import dictionariesReducer from './DictionariesReducer';

export default combineReducers({
    calculation: calculationReducer,
    routing: routerReducer,
    form: formReducer,
    layout : layoutReducer,
    calculationDictionary: dictionariesReducer
});