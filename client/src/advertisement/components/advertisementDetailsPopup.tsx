import * as React from 'react';
import Button from '@mui/material/Button';
import Dialog, {DialogProps} from '@mui/material/Dialog';
import DialogTitle from '@mui/material/DialogTitle';
import DialogContent from '@mui/material/DialogContent';
import DialogActions from '@mui/material/DialogActions';
import Typography from '@mui/material/Typography';
import {Advertisement} from "../models/advertisement";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import Slider from "react-slick"
import {Grid,Paper} from "@mui/material";
import {Map, Placemark} from 'react-yandex-maps';
import PlaceIcon from "@mui/icons-material/Place";

interface Props{
    state : boolean;
    change(): void;
    advertisement: Advertisement
}


export default function AdvertisementDetailsPopup({state, change,advertisement}: Props) {

    const fullWidth = true;
    const [maxWidth, setMaxWidth] = React.useState<DialogProps['maxWidth']>('md');
    const settings = {
        dots: true,
        infinite: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        fade: true,
        autoplaySpeed: 3000,
        pauseOnHover: false,
    };

    const mapState = { center: [56.85, 53.2], zoom: 9 };
    const placeMark = {
        geometry: [56.848217, 53.236675]
    }

    return (
        <Grid container spacing={2}>
            <Dialog
                open={state}
                onClose={change}
                fullWidth={fullWidth}
                maxWidth={maxWidth}
                style={{ overflow: "hidden" }}
            >
                <Grid item xs={12}>
                    <Paper>
                        <DialogTitle style={{ overflow: "hidden" }}>
                            {advertisement.title}
                        </DialogTitle>
                    </Paper>
                </Grid>
                <Grid item xs={11} sx={{ml: 4, mt: 1}} >
                    <Slider {...settings}>
                        {advertisement.images.map((imgUrl:string) =>
                            <div key={advertisement.id}>
                                <img
                                     src={imgUrl}
                                     alt='flat image'
                                     style={{display: 'block', width: '100%', height: '550px'}}/>
                            </div>
                        )}
                    </Slider>
                </Grid>
                <Grid item xs={12}>
                    <DialogContent>
                        <Grid
                            container
                            spacing={0}
                            direction="column"
                            alignItems="center"
                            justifyContent="center"
                        >
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
                        </Grid>
                        <Typography variant="body1" component="div">
                            {advertisement.description}
                        </Typography>
                    </DialogContent>
                </Grid>
                <Grid item xs={12} sx={{ml:1}}>
                    <Map state={mapState} width="98%" height="400px">
                        <Placemark {...placeMark} />
                    </Map>
                    <DialogActions>
                        <Button autoFocus onClick={change}>
                            Close
                        </Button>
                    </DialogActions>
                </Grid>
            </Dialog>
        </Grid>

    );
}