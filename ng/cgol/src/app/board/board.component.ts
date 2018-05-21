import { Component, OnInit, OnChanges, Input } from '@angular/core';
import { Cell } from "app/cell";

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent implements OnInit {
  @Input() private board: Array<Cell>;

  constructor() { }

  ngOnInit() {
    if (!this.board) { return; }    
  }

  ngOnChanges() {
    if (!this.board) { return; }
  }
}
