import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit, OnChanges {
  @Input() board: boolean[][];
  @Input() width: number;
  @Input() height: number;
  widthRange: number[];
  heightRange: number[];

  showSmallBoard: boolean;

  constructor() {
    this.showSmallBoard = false;
  }

  ngOnInit() { }

  ngOnChanges(changes: SimpleChanges) {
    if (!changes.board) {
      return;
    }

    console.log('Board changed: you should be redrawing.');
    console.log(this.board);

    this.showSmallBoard = false;

    this.widthRange = Array(this.width).fill(1).map((_, i) => i);
    this.heightRange = Array(this.height).fill(1).map((_, i) => i);

    if (this.widthRange.length > 20) {
      this.showSmallBoard = true;
    }

    if (this.showSmallBoard) {
      console.log('showing SMALL board');
    } else {
      console.log('showing NORMAL board');
    }

    console.log('width:' + this.width);
    console.log('height:' + this.height);
    console.log('widthrange:' + this.widthRange);
    console.log('heightrange:' + this.heightRange);
  }
}
