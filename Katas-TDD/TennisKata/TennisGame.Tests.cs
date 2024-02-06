
public class TennisGameTests
{


  [Theory]
  [InlineData("player1")]
  public void When_Player1scorefirstpoint_ScorebecomesFifteenLove(string winner){

  var Game = new TennisGame();

  Game.WonPoint(winner);

  Assert.Equal("15-0", Game.Score());

  }

  [Theory]
  [InlineData("player2")]
  public void When_Player2scorefirstpoint_ScorebecomesLoveFifteen(string winner){

  var Game = new TennisGame();

  Game.WonPoint(winner);

  Assert.Equal("0-15", Game.Score());

  }

  [Theory]
  [InlineData("player1", "player2")]
  public void When_BothPlayersScoresfirstpoint_ScorebecomesFifteen_Fifteen(string winner1, string winner2){

  var Game = new TennisGame();

  Game.WonPoint(winner1);
  Game.WonPoint(winner2);

  Assert.Equal("15-15", Game.Score());

  }

   [Theory]
  [InlineData("player1", "player2")]
  public void When_BothPlayersScorespoints_ScorebecomesTheSumOfPointscoredByEachPlayer(string winner1, string winner2){

  var Game = new TennisGame();

  Game.WonPoint(winner1);
  Game.WonPoint(winner1);
  Game.WonPoint(winner1);
  Game.WonPoint(winner2);
  Game.WonPoint(winner2);

  Assert.Equal("40-30", Game.Score());

  }

  [Theory]
  [InlineData("player1", "player2")]
  public void When_BothhasForthy_NextPlayerWhoScoresGet50(string winner1, string winner2){

  var Game = new TennisGame();

  Game.WonPoint(winner1);
  Game.WonPoint(winner1);
  Game.WonPoint(winner1);
  Game.WonPoint(winner2);
  Game.WonPoint(winner2);
  Game.WonPoint(winner2);
  Game.WonPoint(winner1);

  Assert.Equal("50-40", Game.Score());

  }

  [Theory]
  [InlineData("player1", "player2")]
  public void When_Player1Has50andPlayer2has40_AndPlayer2WinsNextPoint_ScoreBecomes40_40Again(string winner1, string winner2){

  var Game = new TennisGame();

  Game.WonPoint(winner1);
  Game.WonPoint(winner1);
  Game.WonPoint(winner1);
  Game.WonPoint(winner2);
  Game.WonPoint(winner2);
  Game.WonPoint(winner2);
  Game.WonPoint(winner1);
  Game.WonPoint(winner2);

  Assert.Equal("40-40", Game.Score());

  }


  
}

 


