import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


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
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [GameService],
  bootstrap: [AppComponent]
})
export class AppModule { }
