import { Component, OnInit } from '@angular/core';
import { GameService } from '../game.service';
import { BoardGenerator } from '../board_generator';
import { Game } from '../game';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css'],
})

export class GameComponent implements OnInit {
  game = new Game();
  generators: BoardGenerator[];
  tickCount = 0;
  autoTick = true;
  activeGame = false;

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

  createNewGame(parameters: Game): void {
    this.activeGame = true;

    console.log('creating new game with params:');
    console.log(parameters);
    this.game.width = parameters.width;
    this.game.height = parameters.height;
    this.game.fillFactor = parameters.fillFactor;

    this.tickCount = 0;
    this.gameService
        .createNewGame(this.game.width, this.game.height, this.game.fillFactor)
        .subscribe(
          data => {
            console.log('RECEIVED BY createNewGame:');
            console.log(data);
            this.game = data;
            console.log(this.game);
          },
          err => console.error(err),
          () => console.log('done creating game')
        );
  }

  tick(): void {
    this.tickCount = this.tickCount + 1;

    this.gameService
        .tick(this.game)
        .subscribe(
          data => {
            console.log(data);
            this.game = data;
            console.log(this.game);
          },
          err => console.error(err),
          () => console.log('done ticking board')
        );
  }

  toggleAutotick(): void {
    this.autoTick = !this.autoTick;

    console.log(`Autoticked changed to ${this.autoTick}`);

    Observable.timer(0, 1000)
      .takeWhile(() => this.autoTick)
      .subscribe(() => {
        console.log('Autotick Triggered');
        this.tick();
      });
  }

  resetGame(): void {
    this.activeGame = false;
    this.autoTick = false;

    this.game = new Game();
    this.tickCount = 0;
    this.getGenerators();
  }

}
