import { CssBaseline, Container, createTheme, ThemeProvider } from '@mui/material';
import { useState, useEffect, useCallback } from 'react';
import { Routes, Route } from "react-router-dom"
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Header from "../common/layout/header";
import {useAppDispatch} from "../common/store/configureStore";
import NotFound from "../errors/components/NotFound";
import Login from "../account/components/login";
import Register from "../account/components/register";
import {fetchCurrentUser} from "../account/slice/thunks/fetchCurrentUser";
import { BrowserRouter as Router } from 'react-router-dom';
import { YMaps } from 'react-yandex-maps';
import Catalog from "../advertisement/components/catalog";

function App() {
    const dispatch = useAppDispatch();
    const [loading, setLoading] = useState(true);

    const initApp = useCallback(async () => {
        try {
            await dispatch(fetchCurrentUser());
        } catch (error) {
            console.log(error);
        }
    }, [dispatch])

    useEffect(() => {
        initApp().then(() => setLoading(false));
    }, [initApp])

    const [darkMode, setDarkMode] = useState(false);
    const paletteType = darkMode ? 'dark' : 'light'
    const theme = createTheme({
        palette: {
            mode: paletteType,
            background: {
                default: paletteType === 'light' ? '#eaeaea' : '#121212'
            }
        }
    })

    function handleThemeChange() {
        setDarkMode(!darkMode);
    }

    if (loading) return <h3>Initialising app...</h3>
    return (
            <ThemeProvider theme={theme}>
                <YMaps>
                    <ToastContainer theme='colored' position='bottom-right' hideProgressBar/>
                    <CssBaseline/>
                    <Router>
                        <Header darkMode={darkMode} handleThemeChange={handleThemeChange}/>
                        <Container sx={{mt: 4}}>
                            <Routes>
                                <Route path="/" element={<Catalog/>}/>
                                <Route path='/login' element={<Login/>}/>
                                <Route path='/register' element={<Register/>}/>
                                <Route path="*" element={<NotFound/>}/>
                            </Routes>
                        </Container>
                    </Router>
                </YMaps>
            </ThemeProvider>
    )
}

export default App;
