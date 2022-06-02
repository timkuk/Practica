import { Button, Fade, MenuItem, Menu } from "@mui/material";
import React from "react";
import { useAppDispatch, useAppSelector } from "../../common/store/configureStore";
import { useNavigate } from "react-router-dom";
import {signOut} from "../slice/accountSlice";

export default function SignInMenu(){

    const dispatch = useAppDispatch();
    const {user} = useAppSelector(state => state.account);
    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);
    const handleClick = (event: any) => {
        setAnchorEl(event.currentTarget);
    };
    const handleClose = () => {
        setAnchorEl(null);
    };
    const nav = useNavigate();

    return (
        <>
            <Button onClick={handleClick} color='inherit' sx={{typography: 'h6'}}>
                {user?.email}
            </Button>
            <Menu
                anchorEl={anchorEl}
                open={open}
                onClose={handleClose}
                TransitionComponent={Fade}>
                <MenuItem onClick={() =>  {
                    dispatch(signOut());
                    nav('/login');
                }}>Logout</MenuItem>
            </Menu>
        </>
    );
}