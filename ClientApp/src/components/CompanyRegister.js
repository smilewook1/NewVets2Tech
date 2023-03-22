import React, { useState } from 'react';
import Axios from 'axios'

import { Link } from 'react-router-dom';

import { Button, Form, FormGroup, Label, Input }
    from 'reactstrap';


export const CompanyRegister = () => {

    const [CompanyName, setCompanyName] = useState("");
    const [CompanyOverview, setCompanyOverview] = useState("");
    const [ContactNames, setContactNames] = useState("");
    const [Phonenumber, setPhonenumber] = useState("");
    const [Email, setEmail] = useState("");

    const addCompany = () => {
        Axios.post('http://localhost:3010/companies', {
            CompanyName: CompanyName,
            CompanyOverview: CompanyOverview,
            ContactNames: ContactNames,
            Phonenumber: Phonenumber,
            Email: Email,
        }).then(() => {
            console.log("successful");
        });
    };
    return (
        <Form className="login-form">

            <div className='cool'>
                <h2>Company Sign up</h2>
            </div>


            <br />


            <FormGroup>
                <Label>Company Name:</Label>
                <Input type="text" placeholder="CompanyName"
                    onChange={(event) => {
                        setCompanyName(event.target.value);
                    }}
                />
            </FormGroup>
            <FormGroup>
                <Label>Company Overview:</Label>
                <Input type="text" placeholder="CompanyOverview"
                    onChange={(event) => {
                        setCompanyOverview(event.target.value);
                    }}
                />
            </FormGroup>
            <FormGroup>
                <Label>Contact Names(Recruiter or Miltary Relations):</Label>
                <Input type="text" placeholder="ContactNames"
                    onChange={(event) => {
                        setContactNames(event.target.value);
                    }}
                />
            </FormGroup>
            <FormGroup>
                <Label>Phone number:</Label>
                <Input type="tel" placeholder="Phone number"
                    onChange={(event) => {
                        setPhonenumber(event.target.value);
                    }}
                />
            </FormGroup>
            <FormGroup>
                <Label>Email:</Label>
                <Input type="email" placeholder="Email"
                    onChange={(event) => {
                        setEmail(event.target.value);
                    }}
                />
            </FormGroup>
            <br />
            <Button onClick={addCompany} className="btn-dark" bsStyle="primary" bsSize="large" block >
                Sign up
            </Button>

            <br></br>

            <Link to="/CompanyLogin"><Button>
                Go to Company Login
            </Button>
            </Link>

        </Form>


    );
}