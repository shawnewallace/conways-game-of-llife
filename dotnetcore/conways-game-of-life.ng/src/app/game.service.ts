import { Injectable } from '@angular/core';
import { Game } from './game';
import { BoardGenerator } from './board_generator';

import { BOARD_GENERATORS } from './mock_generators';
import { Observable } from 'rxjs';

@Injectable()
export class GameService {

  constructor() { }

  getGenerators(): Observable<BoardGenerator[]> {
    return Observable.of(BOARD_GENERATORS);
  }

}
