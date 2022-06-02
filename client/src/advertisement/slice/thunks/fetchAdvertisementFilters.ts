import {createAsyncThunk} from "@reduxjs/toolkit";
import AdvertisementService from "../../services/advertisementService";
import StateConstants from "../../../common/constants/stateConstants";

export const fetchAdvertisementFiltersAsync = createAsyncThunk(
    StateConstants.Filters.PENDING,
    async (_, thunkAPI) => {
        try {
            return await AdvertisementService.fetchAdvertisementFilters();
        } catch (error : any) {
            return thunkAPI.rejectWithValue({error: error.data});
        }
    }
)