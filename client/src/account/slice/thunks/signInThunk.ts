import {createAsyncThunk} from "@reduxjs/toolkit";
import {User} from "../../models/user";
import {FieldValues} from "react-hook-form";
import AccountService from "../../services/accountService";

export const signInUser = createAsyncThunk<User, FieldValues>(
    'account/signInUser',
    async (data, thunkAPI) => {
        try {
            const userDto = await AccountService.login(data);
            localStorage.setItem('user', JSON.stringify(userDto));
            return userDto;
        } catch (error : any) {
            return thunkAPI.rejectWithValue({error: error.data})
        }
    }
)