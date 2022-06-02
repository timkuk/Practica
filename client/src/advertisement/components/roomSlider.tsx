import * as React from 'react';
import Box from '@mui/material/Box';
import Slider from '@mui/material/Slider';
import Typography from "@mui/material/Typography";

const marks = [
    {
        value: 1,
        label: '1',
    },
    {
        value: 2,
        label: '2',
    },
    {
        value: 3,
        label: '3',
    },
    {
        value: 4,
        label: '4+',
    },
];

function valuetext(value: number) {
    return `${value}`;
}

function valueLabelFormat(value: number) {
    return marks.findIndex((mark) => mark.value === value) + 1;
}

interface Props {
    change(event: any): void,
    value: number
}

export default function RoomSlider({change, value}: Props) {
    const handleChange = (event: any, newValue:  any) => {
        change(newValue);
    };

    return (
        <Box sx={{ width: '100%', pr: 2 }}>
            <Typography id="input-slider" gutterBottom>
                Rooms
            </Typography>
            <Slider
                key={value}
                aria-label="Restricted values"
                defaultValue={value}
                valueLabelFormat={valueLabelFormat}
                getAriaValueText={valuetext}
                valueLabelDisplay="auto"
                marks={marks}
                min={1}
                max={4}
                sx={{ml: 1}}
                onChange={handleChange}
            />
        </Box>
    );
}
