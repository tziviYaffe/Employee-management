import { createSlice } from '@reduxjs/toolkit';

export const employeesSlice = createSlice({
    name: 'employees',
    initialState: {
        employees: [],
        managers: [], 
        osEmployees: [],
    },
    reducers: {
        setEmployeesSlice: (state, action) => {
            state.employees = action.payload;
        },
        setManagersSlice: (state, action) => {
            state.managers = action.payload;
        },
        setOsEmployeesSlice: (state, action) => {
            state.osEmployees = action.payload;
        },
        addEmployeeSlice: (state, action) => {
            state.employees.push(action.payload);
        },
        deleteEmployeeSlice: (state, action) => {
            state.employees = state.employees.filter(emp => emp.id !== action.payload);
            state.managers = state.managers.filter(emp => emp.id !== action.payload);
            state.osEmployees = state.osEmployees.filter(emp => emp.id !== action.payload);
        },
        updateEmployeeSlice: (state, action) => {
            const updateArray = (array) => {
                const index = array.findIndex(emp => emp.id === action.payload.id);
                if (index !== -1) {
                    array[index] = { ...array[index], ...action.payload };
                }
            };
            updateArray(state.employees);
            updateArray(state.managers);
            updateArray(state.osEmployees);
        }
    }
});

export const { 
    setEmployeesSlice, 
    setManagersSlice,
    setOsEmployeesSlice,
    addEmployeeSlice, 
    deleteEmployeeSlice, 
    updateEmployeeSlice 
} = employeesSlice.actions;

export default employeesSlice.reducer;


