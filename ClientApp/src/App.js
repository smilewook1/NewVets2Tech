import { useEffect, useState } from "react";
import Layout from './components/Layout';
import StudentList from "./components/StudentList";
import { fetchStudents } from "./Api";

export default function App() {
    // create initial state
    const [students, setStudents] = useState([])
    // load state
    // note: empty array only runs once!
    useEffect(() => {
        setStudents([]);
        fetchStudents()
            .then(setStudents)
            .catch(err => console.error(err));
    }, []);

    //Create div and table
    return (
        <Layout title="Washington Vets 2 Tech">
            {   
                <StudentList items={students}></StudentList>
            }
        </Layout>
    );
}
