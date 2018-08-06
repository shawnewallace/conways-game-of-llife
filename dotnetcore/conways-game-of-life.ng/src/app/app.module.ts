import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { GameComponent } from './game/game.component';
import { ParamsComponent } from './params/params.component';
import { GameControlsComponent } from './game-controls/game-controls.component';
import { BoardComponent } from './board/board.component';
import { GameService } from './game.service';


@NgModule({
  declarations: [
    AppComponent,
    GameComponent,
    ParamsComponent,
    GameControlsComponent,
    BoardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [GameService],
  bootstrap: [AppComponent]
})
export class AppModule { }
