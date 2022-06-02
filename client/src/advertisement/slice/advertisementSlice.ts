import {Advertisement} from "../models/advertisement";
import {RootState} from "../../common/store/configureStore";
import {createEntityAdapter, createSlice} from "@reduxjs/toolkit";
import StateConstants from "../../common/constants/stateConstants";
import {fetchAdvertisementsAsync} from "./thunks/fetchAdvertisements";
import {fetchAdvertisementAsync} from "./thunks/fetchAdvertisement";
import {fetchAdvertisementFiltersAsync} from "./thunks/fetchAdvertisementFilters";
import {Filters} from "../models/filters";
import {MetaData} from "../components/pagination";

interface IAdvertisementState {
    countries: [];
    cities: [];
    rooms: 0;
    maxPrice: 0;
    minPrice: 0;
    metaData: MetaData | null;
    status: string;
    filters: Filters;
    advertisementsLoaded: boolean;
    filtersLoaded: boolean;
}
const advertisementAdapter = createEntityAdapter<Advertisement>();

function initFilters() {
    return {
        country: '',
        city: '',
        rooms: 0,
        maxPrice: 0,
        minPrice: 0,
        pageNumber: 1,
        pageSize: 6
    }
}

const advertisementInitialState = advertisementAdapter.getInitialState<IAdvertisementState>({
    countries: [],
    cities: [],
    rooms: 0,
    maxPrice: 0,
    minPrice: 0,
    filters: initFilters(),
    metaData: null,
    status: 'idle',
    advertisementsLoaded: false,
    filtersLoaded: false
});

export const advertisementSlice = createSlice({
    name: 'catalog',
    initialState: advertisementInitialState,
    reducers: {
        setAdvertisementFilters: (state, action) => {
            state.advertisementsLoaded = false;
            state.filters = {...state.filters, ...action.payload };
        },
        resetAdvertisementFilters: (state) => {
            state.advertisementsLoaded = false;
            state.filters = initFilters();
        },
        setPageNumber: (state, action) => {
            state.advertisementsLoaded = false;
            state.filters = {...state.filters, ...action.payload };
        },
        setMetaData: (state, action) => {
            state.metaData = action.payload;
        },
    },
    extraReducers: (builder => {
        builder.addCase(fetchAdvertisementsAsync.pending, (state) => {
            state.status = StateConstants.Advertisements.PENDING;
        });
        builder.addCase(fetchAdvertisementsAsync.fulfilled, (state, action) => {
            advertisementAdapter.setAll(state, action.payload);
            state.status = 'idle';
            state.advertisementsLoaded = true;
        });
        builder.addCase(fetchAdvertisementsAsync.rejected, (state) => {
            state.status = 'idle';
        });
        builder.addCase(fetchAdvertisementAsync.pending, (state) => {
            state.status = StateConstants.Advertisement.PENDING;
        });
        builder.addCase(fetchAdvertisementAsync.fulfilled, (state, action) => {
            advertisementAdapter.upsertOne(state, action.payload);
            state.status = 'idle';
        });
        builder.addCase(fetchAdvertisementAsync.rejected, (state) => {
            state.status = 'idle';
        });
        builder.addCase(fetchAdvertisementFiltersAsync.pending, (state) => {
            state.status = StateConstants.Filters.PENDING;
        });
        builder.addCase(fetchAdvertisementFiltersAsync.fulfilled, (state, action) => {
            state.cities = action.payload.cities;
            state.countries = action.payload.countries;
            state.rooms = action.payload.rooms;
            state.maxPrice = action.payload.maxPrice;
            state.minPrice = action.payload.minPrice;
            state.filtersLoaded = true;
            state.status = 'idle';
        });
        builder.addCase(fetchAdvertisementFiltersAsync.rejected, (state) => {
            state.status = 'idle';
        })
    }),
})
export const advertisementSelectors = advertisementAdapter.getSelectors((state: RootState) => state.catalog);
export const { setAdvertisementFilters, resetAdvertisementFilters, setMetaData, setPageNumber } = advertisementSlice.actions;