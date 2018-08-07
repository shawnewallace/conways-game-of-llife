import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Game } from '../game';
import { BoardGenerator } from '../board_generator';

@Component({
  selector: 'app-params',
  templateUrl: './params.component.html',
  styleUrls: ['./params.component.css']
})
export class ParamsComponent implements OnInit {

  @Input() generators: BoardGenerator[];
  @Input() width: number;
  @Input() height: number;
  @Input() fillFactor: number;

  @Output() completed = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  complete() {
    this.completed.emit();
  }

}
