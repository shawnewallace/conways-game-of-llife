import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-game-controls',
  templateUrl: './game-controls.component.html',
  styleUrls: ['./game-controls.component.css']
})
export class GameControlsComponent implements OnInit {
  @Input() ticks: number;
  @Output() ticked = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  tick() {
    this.ticked.emit();
  }
}
