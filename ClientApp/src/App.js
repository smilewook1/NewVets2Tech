import { useEffect, useState } from "react";
import Layout from './components/shared/Layout';
import AllStudents from "./components/Students";

const App = () => {

    import { useState } from "react";

    //1 create useState
    const [students, setStudents] = useState([])

    //2 Call Api
    useEffect(() => {
        fetch("api/Student/Get")
            .then(response => { return response.json() })
            .then(responseJson => { 

                setStudents(responseJson)
            })
    }, [])

    //Create div and table


    return
    (
        <Layout>
            <AllStudents></AllStudents>
        </Layout>

    )
}

export default App;
