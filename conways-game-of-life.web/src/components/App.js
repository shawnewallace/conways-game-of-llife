import React from 'react';
import Header from './Header';
import Game from './Game';

export default class App extends React.Component {
  render() {
    return (
      <div>
        <Header />

        <Game />
      </div>
    );
  }
}
