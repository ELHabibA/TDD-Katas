

namespace Katas_TDD.YatzyKata

{
 public class YatzyKata
{
       
    int[]  ScoreList = new int[30];
    int[]  TotalScoreList = new int[6];

    int UppersectionScore = 0;

    int [] choosenDice = new int[30];

    int counter1 = 0;
    int counter3 = 0;

        public void roll(int points, int choosenDice)
        {
         
          ScoreList[counter1] = points;

     
          
          this.choosenDice[counter1] = choosenDice;

         
          
          counter1++;
        }

        public int score(){

           int result = 0;
           int counter = 0;
         
         while(counter < ScoreList.Length){

          for(int i = 0; i < 5; i++) {

            if(ScoreList[counter + i] == choosenDice[counter3]){

              result += ScoreList[counter + i];
            }
               
           }


           counter3 += 5;
           counter += 5;

           if(counter == 30 && result >= 63){

            result += 35;
           }
         }
           
          return result;
        }

















        public int totalScore(){

         int result = 0;

           for(int i = 0; i < ScoreList.Length; i++) {

              result += TotalScoreList[i];
            
               
           }

          return result;
        }


}
}