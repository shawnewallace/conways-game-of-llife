import '../Cell/Cell';
import Cell from '../Cell/Cell';

function GameBoard(props) {
	var world = [];
	var row = [];

	for (var i = 0; i < 20; i++) {
		for (var j = 0; j < 20; j++) {
			row.push(
				<Cell
					key={[i, j]}
					i={i}
					j={j} />);
		}
		world.push(<div className="row" key={i}>{row}</div>);
		row = [];
	}

	return (
		<div >
			{world}
		</div>
	);
}

export default GameBoard;