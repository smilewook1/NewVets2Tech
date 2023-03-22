import React, { useState } from 'react';//importing useState from react package
import Axios from 'axios' //import axios package to allow a student to be added
import './Home.css';

import { Button, Form, FormGroup, Label, Input } from 'reactstrap'; //using Button,Form,FormGroup, Label and Input from reactstrap package.
// so that you can use these function in your code



export const StudentRegister = () => {

    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const addStudent = () => {
        Axios.post('http://localhost:3010/create', {
            email: email,
            password: password,
        }).then(() => {
            console.log("success");
        });
    };


    return (
        <Form className="login-form">

            <div className='cool'>
                <h2>Sign Up</h2>{/* This is the title for the Student Register form */}
            </div>


            <br />

            <FormGroup>
                <Label>Email (Personal Email)</Label>
                <Input type="email" placeholder="Email"
                    onChange={(event) => {
                        setEmail(event.target.value);
                    }}
                />
            </FormGroup>
            <FormGroup>
                <Label>Password</Label>
                <Input type="password" placeholder="Password"
                    onChange={(event) => {
                        setPassword(event.target.value);
                    }}
                />
            </FormGroup>
            <br />
            <div className='center'>
                <Button onClick={addStudent}> Register
                </Button>
            </div>




            <br></br>
            <br></br>

        </Form>


    );
}