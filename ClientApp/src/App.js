
import './App.css';// this is referencing App.css so all the css in App.css will be applied to this file
import 'bootstrap/dist/css/bootstrap.min.css'  //css for bootstrap link to use this
import './images/Logoheader.png'
import { BrowserRouter, Routes, Route } from "react-router-dom"; //this is using BrowserRouter, Routes,Route, Link from react-router-dom package

import { About } from './components/About';//this is referencing About.js from the folder components 
import { Contact } from './components/Contact';//this is referencing Contact.js from the folder components
import { StudentRegister } from './components/StudentRegister';//this is referencing StudentRegister.js from the folder components
import { StudentLogin } from './components/StudentLogin';//this is referencing StudentLogin.js from the folder components
import { ForgotPassword } from './components/ForgotPassword';//this is referencing ForgotPassword.js from the folder components
import { CompanyRegister } from './components/CompanyRegister';//this is referencing CompanyRegister.js from the folder components
import { CompanyLogin } from './components/CompanyLogin';//this is referencing CompanyLogin.js from the folder components
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import React, { useEffect, useState } from "react";



/*export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Routes>
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
        </Routes>
      </Layout>
    );
  }
}*/


function App() {

    const [students, setStudents] = useState([]);

    useEffect(() => {
        fetch("api/student")
            .then((response) => {
                return response.json();
            })
            .then(data => {
                setStudents(data);
            })
    }, []);



    return (
        <><BrowserRouter>{/*this is to keep your UI in sync with the URL by using Route  */}
            <div>
                <Layout>

                <br></br>
                <Routes>


                    <Route path="/About" element={<About />} />{/*This is how you create a path for the other pages so that it will correctly navigation to the page in the navbar */}
                    <Route path="/Contact" element={<Contact />} />

                    <Route path="/StudentRegister" element={<StudentRegister />} />
                    <Route path="/StudentLogin" element={<StudentLogin />} />
                    <Route path="/ForgotPassword" element={<ForgotPassword />} />
                    <Route path="/CompanyRegister" element={<CompanyRegister />} />
                    <Route path="/CompanyLogin" element={<CompanyLogin />} />

                    <Route path="/" element={<Home />} />

                    </Routes>
                </Layout>
            </div>
            <div>
            </div>
        </BrowserRouter>




            <main>
                {(students != null) ?
                    students.map((index, id) => (
                        <h3 key={id}>
                            Id: {index.internalId}, Email: {index.email}, First Name: {index.firstName}, Last Name: {index.lastName}, Password: {index.passwordHash}
                        </h3>
                    ))
                    :
                    <div>Loading</div>}
            </main></>
    );
}

export default App;