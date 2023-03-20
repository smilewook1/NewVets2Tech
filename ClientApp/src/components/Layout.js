import Navbar from "react-bootstrap/Navbar";
import Container from "react-bootstrap/Container";

function Layout(props) {
    return (
        <div>
            <Navbar bg="primary" variant="dark" expand="lg">
                <Container>
                    <Navbar.Brand>{props.title}</Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                </Container>
            </Navbar>
            <Container>{props.children}</Container>
        </div>
    );
}

export default Layout;