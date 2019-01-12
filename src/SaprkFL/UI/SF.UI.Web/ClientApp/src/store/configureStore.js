import { applyMiddleware, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { routerMiddleware } from 'react-router-redux';
import reducers from '../reducers';
const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;


export default function configureStore(history, initialState) {
  const middleware = [
    thunk,
    routerMiddleware(history)
  ];

  return createStore(
    reducers,
    initialState,
    composeEnhancers(applyMiddleware(...middleware))
  );
}
