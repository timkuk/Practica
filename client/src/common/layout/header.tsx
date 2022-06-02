import { AppBar, Toolbar, Typography, Switch, List, ListItem, IconButton, Badge, Box } from '@mui/material';
import { NavLink } from 'react-router-dom';
import { useAppSelector } from '../store/configureStore';
import SignInMenu from "../../account/components/signInMenu";

interface Props {
    darkMode: boolean;
    handleThemeChange: () => void;
}

const rightLinks = [
    {title: 'login', path: '/login'},
    {title: 'register', path: '/register'}
]

const navStyles = {
    color: 'inherit',
    textDecoration: 'none',
    typography: 'h6',
    '&:hover': {
        color: 'grey.500'
    },
    '&.active': {
        color: 'text.secondary'
    }
}

export default function Header({darkMode, handleThemeChange}: Props) {
    const {user} = useAppSelector(state => state.account);

    return (
        <AppBar position='static' sx={{mb: 4}}>
            <Toolbar sx={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>

                <Box display='flex' alignItems='center'>
                    <Typography variant='h6' component={NavLink} to='/' sx={navStyles}>
                        BookIt
                    </Typography>
                    <Switch checked={darkMode} onChange={handleThemeChange}/>
                </Box>

                <List sx={{display: 'flex'}}>
                    {user &&
                        <ListItem
                            component={NavLink}
                            to={'/favourite'}
                            sx={navStyles}
                        >
                            FAVOURITES
                        </ListItem>
                    }
                </List>
                <Box display='flex' alignItems='center'>
                    {user ? (<SignInMenu/>) : (
                        <List sx={{display: 'flex'}}>
                            {rightLinks.map(({title, path}) => (
                                <ListItem
                                    component={NavLink}
                                    to={path}
                                    key={path}
                                    sx={navStyles}
                                >
                                    {title.toUpperCase()}
                                </ListItem>
                            ))}
                        </List>
                    )}
                </Box>
            </Toolbar>
        </AppBar>
    )
}