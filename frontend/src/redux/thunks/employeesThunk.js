import {
  getEmployeesService,
  getManagersService,
  getOsEmployeesService,
  addEmployeeService,
  deleteEmployeeService,
  updateEmployeeService,
} from "../../services/employee.service";

import {
  setEmployeesSlice,
  setManagersSlice,
  setOsEmployeesSlice,
  addEmployeeSlice,
  deleteEmployeeSlice,
  updateEmployeeSlice,
} from "../slices/employeesSlice";

// קריאה לקבלת כל העובדים
export const getEmployeesThunk = () => {
  return async (dispatch) => {
    try {
      const employees = await getEmployeesService();
      dispatch(setEmployeesSlice(employees));
    } catch (error) {
      console.error("Error fetching employees:", error);
    }
  };
};

// קריאה לקבלת כל המנהלים
export const getManagersThunk = () => {
  return async (dispatch) => {
    try {
      const managers = await getManagersService();
      dispatch(setManagersSlice(managers));
    } catch (error) {
      console.error("Error fetching managers:", error);
    }
  };
};

// קריאה לקבלת כל עובדי OS
export const getOsEmployeesThunk = () => {
  return async (dispatch) => {
    try {
      const osEmployees = await getOsEmployeesService();
      dispatch(setOsEmployeesSlice(osEmployees));
    } catch (error) {
      console.error("Error fetching OS employees:", error);
    }
  };
};

//קריאה להוספת עובד
export const addEmployeeThunk = (employee) => {
  return async (dispatch) => {
    try {
      const newEmployee = await addEmployeeService(employee);
      dispatch(addEmployeeSlice(newEmployee)); // מוסיף ישירות לרשימה בלי קריאה נוספת
      return { success: true };
    } catch (error) {
      console.error("Error adding employee:", error);
      return {
        success: false,
        message: error.response?.data?.message || "שגיאה בהוספת עובד",
      };
    }
  };
};

// קריאה לעדכון עובד
export const updateEmployeeThunk = (id, employee) => {
  return async (dispatch) => {
    try {
      await updateEmployeeService(id, employee);
      dispatch(updateEmployeeSlice({ id, ...employee }));
      return Promise.resolve({ success: true }); // החזרת הצלחה מפורשת
    } catch (error) {
      console.error("Error updating employee:", error);
      return Promise.resolve({
        success: false,
        message: error.response?.data?.message || "שגיאה בעדכון עובד",
      });
    }
  };
};

// קריאה למחיקת עובד
export const deleteEmployeeThunk = (id) => {
  return async (dispatch) => {
    try {
      await deleteEmployeeService(id);
      dispatch(deleteEmployeeSlice(id));
    } catch (error) {
      console.error("Error deleting employee:", error);
    }
  };
};
