import {createAsyncThunk} from "@reduxjs/toolkit";
import {Advertisement} from "../../models/advertisement";
import StateConstants from "../../../common/constants/stateConstants";
import AdvertisementService from "../../services/advertisementService";

export const fetchAdvertisementAsync = createAsyncThunk<Advertisement,  string>(
    StateConstants.Advertisement.PENDING,
    async (advertisementId : string, thunkAPI) => {
        try {
            const response = await AdvertisementService.fetchAdvertisementDetails(advertisementId);
            return response;
        } catch (error : any) {
            return thunkAPI.rejectWithValue({error: error.data});
        }
    }
)