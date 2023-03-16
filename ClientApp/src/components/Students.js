import { Row } from "react-bootstrap";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import { useEffect, useState } from "react";
import axios from "axios";

function AllStudents() {
    const [students, setStudents] = useState([]);

    useEffect(() => {
        axios.get("https://localhost:38425/Students").then((response) => {
            setStudents((data) => {
                return response.data;
            });
        });
    }, []);

    return (
        <>
            <Row md={3} className="g-4 mt-1">
                {Students.map((e) => {
                    return (
                        <Col key={sv.id}>
                            <Card>
                                <Card.Img variant="top" src={e.imageUrl} />
                                <Card.Body>
                                    <Card.Title>{e.FirstName}{sv.LastName}</Card.Title>
                                    <Card.Text>
                                        <b>About:</b> {e.About}
                                    </Card.Text>
                                </Card.Body>
                            </Card>
                        </Col>
                    );
                })}
            </Row>
        </>
    );
}

export default AllStudents;