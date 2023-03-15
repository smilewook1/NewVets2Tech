import { useEffect, useState } from "react";
import Layout from './components/shared/Layout';

const App = () => {

    //1 create useState
    const [students, setStudents] = useState([])

    //2 Call Api
    useEffect(() => {
        fetch("api/student/GetStudents")
            .then(response => { return response.json() })
            .then(responseJson => { 

                setStudents(responseJson)
            })
    }, [])

    //Create div and table


    return
    (
        <Layout>
        <div className="container">
            <h1>Students</h1>
            <div className="row">
                <div className="col-sm-12">
                    <table responsive="sm">
                        <thead>
                            students.map((item) => (
                                <tr>
                                <td>{item.FirstName}</td>

                                ))
                                </tr>
                        </thead>

                    </table>
                </div>
            </div>

        </div>
        </Layout>

    )
}

export default App;
