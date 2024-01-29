namespace Katas_TDD.YatzyKata

{
    public class YatzyKataLowerSectionTests
    {

      YatzyKata Game = new YatzyKata();
      
      public YatzyKataLowerSectionTests()
      {
        for(int i = 1; i <= 5; i++){
          Game.roll(i);
        }
        Game.eUpperSectionChoosenQueue = new Queue<YatzyKata.eUpperSectionChoosen>();
        Game.eUpperSectionChoosenQueue.Enqueue((YatzyKata.eUpperSectionChoosen)1);

        for(int i = 1; i <=  5; i++){
          Game.roll(i);
        }
        Game.eUpperSectionChoosenQueue.Enqueue((YatzyKata.eUpperSectionChoosen)2);

        for(int i = 1; i <= 5; i++){
          Game.roll(i);
        }
        Game.eUpperSectionChoosenQueue.Enqueue((YatzyKata.eUpperSectionChoosen)3);

        for(int i = 1; i <= 5; i++){
          Game.roll(i);
        }
        Game.eUpperSectionChoosenQueue.Enqueue((YatzyKata.eUpperSectionChoosen)4);

        for(int i = 1; i <= 5; i++){
          Game.roll(i);
        }
        Game.eUpperSectionChoosenQueue.Enqueue((YatzyKata.eUpperSectionChoosen)5);

        for(int i = 2; i <= 6; i++){
        Game.roll(i);
        }
        Game.eUpperSectionChoosenQueue.Enqueue((YatzyKata.eUpperSectionChoosen)6);

      }

      [Fact]
      public void When_StartingUpperSectionResult_Return21()
      {

        Assert.Equal(21, Game.score());

      }

      [Fact]
      public void When_ThreeOfAKind_AddTotalofAllDices()
      {

          Game.roll(2); 
          Game.roll(2); 
          Game.roll(5);
          Game.roll(5);
          Game.roll(5);

          Game.eLowerSectionChoosenQueue = new Queue<YatzyKata.eLowerSectionChoosen>();
          Game.eLowerSectionChoosenQueue.Enqueue((YatzyKata.eLowerSectionChoosen)7);
          Assert.Equal(36, Game.score());

      }

      [Fact]
       public void When_FourOfAKind_AddTotalofAllDices()
      {

          Game.roll(2); 
          Game.roll(5); 
          Game.roll(5);
          Game.roll(5);
          Game.roll(5);

          Game.eLowerSectionChoosenQueue = new Queue<YatzyKata.eLowerSectionChoosen>();
          Game.eLowerSectionChoosenQueue.Enqueue((YatzyKata.eLowerSectionChoosen)8);
          Assert.Equal(41, Game.score());

      }

      [Fact]
       public void When_FullHouse_Add25() 
      {

          Game.roll(2); 
          Game.roll(2); 
          Game.roll(5);
          Game.roll(5);
          Game.roll(5);

          Game.eLowerSectionChoosenQueue = new Queue<YatzyKata.eLowerSectionChoosen>();
          Game.eLowerSectionChoosenQueue.Enqueue((YatzyKata.eLowerSectionChoosen)9);
          Assert.Equal(46, Game.score());

      }

      [Fact]
       public void When_SmallStraight_Add30() 
      {

          Game.roll(1); 
          Game.roll(2); 
          Game.roll(3);
          Game.roll(4);
          Game.roll(6);

          Game.eLowerSectionChoosenQueue = new Queue<YatzyKata.eLowerSectionChoosen>();
          Game.eLowerSectionChoosenQueue.Enqueue((YatzyKata.eLowerSectionChoosen)10);
          Assert.Equal(51, Game.score());

      }
    }

}