import React, {useState} from 'react'
import {TextField, Checkbox, Button, FormControlLabel, Typography, Box, Container, Grid} from '@mui/material/'
export default function CreateProfile(){
  const handleChange = (e) =>{
  }
  
  const handleSubmit = (e) =>{
  }


  
  return (
    <Container component="main" maxWidth="xs">

    <Box onSubmit={handleSubmit}>
      <TextField type="text"
        required
        name="firstName"
        placeholder="First Name"
        onChange={handleChange}>
      </TextField>
      <TextField type="text"
        required
        name="lastName"
        placeholder="Last Name"
        onChange={handleChange}>
      </TextField>
      
      <TextField type="text"
        required
        name="email"
        placeholder="Email address"
        onChange={handleChange}>
      </TextField>
      
      <TextField type="text"
        required
        name="password"
        placeholder="password"
        onChange={handleChange}>
      </TextField>
      
      <Button type="submit"
              > sign up
      </Button>
    </Box>
    </Container>)
}
