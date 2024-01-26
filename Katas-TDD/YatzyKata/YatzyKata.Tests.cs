

namespace Katas_TDD.YatzyKata

{
    public class YatzyKataTests

    {
         [Fact]
        public void When_FourOneDice_TheScoreShouldbeFour()
        {

          YatzyKata Game = new YatzyKata();

          Game.roll(1, 1);
          Game.roll(1, 1);
          Game.roll(1, 1);
          Game.roll(1, 1);

          Game.roll(5, 1);


            

            Assert.Equal(4, Game.score());

        }

         [Fact]
        public void When_ThreeTwoDice_TheScoreShouldbeSix()
        {

          YatzyKata Game = new YatzyKata();

          Game.roll(2, 2);
          Game.roll(2, 2);
          Game.roll(2, 2);
          Game.roll(4, 2);

          Game.roll(5, 2);


            

            Assert.Equal(6, Game.score());

        }

       [Theory]
       [InlineData(3)]
        public void When_PlayerDecides_SumDecidedValues(int decision)
        {

          YatzyKata Game = new YatzyKata();

          Game.roll(2, decision); //0
          Game.roll(2, decision); 
          Game.roll(3, decision);
          Game.roll(3, decision);
          Game.roll(5, decision);


            

            Assert.Equal(6, Game.score());

        }

        [Theory]
       [InlineData(3, 2)]
        public void When_PlayerPlaysSecondRound_SumDecidedValuesandAddthemToTheTotalScore(int decision1, int decision2)
        {

          YatzyKata Game = new YatzyKata();

        //1
          Game.roll(2, decision2); 
          Game.roll(2, decision2); 
          Game.roll(3, decision2);
          Game.roll(3, decision2);
          Game.roll(5, decision2);


        //2
          Game.roll(2, decision1);
          Game.roll(2, decision1); 
          Game.roll(3, decision1);
          Game.roll(3, decision1);
          Game.roll(3, decision1);

         
            

            Assert.Equal(13,  Game.score());

        }


        [Theory]
       [InlineData(4, 5, 6, 3, 1, 2)]
        public void When_PlayerGetsScore63OrMore_PlayerGetsBonus35(int decision1, int decision2, int decision3,  int decision4, int decision5, int decision6)
        {

          YatzyKata Game = new YatzyKata();

        //1
          Game.roll(2, decision2); 
          Game.roll(2, decision2); 
          Game.roll(5, decision2);
          Game.roll(5, decision2);
          Game.roll(5, decision2); //15 5


        //2
          Game.roll(2, decision1);
          Game.roll(2, decision1); 
          Game.roll(4, decision1);
          Game.roll(4, decision1);
          Game.roll(5, decision1); //8 4

          //3
          Game.roll(6, decision3); 
          Game.roll(6, decision3); 
          Game.roll(6, decision3);
          Game.roll(6, decision3);
          Game.roll(5, decision3); //24 6


          //4
          Game.roll(2, decision4);
          Game.roll(3, decision4); 
          Game.roll(3, decision4);
          Game.roll(3, decision4);
          Game.roll(3, decision4); //12 3

               //5
          Game.roll(1, decision5);
          Game.roll(1, decision5); 
          Game.roll(4, decision5);
          Game.roll(3, decision5);
          Game.roll(5, decision5); //2 1
          //6
          Game.roll(1, decision6);
          Game.roll(2, decision6); 
          Game.roll(3, decision6);
          Game.roll(3, decision6);
          Game.roll(5, decision6); //2 2

         
            

            Assert.Equal(98,  Game.score());

        }



    }
}