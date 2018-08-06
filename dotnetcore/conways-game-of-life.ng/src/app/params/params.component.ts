import { Component, OnInit, Input } from '@angular/core';
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

  constructor() { }

  ngOnInit() {
  }

}
