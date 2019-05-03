import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-game-controls',
  templateUrl: './game-controls.component.html',
  styleUrls: ['./game-controls.component.css']
})
export class GameControlsComponent implements OnInit {
  @Input() ticks: number;
  @Input() autoTick: boolean;
  @Input() toroidalBoard: boolean;

  // exposed events
  @Output() ticked = new EventEmitter();
  @Output() toggleAutotick = new EventEmitter();
  @Output() toggleToiroidal = new EventEmitter();
  @Output() reset = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  toggle() {
    this.toggleAutotick.emit();
  }

  toggleT() {
    this.toggleToiroidal.emit();
  }

  tick() {
    this.ticked.emit();
  }

  resetBoard() {
    this.reset.emit();
  }
}
