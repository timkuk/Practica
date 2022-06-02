import {createAsyncThunk} from "@reduxjs/toolkit";
import {Advertisement} from "../../models/advertisement";
import {RootState} from "../../../common/store/configureStore";
import AdvertisementService from "../../services/advertisementService";
import CommonConstants from "../../../common/constants/commonConstants";
import StateConstants from "../../../common/constants/stateConstants";
import {Filters} from "../../models/filters";
import {setMetaData} from "../advertisementSlice";

function getAxiosParams(filters: Filters) {
    const params = new URLSearchParams();

    params.append('pageNumber', filters.pageNumber.toString());
    params.append('pageSize', filters.pageSize.toString());

    if (filters.city.length > 0) {
        params.append(CommonConstants.COUNTRIES, filters.country.toString());
    }

    if (filters.city.length > 0) {
        params.append(CommonConstants.CITIES, filters.city.toString());
    }

    if (filters.maxPrice > 0) {
        params.append(CommonConstants.MAX_PRICE, filters.maxPrice.toString());
    }

    if (filters.minPrice > 0) {
        params.append(CommonConstants.MIN_PRICE, filters.minPrice.toString());
    }

    if (filters.rooms > 0) {
        params.append(CommonConstants.ROOMS, filters.rooms.toString());
    }
    return params;
}
export const fetchAdvertisementsAsync = createAsyncThunk<Advertisement[], void, { state: RootState }>(
    StateConstants.Advertisements.PENDING,
    async (_, thunkAPI) => {
        const params = getAxiosParams(thunkAPI.getState().catalog.filters);
        try {
            const response = await AdvertisementService.fetchAdvertisements(params);
            thunkAPI.dispatch(setMetaData(response.metaData));
            return response.items;
        } catch (error : any) {
            return thunkAPI.rejectWithValue({error: error.data});
        }
    }
)