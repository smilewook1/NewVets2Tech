import React, {useState} from 'react';
import {TextField, Checkbox, Button, FormControlLabel, Typography, Box, Container, Grid} from '@mui/material/';

const Signup = () => {
  
    return (
        <Container component="main" maxWidth="xs">
            <Box
                sx={{
                    marginTop: 8,
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                }}
            >

                <Typography component="h1" variant="h5">
                    Sign up
                </Typography>
                <Box sx={{ mt: 3 }}>
                    <Grid container spacing={2}>
                        <Grid item xs={6}>
                            <TextField
                                autoComplete="given-name"
                                name="firstName"
                                required
                                fullWidth
                                id="firstName"
                                label="First Name"
                                autoFocus />
                        </Grid>
                        <Grid item xs={6}>
                            <TextField
                                required
                                fullWidth
                                id="lastName"
                                label="Last Name"
                                name="lastName"
                                autoComplete="family-name" />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                label="email address"
                                required
                                fullWidth
                                name="email"
                                autoComplete="email" />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                label="password"
                                type="password"
                                required
                                fullWidth
                                name="password"
                                autoComplete="current-password" />
                        </Grid>
                    </Grid>

                    <Button
                        type="submit"
                        fullWidth
                        variant="contained" sx={{ mt: 3, mb: 2 }}> sign up
                    </Button>
                </Box>
            </Box>
        </Container>
    );
}

export default Signup;
