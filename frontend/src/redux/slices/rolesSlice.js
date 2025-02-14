import { createSlice } from '@reduxjs/toolkit';

export const rolesSlice = createSlice({
    name: 'roles',
    initialState: {
        roles: [],
    },
    reducers: {
        setRolesSlice: (state, action) => {
            state.roles = action.payload;
        }
    }
});

export const { setRolesSlice } = rolesSlice.actions;
export default rolesSlice.reducer;
