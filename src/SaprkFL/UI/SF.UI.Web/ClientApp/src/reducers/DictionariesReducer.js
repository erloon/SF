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
        ],
        CalcualtionDefaultValues: {
            salary: 0,
            isGross: false,
            vatAmmountDeduction: 0,
            incomeCosts: 0,
            previusMonthsIncomes: 0,
            isMedicalInsurance: false,
            accidentContributionPercentage: 1.67,
            insuranceContributionForm: 1,
            taxationForm: 1
        }
}

export default (state = initialState , action) => {
    switch (action.type) {
        case GET_DICTIONARIES:
            return { ...state }
        default:
            return state;
    }
};