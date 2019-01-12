import { TOGGLE_SIDEBAR } from './types';

export const toggleSidebar = (css)=>{
    return {
        type: TOGGLE_SIDEBAR,
        payload: css
    };
};