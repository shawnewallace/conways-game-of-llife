using System;
using conways_game_of_life.core;

namespace conways_game_of_life.lib
{
	public class GameCreator : ICGolGameCreator
  {
    public int Width { get; set; }
    public int Height { get; set; }
    public double FillFactor { get; set; }
    public BoardGenerator Generator { get; set; }
		public ICGolGame Game { get; private set; }

		public GameCreator(ICGolGame game) {
			Game = game;
		}

    public ICGolGame Execute()
    {
      switch (Generator)
      {
        case BoardGenerator.Random:
          return RandomBoard();
        case BoardGenerator.Blank:
          return BlankBoard();
        case BoardGenerator.Symmetric:
          return SymmetricBoard();
        case BoardGenerator.Checkerboard:
          return Checkerboard();
        case BoardGenerator.Gosper:
          return GospersGlidingGun();
      }

      return BlankBoard();
    }

    private ICGolGame GospersGlidingGun()
    {
      SetMinDimensions(40, 11);
      var game = InitializeGame();

      //left square
      game.Board[1, 5].Alive = true;
      game.Board[2, 5].Alive = true;
      game.Board[1, 6].Alive = true;
      game.Board[2, 6].Alive = true;

      //left node
      game = DrawVerticalLine(game, 11, 5, 7);
      game.Board[12, 4].Alive = true;
      game.Board[12, 8].Alive = true;

      game.Board[13, 3].Alive = true;
      game.Board[14, 3].Alive = true;
      game.Board[13, 9].Alive = true;
      game.Board[14, 9].Alive = true;

      game.Board[15, 6].Alive = true;

      game.Board[16, 4].Alive = true;
      game.Board[16, 8].Alive = true;

      game = DrawVerticalLine(game, 17, 5, 7);

      game.Board[18, 6].Alive = true;

      //right node
      game = DrawVerticalLine(game, 21, 3, 5);
      game = DrawVerticalLine(game, 22, 3, 5);

      game.Board[23, 2].Alive = true;
      game.Board[23, 6].Alive = true;

      game.Board[25, 1].Alive = true;
      game.Board[25, 2].Alive = true;

      game.Board[25, 6].Alive = true;
      game.Board[25, 7].Alive = true;

      //right square
      //35
      game.Board[35, 3].Alive = true;
      game.Board[36, 3].Alive = true;
      game.Board[35, 4].Alive = true;
      game.Board[36, 4].Alive = true;




      return game;
    }

    private ICGolGame Checkerboard()
    {
      //board must be square and dimensions must be even
      var length = Width;
      if (Width > Height) length = Width;
      if (Height > Width) length = Height;

      if (length % 2 != 0) length++;

      Width = length;
      Height = length;

      var game = InitializeGame();
      var initialState = true;

      for (var i = 0; i < Width; i++)
      {
        var nextState = initialState;
        for (var j = 0; j < Height; j++)
        {
          game.Board[i, j] = new Cell { Alive = nextState };
          nextState = !nextState;
        }

        initialState = !initialState;
      }

      return game;
    }

    private ICGolGame SymmetricBoard()
    {
      SetMinDimensions(20, 20);

      var board = InitializeGame();

      var centerX = (int)Math.Floor((decimal)(Width / 2)) - 1;
      var centerY = (int)Math.Floor((decimal)(Width / 2)) - 1;

      board.Board[centerX, centerY].Alive = true;
      board.Board[centerX + 1, centerY].Alive = true;
      board.Board[centerX, centerY + 1].Alive = true;
      board.Board[centerX + 1, centerY + 1].Alive = true;

      board = DrawVerticalLine(board, centerX - 3, centerY - 3, centerY + 4);
      board = DrawVerticalLine(board, centerX + 4, centerY - 3, centerY + 4);

      board = DrawHorozontalLine(board, centerY - 3, centerX - 3, centerX + 4);
      board = DrawHorozontalLine(board, centerY + 4, centerX - 3, centerX + 4);

      return board;
    }

    private ICGolGame DrawHorozontalLine(ICGolGame board, int y, int xFrom, int xTo)
    {
      for (var x = xFrom; x <= xTo; x++)
      {
        board.Board[x, y].Alive = true;
      }

      return board;
    }

    private ICGolGame DrawVerticalLine(ICGolGame board, int x, int yFrom, int yTo)
    {
      for (var y = yFrom; y <= yTo; y++)
      {
        board.Board[x, y].Alive = true;
      }

      return board;
    }

    private ICGolGame BlankBoard()
    {
      return InitializeGame();
    }

    private ICGolGame RandomBoard()
    {
      var game = InitializeGame();

      var rand = new Random();

      for (var i = 0; i < Width; i++)
      {
        for (var j = 0; j < Height; j++)
        {
          var shouldBeAlive = rand.NextDouble() < FillFactor;

          game.Board[i, j] = new Cell { Alive = shouldBeAlive };
        }
      }

      return game;
    }

    private ICGolGame InitializeGame()
    {
			Game.Board = new Cell[Width, Height];


			for (var i = 0; i < Width; i++)
      {
        for (var j = 0; j < Height; j++)
        {
					Game.Board[i, j] = new Cell { Alive = false };
        }
      }

			return Game;
    }

    private void SetMinDimensions(int minWidth, int minHeight)
    {
      if (Width < minWidth) Width = minWidth;
      if (Height < minHeight) Height = minHeight;
    }
  }
}
