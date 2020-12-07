function GameParameters(props) {
	return (
		<div>
			<span>Game Parameters Go Here</span>
			<input type="number" placeholder="width"></input>
			<input type="number" placeholder="height"></input>
			<span>Fillfactor</span>
			<span>Toroidal</span>
			<br />
			<button type="button" class="btn btn-light">Start</button>
			<button type="button" class="btn btn-light">Reset</button>
		</div>
	);
}

export default GameParameters;