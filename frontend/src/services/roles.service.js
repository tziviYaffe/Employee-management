import axiosInstance from "../utils/axios"; //  שימוש ב-axiosInstance

export const getRolesService = async () => {
    const response = await axiosInstance.get("/Role");
    return response.data;
};
