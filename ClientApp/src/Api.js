export function fetchStudents() {
    return fetch("api/students", { method: "get" })
        .then(response => response.json());
}


    //     // fetch("api/students", { method: "get" })
    //     //     .then(response => response.json)
    //     //     .then(responseJson => { 

    //     //         setStudents(responseJson)
    //     //     })
