import React from 'react';

class GameParameters extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			width: 3,
			height: 3,
			fillFactor: 0.5,
			isToroidal: false
		};
	}

	render() {
		const height = this.state.height;
		const width = this.state.width;
		const fillFactor = this.state.fillFactor;
		const isToroidal = this.state.isToroidal;
		return (
			<div>
				<span>Game Parameters Go Here</span><br />
				
				<label htmlFor="width">Width</label>
				<input
					id="width"
					type="number"
					placeholder="X"
					min="3" 
					max="100"
					defaultValue={width}>
				</input>&nbsp;

				<label htmlFor="height">Height</label>
				<input
					id="height"
					type="number"
					placeholder="Y"
					min="3"
					max="100"
					defaultValue={height}>
				</input><br />
				
				<label htmlFor="fillFactor">Fill Factor</label>
				<input
					id="fillFactor"
					type="number"
					placeholder="FF"
					min="0"
					max="1"
					step="0.1"
					defaultValue={fillFactor}>
				</input><br />
				
				<input
					type="checkbox"
					defaultChecked={isToroidal}>
				</input>Toroidal<br />
				
				<button type="button" className="btn btn-light">Start</button>
				<button type="button" className="btn btn-light">Reset</button>
			</div>
		);
	}
}



export default GameParameters;