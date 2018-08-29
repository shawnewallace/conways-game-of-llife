export class Game {
  height = 10;
  width = 10;
  fillFactor = 0.5;
  useToiroidalBoard: Boolean = false;
  board: boolean[][];
  generator: "Random";
}

export class GameApiRequest {
  body: Game;
}
