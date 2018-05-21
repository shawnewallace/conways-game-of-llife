import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { ParametersComponent } from './parameters/parameters.component';
import { BoardComponent } from './board/board.component';
import { GameComponent } from './game/game.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ParametersComponent,
    BoardComponent,
    GameComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
