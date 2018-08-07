import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Game } from './game';
import { BoardGenerator } from './board_generator';

import { BOARD_GENERATORS } from './mock_generators';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import { resetFakeAsyncZone } from '../../node_modules/@angular/core/testing';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class GameService {
  serviceUrls = 'assets/config.json';

  constructor(private http:  HttpClient) { }

  getGenerators(): Observable<BoardGenerator[]> {
    return this.http.get<BoardGenerator[]>('https://localhost:5001/api/generators');
  }

}
