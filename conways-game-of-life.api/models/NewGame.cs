using System;
using conways_game_of_life.core;
using conways_game_of_life.lib;

namespace conways_game_of_life.api.Models
{
  public class NewGame
  {
    public int height { get; set; }
    public int width { get; set; }
    public double fillFactor { get; set; }
    public BoardGenerator generator { get;set; }
  }
}