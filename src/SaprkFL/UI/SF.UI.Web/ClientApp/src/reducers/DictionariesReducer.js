import { GET_DICTIONARIES } from "../actions/types";

const initialState = {
        InsuranceContributionForm: [
            {
                name: "Brak - Ulga na start",
                value: 1
            },
            {
                name: "Preferencyjna składka",
                value: 2
            },
            {
                name: "Normalna",
                value: 3
            }
        ],
        TxationForm: [
            {
                name: "Skala podatkowa (18/32%)",
                value: 1
            },
            {
                name: "Liniowy (19%)",
                value: 2
            }
        ]
}

export default (state = initialState , action) => {
    switch (action.type) {
        case GET_DICTIONARIES:
            return { ...state }
        default:
            return state;
    }
};