
using System.Security.Cryptography;

namespace Katas_TDD.YatzyKata

{
 public class YatzyKata
{
       
    int[]  ScoreList = new int[65];
    public Queue<eUpperSectionChoosen>? eUpperSectionChoosenQueue = null; 
     public Queue<eLowerSectionChoosen>? eLowerSectionChoosenQueue = null; 
    private int counter1 = 0;

    public enum eUpperSectionChoosen {
    ones = 1, twos, threes, fours, five, six
    }
    public enum eLowerSectionChoosen {
     threeOfaKind = 7, fourOfaKind, fullHouse, smStraight, lgStraight, yahtzee, chance
    }

        public void roll(int points)
        {
         
          ScoreList[counter1] = points;
          counter1++;
        }

        public int score(){

           int result = 0;
           int counter = 0;
          
          if(eUpperSectionChoosenQueue == null){
              
              return -1;

          }
         
         while(counter < 30){

            if (eUpperSectionChoosenQueue.Count == 0)
            {
                break; 
            }

          for(int i = 0; i < 5; i++) {

            if(ScoreList[counter + i] == (int)eUpperSectionChoosenQueue.Peek()){

              result += ScoreList[counter + i];
            }
               
           }

           counter += 5;
           eUpperSectionChoosenQueue.Dequeue();
         }

        if(result >= 63){   //Bonus

            result += 35;
        }

         while(counter < ScoreList.Length){

            if (eLowerSectionChoosenQueue == null || eLowerSectionChoosenQueue.Count == 0)
            {
                break;
            }


            if((int)eLowerSectionChoosenQueue.Peek() == 7){

              ThreeOfAKind(ScoreList, counter, counter+5, ref result);
            }

            if((int)eLowerSectionChoosenQueue.Peek() == 8){

              FourOfAKind(ScoreList, counter, counter+5, ref result);
            }

            if((int)eLowerSectionChoosenQueue.Peek() == 9){

              FullHouse(ScoreList, counter, counter+5, ref result);
            }

           counter += 5;
           eLowerSectionChoosenQueue.Dequeue();
         }

      
          return result;
        }

 private void ThreeOfAKind(int[] arr, int from, int to, ref int  result){
    int[] tmparr = new int[5];
    int count = 0;

    for(int i = 0; i < 5; i++){
         tmparr[i] = 0;
    }

    for(int i = from; i < to; i++){
      
      for(int j = from; j < to; j++){

        if(arr[i] == arr[j]){ 

          tmparr[count] = arr[j];
          count++;

        }

      }

      if(tmparr[2] != 0){

      for(int k = 0; k < 3; k++){
          result += tmparr[k];
       }
        break;
      }
    
      count = 0;
    }

 }

  private void FourOfAKind(int[] arr, int from, int to, ref int  result){
    int[] tmparr = new int[5];
    int count = 0;

    for(int i = 0; i < 5; i++){
         tmparr[i] = 0;
    }

    for(int i = from; i < to; i++){
      
      for(int j = from; j < to; j++){

        if(arr[i] == arr[j]){ 

          tmparr[count] = arr[j];
          count++;

        }

      }

      if(tmparr[3] != 0){

      for(int k = 0; k < 4; k++){
          result += tmparr[k];
       }
        break;
      }
    
      count = 0;
    }

    
 }

 private void FullHouse(int[] arr, int from, int to, ref int  result){
    
    string str1 = "";
    string str2 = "";

    for(int i = from; i < to; i++){


       if(arr[from] == arr[i]){
            str1 += arr[i];
       }

       else{

            str2 += arr[i];
       }
     }

     if(str1.Length != 2 && str1.Length != 3){

      return;

     }
     for(int i = str2.Length-1; i > 0; i--){

      if(str2[i] != str2[i-1]){
        return;
      }

     }

     result += 25;
    
 }


}
}