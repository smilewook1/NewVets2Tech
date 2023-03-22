import React from 'react';

import { Link } from 'react-router-dom';

import { Button, Form, FormGroup, Label, Input }
    from 'reactstrap';



export const CompanyLogin = () => {
    return (
        <Form className="login-form">

            <div className='cool'>
                <h2>Company Login</h2>
            </div>


            <br />

            <FormGroup>
                <Label>Company Name:</Label>
                <Input type="text" placeholder="CompanyName"
                />
            </FormGroup>
            <FormGroup>
                <Label>Company Overview:</Label>
                <Input type="text" placeholder="CompanyOverview"

                />
            </FormGroup>
            <FormGroup>
                <Label>Contact Names(Recruiter or Miltary Relations):</Label>
                <Input type="text" placeholder="ContactNames"

                />
            </FormGroup>
            <FormGroup>
                <Label>Phone number:</Label>
                <Input type="tel" placeholder="Phone number"

                />
            </FormGroup>
            <FormGroup>
                <Label>Email:</Label>
                <Input type="email" placeholder="Email"

                />
            </FormGroup>
            <br />
            <Button className="btn-dark" bsStyle="primary" bsSize="large" block >
                Login
            </Button>


            <br></br>

            <Link to="/"><Button>
                Go to Home Page
            </Button>
            </Link>

        </Form>


    );
}