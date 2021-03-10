class GameModel {
	constructor(props) {
		this.width = props.width;
		this.height = props.height;
		this.fillFactor = props.fillFactor;
		this.isToroidal = props.isToroidal;
	}
}

export default GameModel;