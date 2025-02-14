import { getRolesService } from '../../services/roles.service';
import { setRolesSlice } from '../slices/rolesSlice';

export const getRolesThunk = () => {
    return async (dispatch) => {
        try {
            const roles = await getRolesService();
            dispatch(setRolesSlice(roles));
        } catch (error) {
            console.error("Error fetching roles:", error);
        }
    };
};
