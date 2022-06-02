import {User} from "../models/user";
import {createSlice, isAnyOf} from "@reduxjs/toolkit";
import {toast} from "react-toastify";
import {signInUser} from "./thunks/signInThunk";
import {fetchCurrentUser} from "./thunks/fetchCurrentUser";

interface AccountUser {
    user: User | null;
}

const initialState: AccountUser = {
    user: null
}

export const accountSlice = createSlice({
    name: 'account',
    initialState,
    reducers: {
        signOut: (state) => {
            state.user = null;
            localStorage.removeItem('user');
        },
        setUser: (state, action) => {
            let claims = JSON.parse(atob(action.payload.token.split('.')[1]));
            let roles = claims['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
            state.user = {...action.payload, roles: typeof(roles) === 'string' ? [roles] : roles};
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchCurrentUser.rejected,state => {
            state.user = null;
            localStorage.removeItem('user');
            toast.error('Session expired - login again');
        });
        builder.addMatcher(isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled), (state, action) =>{
            let claims = JSON.parse(atob(action.payload.token.split('.')[1]));
            let roles = claims['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
            state.user = {...action.payload, roles: typeof(roles) === 'string' ? [roles] : roles};
        });
        builder.addMatcher(isAnyOf(signInUser.rejected), (state, action) => {
            console.log(action.payload);
        });
    })
});

export const {signOut, setUser} = accountSlice.actions;