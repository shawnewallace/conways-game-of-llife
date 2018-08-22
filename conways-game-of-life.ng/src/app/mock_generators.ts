import { BoardGenerator } from './board_generator';

export const BOARD_GENERATORS: BoardGenerator[] = [
  { id: 0, name: 'Random' },
  { id: 1, name: 'Blank' },
  { id: 2, name: 'Symmetric' },
  { id: 3, name: 'Checkerboard' },
  { id: 4, name: 'Gosper\'s Gliding Gun' },
];
