import React from 'react';
import { Well } from 'react-bootstrap';
import GameParams from './GameParams';
import GameControl from './GameControl';

export default class Game extends React.Component {
  render() {
    return (
      <Well>
        <GameParams />
        <hr />
        <GameControl />
      </Well>
    );
  }
}
