



public class TennisGameSetsTests
{
  
  TennisGame Game = new TennisGame();

  public TennisGameSetsTests()
  {
    for (int i = 0; i < 16; i++)
    {
      Game.WonPoint("player1");
    }

    for (int i = 0; i < 16; i++)
    {
      Game.WonPoint("player2");
    }
    
  }


  [Fact]
  public void When_StartingThisTestClass_ScoreIsFourEach(){

      Assert.Equal("4-4 || 0-0", Game.Score());

  }


   [Fact]
  public void When_WhenaPlayerScore6Points_NextPointScoredGotonextset(){

    for (int i = 0; i < 16; i++)
    {
        Game.WonPoint("player1");
    }

      Assert.Equal("6-4 | 2-0 || 0-0", Game.Score());

  }

  
  [Fact]
  public void When_APlayerScore6PointsAndTheOtherPlayerHas5Points_GoToAdditionalPoint(){
    
    for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player2");
    }

    for (int i = 0; i < 12; i++)
    {
        Game.WonPoint("player1");
    }

      Assert.Equal("7-5 || 0-0", Game.Score());

  }

  
  [Fact]
  public void When_PlayerScore6PointsAndTheOtherPlayerHas6Points_GoToAdditionalPoint(){
    
    for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player2");
    }

    for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player1");
    }

    for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player1");
    }

     for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player2");
    }

    for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player1");
    }


      Assert.Equal("7-6 || 0-0", Game.Score());

  }

  [Fact]
  public void When_PlayerScore7PointsAndTheOtherPlayerHas6Points_GoToNextSet(){
    
    for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player2");
    }

    for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player1");
    }

    for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player1");
    }

     for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player2");
    }

    for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player1");
    }
     
    for (int i = 0; i < 4; i++)
    {
        Game.WonPoint("player1");
    }

      Assert.Equal("7-6 | 1-0 || 0-0", Game.Score());

  }

  [Fact]
  public void When_PlayerScore6PointsinSecondSet_GoToNextSet(){
    
    for (int i = 0; i < 40; i++)
    {
        Game.WonPoint("player1");
    }

      Assert.Equal("6-4 | 6-0 | 2-0 || 0-0", Game.Score());

  }


  [Fact]
  public void When_ThreeSetsisDone_GameIsFinished(){
    
    for (int i = 0; i < 40; i++)
    {
        Game.WonPoint("player1");
    }
    for (int i = 0; i < 12; i++)
    {
        Game.WonPoint("player1");
    }

    for (int i = 0; i < 8; i++)
    {
        Game.WonPoint("player2");
    }

    for (int i = 0; i < 8; i++)
    {
        Game.WonPoint("player1");
    }

      Assert.Equal("6-4 | 6-0 | 6-2 || 0-0", Game.Score());

  }

}