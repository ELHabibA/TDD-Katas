

namespace Katas_TDD.YatzyKata

{
    public class YatzyKataUpperSectionTests

    {
        [Fact]
        public void When_FourOneDice_TheScoreShouldbeFour()
        {

          YatzyKata Game = new YatzyKata();

          Game.roll(1);
          Game.roll(1);
          Game.roll(1);
          Game.roll(1);
          Game.roll(5);
          Game.ChooseUpperSectionBox(1);

            Assert.Equal(4, Game.score());

        }

        [Fact]
        public void When_ChoosenDiceIsNotProvided_ReturnMinusOne()
        {

          YatzyKata Game = new YatzyKata();

          Game.roll(1);
          Game.roll(1);
          Game.roll(1);
          Game.roll(1);
          Game.roll(5);

          Assert.Equal(-1, Game.score());

        }

        [Fact]
        public void When_ThreeTwoDice_TheScoreShouldbeSix()
        {

          YatzyKata Game = new YatzyKata();

          Game.roll(2);
          Game.roll(2);
          Game.roll(2);
          Game.roll(4);
          Game.roll(5);
          Game.ChooseUpperSectionBox(2);

          

          Assert.Equal(6, Game.score());

        }

       [Fact]
        public void When_PlayerDecides_SumDecidedValues()
        {

          YatzyKata Game = new YatzyKata();

          Game.roll(2);
          Game.roll(2); 
          Game.roll(3);
          Game.roll(3);
          Game.roll(5);
           
          Game.ChooseUpperSectionBox(3);

          

          Assert.Equal(6, Game.score());

        }

        [Fact]
        public void When_PlayerPlaysSecondRound_SumDecidedValuesandAddthemToTheTotalScore()
        {

          YatzyKata Game = new YatzyKata();

        //1
          Game.roll(2); 
          Game.roll(2); 
          Game.roll(3);
          Game.roll(3);
          Game.roll(5);
          Game.ChooseUpperSectionBox(2);
          

        //2
          Game.roll(2);
          Game.roll(2); 
          Game.roll(3);
          Game.roll(3);
          Game.roll(3);
          Game.ChooseUpperSectionBox(3);
          
        
          Assert.Equal(13,  Game.score());

        }

        [Fact]
        public void When_PlayerGetsScoreUnder63_PlayerGetsTheSumOnly()
        {

          YatzyKata Game = new YatzyKata();

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
          
          Assert.Equal(21,  Game.score());

        }


        [Fact]
        public void When_PlayerGetsScore63OrMore_PlayerGetsBonus35()
        {

          YatzyKata Game = new YatzyKata();

          //1
          Game.roll(2); 
          Game.roll(2); 
          Game.roll(5);
          Game.roll(5);
          Game.roll(5);

          Game.ChooseUpperSectionBox(5);

 //15 5


          //2
          Game.roll(2);
          Game.roll(2); 
          Game.roll(4);
          Game.roll(4);
          Game.roll(5); //8 4
       
          Game.ChooseUpperSectionBox(4);

          //3
          Game.roll(6); 
          Game.roll(6); 
          Game.roll(6);
          Game.roll(6);
          Game.roll(5); //24 6
          Game.ChooseUpperSectionBox(6);



          //4
          Game.roll(2);
          Game.roll(3); 
          Game.roll(3);
          Game.roll(3);
          Game.roll(3); //12 3
          Game.ChooseUpperSectionBox(3);


          //5
          Game.roll(1);
          Game.roll(1); 
          Game.roll(4);
          Game.roll(3);
          Game.roll(5); //2 1
          Game.ChooseUpperSectionBox(1);


          //6
          Game.roll(1);
          Game.roll(2); 
          Game.roll(3);
          Game.roll(3);
          Game.roll(5); //2 2
          Game.ChooseUpperSectionBox(2);

          Assert.Equal(98,  Game.score());

        }


        [Fact]
        public void When_PlayerChoseDiceToSum_IfHeChoosesSameDiceAgainIgnoreIt()
        {

          YatzyKata Game = new YatzyKata();

        //1
          Game.roll(2); 
          Game.roll(2); 
          Game.roll(3);
          Game.roll(3);
          Game.roll(5);

          Game.ChooseUpperSectionBox(2);

          

        //2
          Game.roll(2);
          Game.roll(2); 
          Game.roll(2);
          Game.roll(3);
          Game.roll(3);
          Game.ChooseUpperSectionBox(2);
          
        
          Assert.Equal(4,  Game.score());

        }

        [Fact]
        public void When_PlayerChoseDiceToSum_IfHeChoosesSameDiceAgainIgnoreIt2()
        {

          YatzyKata Game = new YatzyKata();

        //1
          Game.roll(2); 
          Game.roll(2); 
          Game.roll(3);
          Game.roll(3);
          Game.roll(6);

          Game.ChooseUpperSectionBox(6);

          

        //2
          Game.roll(6);
          Game.roll(6); 
          Game.roll(2);
          Game.roll(3);
          Game.roll(3);
          Game.ChooseUpperSectionBox(6);
          
        
          Assert.Equal(6,  Game.score());

        }
    }
}