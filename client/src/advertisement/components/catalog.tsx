import {Grid, Paper} from "@mui/material";
import { useEffect } from "react";
import {useAppDispatch, useAppSelector} from "../../common/store/configureStore";
import {advertisementSelectors, resetAdvertisementFilters, setAdvertisementFilters, setPageNumber} from "../slice/advertisementSlice";
import {fetchAdvertisementsAsync} from "../slice/thunks/fetchAdvertisements";
import {LoadingButton} from "@mui/lab";
import {FormProvider, useForm} from "react-hook-form";
import * as React from "react";
import PriceSlider from "../../advertisement/components/priceSlider";
import AdvertisementList from "../../advertisement/components/advertisementList";
import SelectList from "../../common/layout/selectList";
import RoomSlider from "./roomSlider";
import {fetchAdvertisementFiltersAsync} from "../slice/thunks/fetchAdvertisementFilters";
import AppPagination from "../../common/layout/appPagination";

export default function Catalog() {

    const methods = useForm({
        mode: 'all'
    });
    const advertisements = useAppSelector(advertisementSelectors.selectAll);
    const { advertisementsLoaded, filtersLoaded, filters, countries, cities, minPrice, maxPrice, metaData } = useAppSelector(state => state.catalog);
    const [countryFilterValue, setCountryFilterValue] = React.useState<string>('');
    const [cityFilterValue, setCityFilterValue] = React.useState<string>('');
    const [priceFilterValue, setPriceFilterValue] = React.useState<number[]>([20, 700]);
    const [roomFilterValue, setRoomFilterValue] = React.useState<number>(1);

    const dispatch = useAppDispatch();

    useEffect(() => {
        if (!advertisementsLoaded) dispatch(fetchAdvertisementsAsync());
    }, [advertisementsLoaded, dispatch])

    useEffect(() => {
        if (!filtersLoaded) dispatch(fetchAdvertisementFiltersAsync());
    }, [filtersLoaded, dispatch]);

    function handleSubmit(event: any) {
        event.preventDefault();
        dispatch(setAdvertisementFilters({
            country: countryFilterValue,
            city: cityFilterValue,
            rooms: roomFilterValue,
            maxPrice: priceFilterValue[1],
            minPrice: priceFilterValue[0],
        }))
    }

    function resetFilters(){
        setCountryFilterValue('');
        setCityFilterValue('');
        setPriceFilterValue([20, 700]);
        setRoomFilterValue(1);
        dispatch(resetAdvertisementFilters());

    }

    if(!filtersLoaded) {
        return <h1>Filters loading...</h1>
    }

    return (
        <FormProvider {...methods}>
            <form onSubmit={handleSubmit}>
                <Grid container columnSpacing={4} >
                    <Grid item xs={4} sx={{ml:-17, mr: 4}}>
                        <Paper sx={{ mb: 2, p: 1 }}>
                            <SelectList label="Country" items={countries} value={countryFilterValue} change={setCountryFilterValue}/>
                        </Paper>
                        <Paper sx={{ mb: 2, p: 1  }}>
                            <SelectList label="City" items={cities} value={cityFilterValue} change={setCityFilterValue}/>
                        </Paper>
                        <Paper sx={{ mb: 2, p: 1 }}>
                            <PriceSlider minPrice={minPrice} maxPrice={maxPrice} values={priceFilterValue} change={setPriceFilterValue}/>
                        </Paper>
                        <Paper sx={{ mb: 2, p: 1 }}>
                            <RoomSlider value={roomFilterValue} change={setRoomFilterValue}/>
                        </Paper>
                        <Grid
                            container
                            spacing={0}
                            direction="row"
                            alignItems="center"
                            justifyContent="center"
                        >
                            <LoadingButton type="submit">
                                CONFIRM
                            </LoadingButton>
                            <LoadingButton onClick={resetFilters}>
                                RESET
                            </LoadingButton>
                        </Grid>
                    </Grid>
                    <Grid container item xs={9}>
                        <AdvertisementList advertisements={advertisements} />
                    </Grid>
                    <Grid item xs={3} />
                    <Grid item xs={9} sx={{mb: 2, mt:2}}>
                        {metaData &&
                            <AppPagination
                                metaData={metaData}
                                onPageChange={(page: number) => dispatch(setPageNumber({pageNumber: page}))}
                            />}
                    </Grid>
                </Grid>
            </form>
        </FormProvider>
    )
}