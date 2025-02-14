import axios from '../utils/axios';

// קבלת כל העובדים הפעילים
export const getEmployeesService = async () => {
    const response = await axios.get("/Employee");
    return response.data;
};

// קבלת כל עובדי OS
export const getOsEmployeesService = async () => {
    const response = await axios.get("/Employee/os");
    return response.data;
};

// קבלת כל המנהלים
export const getManagersService = async () => {
    const response = await axios.get("/Employee/managers");
    return response.data;
};

// הוספת עובד חדש
export const addEmployeeService = async (employee) => {
    const response = await axios.post(`/Employee`, employee);
    return response.data;
};

// עדכון עובד לפי מזהה
export const updateEmployeeService = async (id, employee) => {
    const response = await axios.put(`/Employee/${id}`, employee);
    return response.data;
};



// מחיקת עובד לפי מזהה
export const deleteEmployeeService = async (id) => {
    await axios.delete(`/Employee/${id}`);
};

