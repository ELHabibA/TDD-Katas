

namespace Katas_TDD.YatzyKata

{
    public class YatzyKataTests

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
          Game.eChoosenQueue = new Queue<YatzyKata.eChoosen>();
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)1);

            

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
          
          Game.eChoosenQueue = new Queue<YatzyKata.eChoosen>();
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)2);
          

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
           
          Game.eChoosenQueue = new Queue<YatzyKata.eChoosen>();
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)3);
          

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

          Game.eChoosenQueue = new Queue<YatzyKata.eChoosen>();
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)2);
          

        //2
          Game.roll(2);
          Game.roll(2); 
          Game.roll(3);
          Game.roll(3);
          Game.roll(3);
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)3);
          
        
          Assert.Equal(13,  Game.score());

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

          Game.eChoosenQueue = new Queue<YatzyKata.eChoosen>();
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)5);
 //15 5


          //2
          Game.roll(2);
          Game.roll(2); 
          Game.roll(4);
          Game.roll(4);
          Game.roll(5); //8 4
       
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)4);

          //3
          Game.roll(6); 
          Game.roll(6); 
          Game.roll(6);
          Game.roll(6);
          Game.roll(5); //24 6
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)6);



          //4
          Game.roll(2);
          Game.roll(3); 
          Game.roll(3);
          Game.roll(3);
          Game.roll(3); //12 3
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)3);


          //5
          Game.roll(1);
          Game.roll(1); 
          Game.roll(4);
          Game.roll(3);
          Game.roll(5); //2 1
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)1);


          //6
          Game.roll(1);
          Game.roll(2); 
          Game.roll(3);
          Game.roll(3);
          Game.roll(5); //2 2
          Game.eChoosenQueue.Enqueue((YatzyKata.eChoosen)2);

          Assert.Equal(98,  Game.score());

        }



    }
}