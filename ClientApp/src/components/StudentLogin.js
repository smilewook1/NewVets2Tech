import React from 'react';

import './Home.css';

import { Button, Form, FormGroup, Label, Input }
    from 'reactstrap';



export const StudentLogin = () => {


    return (
        <Form className="login-form">


            <div className='cool'>
                <h2>Student Login</h2>
            </div>

            <br />

            <FormGroup>
                <Label>Email (Personal Email)</Label>
                <Input type="email" placeholder="Email"
                />
            </FormGroup>
            <FormGroup>
                <Label>Password</Label>
                <Input type="password" placeholder="Password"

                />
            </FormGroup>
            <br />
            <Button className="btn-dark" bsStyle="primary" bsSize="large" block >
                Sign in
            </Button>

            <br></br>

            <div className="text-center">
                <a href="/ForgotPassword">Forgot Password</a>
            </div>



        </Form>


    );
}