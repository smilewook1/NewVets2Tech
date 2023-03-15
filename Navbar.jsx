import React from 'react';
import PropTypes from 'prop-types';
import {TextField, Checkbox, Button, FormControlLabel, Typography, Box, Container, Grid, Toolbar} from '@mui/material/';
import { Link } from 'react-router-dom'

export default function Navbar(){
  return(
    <React.Fragment>
    <Toolbar sx={{ borderBottom: 1, borderColor: 'divider' }}>
        <Typography
          component="h1"
          variant="h5"
          color="inherit"
          align="center"
          noWrap
          sx={{ flex: 1 }}
        >
          <Link to='/'>
            Admin
          </Link>
        </Typography>
      
      <Button variant="outlined" size="small">
          <Link to='/registration'>
            Registration
          </Link>
        </Button>
        <Button variant="outlined" size="small">
          <Link to='/profile'>
          Create Profile
            </Link>
        </Button>
      <Button variant="outlined" size="small">
        <Link to='/data'>
          Edit Data
          </Link>
        </Button>
      </Toolbar>
      </React.Fragment>
    )
}
