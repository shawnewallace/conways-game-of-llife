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
        .subscribe(gens => this.generators = gens);
  }

  clicker(): void {
    this.game.height = this.game.height + 10;
    this.game.width = this.game.height;
  }

  resetGame(): void {
    this.game = new Game();
    this.getGenerators();
  }

}
