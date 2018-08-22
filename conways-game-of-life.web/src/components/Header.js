import React from 'react';
import { Navbar } from 'react-bootstrap';

export default class Header extends React.Component {
  render() {
    return (
      <Navbar fixedTop fluid>
        <Navbar.Header>
          <Navbar.Brand>
            <a href="/">Conway's Game of Life</a>
          </Navbar.Brand>
        </Navbar.Header>
      </Navbar>
    );
  }
}
