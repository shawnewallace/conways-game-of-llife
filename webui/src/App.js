import './App.css';
import GameHeader from './GameHeader'
import GameParameters from './GameParameters'
import GameBoard from './GameBoard'
import GameController from './GameController'
import GameModel from './GameModel'
import React from 'react';

class App extends React.Component {
	constructor(props) {
		super(props);

		this.defaultWidth = 3;
		this.defaultHeight = 4;
		this.defaultFillFactor = 0.3;
		this.defaultIsToroidal = false;

		this.startGame = this.startGame.bind(this);
		this.resetGame = this.resetGame.bind(this);

		this.state = { gameParams: new GameModel(this.defaultWidth, this.defaultHeight, this.defaultFillFactor, this.defaultIsToroidal) }

		this.initializeGameParams();
	}

	initializeGameParams() {
		this.setState(
			{
				gameParams: new GameModel(this.defaultWidth, this.defaultHeight, this.defaultFillFactor, this.defaultIsToroidal)
			}
		);
	}

	startGame(width, height, fillFactor, isTorpoidal) {
		alert(`APP -> start game(${width}, ${height}, ${fillFactor}, ${isTorpoidal} )`);
	}

	resetGame() {
		alert("APP -> reset game");

		this.initializeGameParams();
	}

	render() {
		return (
			<div className="App">

				<div className="Header">
					<GameHeader></GameHeader>
				</div>

				<div className="Parameters">
					<GameParameters
						width={this.state.gameParams.width}
						height={this.state.gameParams.height}
						fillFactor={this.state.gameParams.fillFactor}
						isToroidal={this.state.gameParams.isToroidal}
						onStartGame={this.startGame}
						onResetGame={this.resetGame}></GameParameters>
				</div>

				<div className="Controller">
					<GameController></GameController>
				</div>

				<div className="Board">
					<GameBoard></GameBoard>
				</div>

			</div>
		);
	}
}

export default App;
