/* eslint-disable indent */
import './App.css';
import GameHeader from '../GameHeader/GameHeader';
import GameParameters from '../GameParameters/GameParameters';
// import GameBoard from '../GameBoard/GameBoard'
// import GameController from '../GameController/GameController'
// import GameModel from '../../GameModel'
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

		this.state = {
			width: this.defaultWidth,
			height: this.defaultHeight, 
			fillFactor: this.defaultFillFactor,
			isTorpidal: this.defaultIsToroidal
		};

		this.initializeGameParams();
	}

	initializeGameParams() {
		this.setState({
			width: this.defaultWidth,
			height: this.defaultHeight,
			fillFactory: this.defaultFillFactor,
			isTorpidal: this.defaultIsToroidal
		});
	}

	startGame(width, height, fillFactor, isTorpoidal) {
		alert(`APP -> start game(${width}, ${height}, ${fillFactor}, ${isTorpoidal} )`);
	}

	resetGame() {
		alert('APP -> reset game');
		this.initializeGameParams();
	}

	render() {
		const width = this.state.width;
		const height = this.state.height;
		const fillFactor = this.state.fillFactor;
		const isToroidal = this.state.isTorpidal;

		return (
			<div className="App">

				<div className="Header box">
					<GameHeader></GameHeader>
				</div>

				<div className="Parameters box">
					<GameParameters
						width={width}
						height={height}
						fillFactor={fillFactor}
						isToroidal={isToroidal}
						onStartGame={this.startGame}
						onResetGame={this.resetGame}></GameParameters>
				</div>

				{/* <div className="Controller box">
					<GameController></GameController>
				</div>

				<div className="Board box">
					<GameBoard></GameBoard>
				</div> */}

			</div>
		);
	}
}

export default App;
