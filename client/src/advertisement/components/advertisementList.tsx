import { Grid } from "@mui/material";
import ProductCardSkeleton from "../../common/layout/cardSkeleton";
import {useAppSelector} from "../../common/store/configureStore";
import {Advertisement} from "../models/advertisement";
import AdvertisementCard from "./advertisementCard";

interface Props {
    advertisements: Advertisement[];
}

export default function AdvertisementList({ advertisements }: Props) {
    const { advertisementsLoaded } = useAppSelector(state => state.catalog);
    return (
        <Grid container spacing={3}>
            {advertisements.map(advertisement => (
                    <Grid item xs={4} key={advertisement.id} id={advertisement.id} sx={{ display: 'flex'}}>
                {!advertisementsLoaded ? (
                    <ProductCardSkeleton />
                ) : (
                    <AdvertisementCard advertisement={advertisement} />
                    )}
                    </Grid>
            ))}
        </Grid>
    )
}