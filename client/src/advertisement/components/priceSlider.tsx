import * as React from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import Slider from '@mui/material/Slider';
import MuiInput from '@mui/material/Input';
import AttachMoneyIcon from '@mui/icons-material/AttachMoney';

const Input = styled(MuiInput)`width: 50px;`;
const minDistance = 20;

interface Props {
    change(event: any): void;
    values: number[];
    minPrice: number;
    maxPrice: number;
}

export default function PriceSlider({minPrice, maxPrice, change, values}: Props) {

    const handleChange = (
        event: Event,
        newValue: number | number[],
        activeThumb: number,
    ) => {
        if (!Array.isArray(newValue)) {
            return;
        }

        if (activeThumb === 0) {
            change([Math.min(newValue[0], values[1] - minDistance), values[1]]);
        } else {
            change([values[0], Math.max(newValue[1], values[0] + minDistance)]);
        }
    };

    const handleInputMaxChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const copyArray = [...values];
        if (Number(event.target.value) === copyArray[0]){
            return change(copyArray);
        }
        copyArray[1] = Number(event.target.value);
        change(copyArray);
    };
    const handleInputMinChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const copyArray = [...values];
        if (Number(event.target.value) >= copyArray[1]){
            return change(copyArray);
        }
        copyArray[0] = Number(event.target.value);
        return change(copyArray);
    };

    return (
        <Box sx={{ width: 340 }}>
            <Typography id="input-slider" gutterBottom>
               Price per month, BYN
            </Typography>
            <Grid container spacing={2} alignItems="center">
                <Grid item>
                    <AttachMoneyIcon />
                </Grid>
                <Grid item>
                    <Input
                        value={values[0]}
                        size="small"
                        onChange={handleInputMinChange}
                        inputProps={{
                            step: 1,
                            min: minPrice,
                            type: 'number',
                            'aria-labelledby': 'input-slider',
                        }}
                    />
                </Grid>
                <Grid item xs>
                    <Slider
                        getAriaLabel={() => 'Temperature range'}
                        value={values}
                        onChange={handleChange}
                        valueLabelDisplay="auto"
                        min={minPrice}
                        max={maxPrice}
                        disableSwap
                    />
                </Grid>
                <Grid item>
                    <Input
                        value={values[1]}
                        size="small"
                        onChange={handleInputMaxChange}
                        inputProps={{
                            step: 1,
                            max: maxPrice,
                            type: 'number',
                            'aria-labelledby': 'input-slider',
                        }}
                    />
                </Grid>
            </Grid>
        </Box>
    );
}


