import {createAsyncThunk} from "@reduxjs/toolkit";
import {User} from "../../models/user";
import AccountService from "../../services/accountService";
import {setUser} from "../accountSlice";

export const fetchCurrentUser = createAsyncThunk<User>(
    'account/fetchCurrentUser',
    async (_, thunkAPI) => {
        thunkAPI.dispatch(setUser(JSON.parse(localStorage.getItem('user')!)));
        try {
            const userDto = await AccountService.getCurrentUser();
            const {user} = userDto;
            localStorage.setItem('user', JSON.stringify(user));
            return user;
        } catch (error : any) {
            return thunkAPI.rejectWithValue({error: error.data})
        }
    },
    {
        condition: () => {
            if (!localStorage.getItem('user')){
                return false;
            }
        }
    }
)