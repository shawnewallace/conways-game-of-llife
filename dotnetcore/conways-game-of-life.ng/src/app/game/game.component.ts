import { Component, OnInit } from '@angular/core';
import { GameService } from '../game.service';
import { BoardGenerator } from '../board_generator';
import { Game } from '../game';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css'],
})
export class GameComponent implements OnInit {
  game: Game;
  generators: BoardGenerator[];

  constructor(private gameService: GameService) { }

  ngOnInit() {
    this.resetGame();
  }

  getGenerators(): void {
    this.gameService
        .getGenerators()
        .subscribe(
          data => {
            this.generators = data;
          },
          err => console.error(err),
          () => console.log('done loading generators')
        );
  }

  createNewGame(): void {
    this.gameService
        .createNewGame(this.game.width, this.game.height, this.game.fillFactor)
        .subscribe(
          data => {
            console.log(data);
            this.game.board = data.board;
            console.log(this.game);
          },
          err => console.error(err),
          () => console.log('done loading generators')
        );
  }

  resetGame(): void {
    this.game = new Game();
    this.getGenerators();
  }

}
