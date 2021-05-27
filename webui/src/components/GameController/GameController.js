function GameController(props) {
	return (
			<div>
				<span>Game Controller here!</span><br />

				<input
					name="autoTick"
					type="checkbox"
					defaultChecked={props.autoTick}
					onChange={this.toggleAutoTick}>
				</input>Auto-tick<br />

				<button type="button" className="btn btn-light" onClick={props.onTick}>Tick</button>
				<button type="button" className="btn btn-light" onClick={props.onResetGame}>Reset</button>


				<div>Num Ticks: {props.numTicks}</div>
				<div>Population: {props.population}</div>
			</div>
		);
}

export default GameController;