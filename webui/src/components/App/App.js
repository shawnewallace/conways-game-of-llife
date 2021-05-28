/* eslint-disable indent */
import './App.css';
import GameHeader from '../GameHeader/GameHeader';
import GameParameters from '../GameParameters/GameParameters';
import GameBoard from '../GameBoard/GameBoard';
import GameController from '../GameController/GameController';
// import GameModel from '../../GameModel'
import React from 'react';
import { findAllByTestId } from '@testing-library/dom';

class App extends React.Component {
	constructor(props) {
		super(props);

		this.defaultWidth = 3;
		this.defaultHeight = 4;
		this.defaultFillFactor = 0.3;
		this.defaultIsToroidal = false;
		this.defaultAutoTick = false;

		this.startGame = this.startGame.bind(this);
		this.resetGame = this.resetGame.bind(this);
		this.tick = this.tick.bind(this);
		this.toggleAutoTick = this.toggleAutoTick.bind(this);

		this.state = {
			width: this.defaultWidth,
			height: this.defaultHeight,
			fillFactor: this.defaultFillFactor,
			isTorpidal: this.defaultIsToroidal,
			isInGame: false,
			numTicks: 0,
			population: 0,
			autoTick: this.defaultAutoTick,
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
		console.log(`APP -> start game(${width}, ${height}, ${fillFactor}, ${isTorpoidal} )`);
		this.setState({ isInGame: true });
	}

	resetGame() {
		console.log('APP -> reset game');
		this.setState({ isInGame: false });
		this.setState({ numTicks: 0 });
		this.setState({ autoTick: this.defaultAutoTick });
	}

	toggleAutoTick() {
		console.log(`Toggle Autotick ${!this.state.autoTick}`);
		this.setState(prevState => {
			return { autoTick: !prevState.autoTick }
		}, () => {
			if (this.state.autoTick) {
				this.autoTickTimer = setInterval(() => {
					this.tick();
				}, 1000);
			}
			else {
				clearInterval(this.autoTickTimer);
			}
		});
	}

	tick() {
		console.log(`TICK - ${this.state.numTicks}`);
		this.setState(prevState => {
			return { numTicks: prevState.numTicks + 1 }
		});
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
				{!this.state.isInGame &&
					<div className="Parameters box">
						<GameParameters
							width={width}
							height={height}
							fillFactor={fillFactor}
							isToroidal={isToroidal}
							onStartGame={this.startGame}
							onResetGame={this.resetGame}></GameParameters>
					</div>
				}
				{this.state.isInGame &&
					<div className="Controller box">
						<GameController
							autoTick={this.state.autoTick}
							numTicks={this.state.numTicks}
							population={this.state.population}
							onToggleAutoTick={this.toggleAutoTick}
							onTick={this.tick}
							onResetGame={this.resetGame}></GameController>
					</div>
				}

				{this.state.isInGame &&
					<div className="Board box">
						<GameBoard></GameBoard>
					</div>
				}


			</div>
		);
	}
}

export default App;
