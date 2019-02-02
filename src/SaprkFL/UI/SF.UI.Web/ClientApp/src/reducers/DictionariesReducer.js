import { GET_DICTIONARIES } from "../actions/types";

const initialState = {
        InsuranceContributionForm: [
            {
                name: "Brak",
                value: 1
            },
            {
                name: "Preferencyjna",
                value: 2
            },
            {
                name: "Normalna",
                value: 3
            }
        ],
        TxationForm: [
            {
                name: "Skala podatkowa",
                value: 1
            },
            {
                name: "Liniowy",
                value: 2
            }]
}

export default (state = initialState , action) => {
    switch (action.type) {
        case GET_DICTIONARIES:
            return { ...state }
        default:
            return state;
    }
};