import Card from "react-bootstrap/Card";

function StudentListCard(props) {
    return (    
        <Card>
            <Card.Img variant="top" src={props.imageUrl} />
            <Card.Body>
                <Card.Title>{props.firstName}{props.lastName}</Card.Title>
                <Card.Text>
                    <b>About:</b> {props.about}
                </Card.Text>
            </Card.Body>
        </Card>
    );
}

export default StudentListCard;