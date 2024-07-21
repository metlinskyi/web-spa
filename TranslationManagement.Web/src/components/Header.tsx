import React, { FC } from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import logo from './../logo.svg';
import { Link } from 'react-router-dom';
interface HeaderProps {}

const Header: FC<HeaderProps> = () => (
  <Navbar expand="lg" className="bg-body-tertiary">
    <Container>
      <Navbar.Brand href="/"><img src={logo} className="App-logo" alt="logo" /></Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="me-auto">
          <Link to={"translators"}>Translators</Link>
        </Nav>
      </Navbar.Collapse>
    </Container>
  </Navbar>
);

export default Header;
