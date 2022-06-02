import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActions, Grid } from '@mui/material';
import {Advertisement} from "../models/advertisement";
import PlaceIcon from '@mui/icons-material/Place';
import StarOutlineIcon from '@mui/icons-material/StarOutline';
import { LoadingButton } from "@mui/lab";
import AdvertisementDetailsPopup from "./advertisementDetailsPopup";

interface Props {
    advertisement: Advertisement
}

export default function AdvertisementCard({ advertisement } : Props) {

    const [open, setOpen] = React.useState(false);

    function handleClick(event: any){
        setOpen(true);
    }

    function handleClose(){
        setOpen(false);
    }

    return (
        <>
            <Card sx={{ maxWidth: 300, height: '100%', width:'100%', display: 'flex', flexDirection: 'column'}}>
                <CardMedia
                    component="img"
                    height="180"
                    image={advertisement.images[0]}
                    alt="image"
                    sx={{maxHeight: 200}}
                />

                <Grid style={{ position: "relative" }}
                      onClick={() => console.log('hello')}>
                    <StarOutlineIcon
                        fontSize="large"
                        style={{ position: "absolute", top: "10px", right: "5px" }}
                        sx={{ "&:hover": { color: "blue", cursor: 'pointer' }}}
                    />
                </Grid>

                <CardContent sx={{flex: '1 1 auto'}}>
                    <Typography gutterBottom variant="h6" component="div">
                        {advertisement.price} BYN / month
                    </Typography>
                    <Typography gutterBottom variant="h6" component="div">
                        {advertisement.rooms} room(s) | {advertisement.livingArea} s.m.
                    </Typography>
                    <Typography  variant="body1" component="div" sx={{mb: 2}}>
                        <PlaceIcon sx={{ml: -1}}/>
                        {advertisement.location.address}
                    </Typography>
                    <Typography variant="body1" component="div">
                        {advertisement.title}
                    </Typography>
                </CardContent>
                <CardActions>
                    <LoadingButton onClick={handleClick}>
                        Details
                    </LoadingButton>
                </CardActions>
            </Card>
            {open && <AdvertisementDetailsPopup advertisement={advertisement} state={open} change={handleClose}/>}

        </>
    );
}

