import { GET_DICTIONARIES, GET_MONTHNAME } from "../actions/types";

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
    ],
    MonthNames: ["Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień"],
    MonthNumbers: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
}

export default (state = initialState, action) => {
    switch (action.type) {
        case GET_DICTIONARIES:
            return { ...state }
        case GET_MONTHNAME:
            return { ...state, currentMonthName: action.payload }
        default:
            return state;
    }
};