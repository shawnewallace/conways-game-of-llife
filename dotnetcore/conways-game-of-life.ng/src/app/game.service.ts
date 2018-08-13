import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Game, GameApiRequest } from './game';
import { BoardGenerator } from './board_generator';

import { BOARD_GENERATORS } from './mock_generators';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import { resetFakeAsyncZone } from '../../node_modules/@angular/core/testing';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' })
};

// const rootUrl = 'https://localhost:5001/api';
const rootUrl = 'https://20b4yyylc8.execute-api.us-east-2.amazonaws.com/dev';


@Injectable()
export class GameService {
  serviceUrls = 'assets/config.json';

  constructor(private http:  HttpClient) { }

  getGenerators(): Observable<BoardGenerator[]> {
    return this.http.get<BoardGenerator[]>(`${rootUrl}/generators`, httpOptions);
  }

  createNewGame(width: number, height: number, fillFactor: number): Observable<Game> {
    const body = {
      width: width,
      height: height,
      fillFactor: fillFactor
    };

    console.log(body);

    return this.http.post<Game>(`${rootUrl}/game`, body, httpOptions);
  }

  tick(game: Game) {
    console.log('Ticking board:');
    console.log(game);

    const request = new GameApiRequest();
    request.body = game;

    return this.http.post<GameApiRequest>(`${rootUrl}/game/tick`, request, httpOptions);
  }
}
