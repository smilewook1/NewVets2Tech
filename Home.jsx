import React from 'react'
import { Link } from 'react-router-dom'
import { Button, FormControlLabel, Typography, Box, Container, Grid } from '@mui/material/';

export default function Home() {
  return <Container component="main" maxWidth="xs">

    <Box sx={{ mt: 3 }}>
      <Grid container spacing={2}>
        <Typography component="h1" variant="h5">
          <Grid item xs={12}>
            <Button size="small">
              <Link to="/signin">Sign In</Link>
            </Button>
          </Grid>
          <Grid item xs={12}>
            <Button size="small">
              <Link to="/signup">Sign Up</Link>
            </Button>
          </Grid>
        </Typography>
      </Grid>
    </Box>
  </Container>

}
