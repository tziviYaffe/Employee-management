import { configureStore } from "@reduxjs/toolkit";
import employeesReducer from "./slices/employeesSlice";
import rolesReducer from "./slices/rolesSlice"; 

const store = configureStore({
  reducer: {
    employees: employeesReducer,
    roles: rolesReducer, 
  },
});

export default store;
