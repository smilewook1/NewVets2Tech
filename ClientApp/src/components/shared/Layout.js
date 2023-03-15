import Navbar from "react-bootstrap/Navbar";

function Layout(props) {
    return (
        <div>
            <Navbar bg="primary" variant="dark" expand="lg">
                <Container>
                    <Navbar.Brand>Washington Vets 2 Tech</Navbar.Brand>
                    <Navbar.Toggle aria-controls="basic-navbar-nav" />
                </Container>
            </Navbar>
            <Container>{props.children}</Container>
        </div>
    );
}

export default Layout;