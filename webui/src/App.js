import './App.css';
import GameHeader from './GameHeader'
import GameParameters from './GameParameters'
import GameBoard from './GameBoard'
import GameController from './GameController'

function App() {
  return (
    <div className="App">
      
			<GameHeader></GameHeader>

			<GameParameters></GameParameters>

			<GameController></GameController>

			<GameBoard></GameBoard>
    </div>
  );
}

export default App;
