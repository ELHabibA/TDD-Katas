

namespace Katas_TDD.YatzyKata

{
 public class YatzyKata
{
       
    int[]  ScoreList = new int[30];
    public Queue<eChoosen>? eChoosenQueue = null; 
    int counter1 = 0;

    public enum eChoosen {
    ones = 1, twos, threes, fours, five, six, fhreeOfaKind, fourOfaKind, fullHouse, smStraight, lgStraight, yahtzee, chance
    }
        public void roll(int points)
        {
         
          ScoreList[counter1] = points;
          counter1++;
        }

        public int score(){
          
          if(eChoosenQueue == null){
              
              return -1;

          }
           int result = 0;
           int counter = 0;
         
         while(counter < ScoreList.Length){

            if (eChoosenQueue.Count == 0)
            {
                break; // Exit the loop if the queue is empty
            }

          for(int i = 0; i < 5; i++) {

            if(ScoreList[counter + i] == (int)eChoosenQueue.Peek()){

              result += ScoreList[counter + i];
            }
               
           }

           counter += 5;
           eChoosenQueue.Dequeue();
           if(counter == 30 && result >= 63){

            result += 35;
           }
         }
           
          return result;
        }




}
}