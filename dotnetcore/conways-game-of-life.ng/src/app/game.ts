export class Game {
  height = 3;
  width = 3;
  fillFactor = 0.5;
  useToiroidalBoard: Boolean = false;
  board: Cell[][];
}

export class Cell {
  alive: boolean;
}
