import React from 'react';
import './Home.css';
import { Link } from 'react-router-dom';
import { Button, Form, FormGroup, Label, Input }
    from 'reactstrap';

export const Home = () => {

    return (
        <Form >


            <div className='cool'>
                <h2 >Wa2Vet Program</h2>
            </div>

            <br />
            <br></br>

            <div class='fun'>

                <Link to="/StudentRegister">
                    <button class="btn btn-danger btn-circle btn-xl" >
                        Student Register
                    </button>
                </Link>

                <Link to="/StudentLogin">
                    <button class="btn btn-success btn-circle btn-xl" >
                        Student Login
                    </button>
                </Link>

                <Link to="/CompanyRegister">
                    <button class="btn btn-warning btn-circle btn-xl" >
                        Company Register
                    </button>
                </Link>

                <Link to="/CompanyLogin">
                    <button class="btn btn-secondary btn-circle btn-xl" >
                        Company Login
                    </button>
                </Link>


            </div>

            <br />

        </Form>

    );

}