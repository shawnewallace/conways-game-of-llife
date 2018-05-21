import { Component, OnInit } from '@angular/core';
import { Cell } from "app/cell";

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {
  private board: Cell[,];

  constructor() { }

  ngOnInit() {
  }

  public createNewGame() {
    board = new Cell[,];
  }
}
