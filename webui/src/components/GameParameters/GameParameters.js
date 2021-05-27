import React from 'react';

class GameParameters extends React.Component {
	constructor(props) {
		super(props);

		this.handleStartGame = this.handleStartGame.bind(this);
		this.handleResetGame = this.handleResetGame.bind(this);

		this.state = {
			height: props.height,
			width: props.width,
			fillFactor: props.fillFactor,
			isToroidal: props.isToroidal
		}
	}

	handleStartGame(e) {
		this.props.onStartGame(this.state.width, this.state.height, this.state.fillFactor, this.state.isToroidal);
	}

	handleResetGame(e) {
		this.setState({ width: this.props.width });
		this.setState({ height: this.props.height });
		this.setState({ fillFactor: this.props.fillFactor });
		this.setState({ isToroidal: this.props.isToroidal });

		this.props.onResetGame();
	}

	handleChange = e => {
		this.setState({ [e.target.name]: e.target.value }, () => {
			if (this.props.onChange) {
				this.props.onChange(this.state);
			}
		})
	};

	handleIsToroidalChange = e => {
		this.setState({ isToroidal: !this.state.isToroidal });
	}

	render() {
		return (
			<div>
				<span>Game Parameters Go Here</span><br />
				
				<label htmlFor="width">Width</label>
				<input
					name="width"
					type="number"
					placeholder="X"
					min="3" 
					max="100"
					value={this.state.width}
					onChange={this.handleChange}>
				</input>&nbsp;

				<label htmlFor="height">Height</label>
				<input
					name="height"
					type="number"
					placeholder="Y"
					min="3"
					max="100"
					value={this.state.height}
					onChange={this.handleChange}>
				</input><br />
				
				<label htmlFor="fillFactor">Fill Factor</label>
				<input
					name="fillFactor"
					type="number"
					placeholder="FF"
					min="0"
					max="1"
					step="0.1"
					value={this.state.fillFactor}
					onChange={this.handleChange}>
				</input><br />
				
				<input
					name="isToroidal"
					type="checkbox"
					checked={this.state.isToroidal}
					onChange={this.handleIsToroidalChange}>
				</input>Toroidal<br />
				
				<button type="button" className="btn btn-light" onClick={this.handleStartGame}>Start</button>
				<button type="button" className="btn btn-light" onClick={this.handleResetGame}>Reset</button>
			</div>
		);
	}
}

export default GameParameters;