import { Component, OnInit, OnChanges, Output } from '@angular/core';

@Component({
  selector: 'app-parameters',
  templateUrl: './parameters.component.html',
  styleUrls: ['./parameters.component.scss']
})
export class ParametersComponent implements OnInit, OnChanges {
  @Output() public width: number = 10;
  @Output() public height: number = 10;
  @Output() public fillFactor: number = .5;

  public initialBoards = [
    {"value":"random", "display": "Random Board"},
    {"value":"blank", "display": "Random Board"},
    {"value":"checkerboard", "display": "Checker Board"},
    {"value":"symmetric", "display": "Symmetric"},
    {"value":"gosper", "display": "Gosper's Gliding Gun"}
  ];

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges() {
  }
}
