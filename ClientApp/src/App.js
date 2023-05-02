
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

import { Home } from './components/Home';


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




    return (
        <BrowserRouter>{/*this is to keep your UI in sync with the URL by using Route  */}

            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <a class="navbar-brand" href="/">
                    <img src="/images/Logoheader.png" width="30" height="30" alt="Logo"></img>
                </a>
                
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="/Home">Home <span class="sr-only">(current)</span></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="/About">About</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="/Contact">Contact</a>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Register/Login
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <a class="dropdown-item" href="/StudentRegister">Register</a>
                                <a class="dropdown-item" href="/StudentLogin">Login</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </nav>







            <div>



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
            </div>
            <div>
            </div>
        </BrowserRouter>
    );
}

export default App;