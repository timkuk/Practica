import { FormControl, InputLabel, Select, MenuItem } from "@mui/material";

interface Props {
    label: string;
    items: string[];
    value: string;
    change(event: any): void;
}

export default function SelectList(props: Props) {
    return (
        <FormControl fullWidth>
            <InputLabel>{props.label}</InputLabel>
            <Select
                required={true}
                value={props.value}
                label={props.label}
                onChange={(item) => props.change(item.target.value)}
            >
                {props.items.map((item, index) => (
                    <MenuItem key={index} value={item}>{item}</MenuItem>
                ))}
            </Select>
        </FormControl>
    )
}