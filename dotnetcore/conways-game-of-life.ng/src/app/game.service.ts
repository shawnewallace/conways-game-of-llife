import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Game } from './game';
import { BoardGenerator } from './board_generator';

import { BOARD_GENERATORS } from './mock_generators';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';

@Injectable()
export class GameService {

  constructor(private http:  HttpClient) { }

  getGenerators(): Observable<BoardGenerator[]> {
    return Observable.of(BOARD_GENERATORS);
  }

}
