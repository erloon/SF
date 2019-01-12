import { TOGGLE_SIDEBAR } from '../actions/types'
const initialState = {
    sidebarCss:''
}

export default (state = {initialState}, action) => {
    switch (action.type) {
      case TOGGLE_SIDEBAR:
        return { ...state, sidebarCss: action.payload }
      default:
        return state;
    }
  };