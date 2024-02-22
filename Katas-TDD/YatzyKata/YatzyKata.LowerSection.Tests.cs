namespace Katas_TDD.YatzyKata

{
    public class YatzyKataLowerSectionTests
    {

      private readonly YatzyKata Game;
      
      public YatzyKataLowerSectionTests()
      {

        Game = new YatzyKata();

        for(int i = 1; i <= 5; i++){
          Game.roll(i);
        }
        Game.ChooseUpperSectionBox(1);


        for(int i = 1; i <=  5; i++){
          Game.roll(i);
        }
        Game.ChooseUpperSectionBox(2);


        for(int i = 1; i <= 5; i++){
          Game.roll(i);
        }
          Game.ChooseUpperSectionBox(3);

        for(int i = 1; i <= 5; i++){
          Game.roll(i);
        }
          Game.ChooseUpperSectionBox(4);

        for(int i = 1; i <= 5; i++){
          Game.roll(i);
        }
          Game.ChooseUpperSectionBox(5);

        for(int i = 2; i <= 6; i++){
        Game.roll(i);
        }
          Game.ChooseUpperSectionBox(6);

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
          Game.ChooseLowerSectionBox(7);

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

          Game.ChooseLowerSectionBox(8);
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

          Game.ChooseLowerSectionBox(9);
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

          Game.ChooseLowerSectionBox(10);
          Assert.Equal(51, Game.score());

      }

      [Fact]
       public void When_LangStraight_Add50() 
      {

          Game.roll(1); 
          Game.roll(2); 
          Game.roll(3);
          Game.roll(4);
          Game.roll(5);

          Game.ChooseLowerSectionBox(11);
          Assert.Equal(61, Game.score());

      }

      [Fact]
       public void When_Yathzee_Add40() 
      {

          Game.roll(4); 
          Game.roll(4); 
          Game.roll(4);
          Game.roll(4);
          Game.roll(4);

          Game.ChooseLowerSectionBox(12);
          Assert.Equal(61, Game.score());

      }

      [Fact]
       public void When_Chance_AddTotaldice() 
      {

          Game.roll(4); 
          Game.roll(4); 
          Game.roll(2);
          Game.roll(5);
          Game.roll(3);

          Game.ChooseLowerSectionBox(13);
          Assert.Equal(39, Game.score());

      }

      [Fact]
       public void When_BoxIsAlreadyChoosed_DoNOTAddToResult() 
      {

          Game.roll(4); 
          Game.roll(4); 
          Game.roll(2);
          Game.roll(5);
          Game.roll(3);

          Game.ChooseLowerSectionBox(13);


          Game.roll(2); 
          Game.roll(1); 
          Game.roll(1);
          Game.roll(3);
          Game.roll(2);

          Game.ChooseLowerSectionBox(13);
          
          Assert.Equal(41, Game.score());


      }
    }


}