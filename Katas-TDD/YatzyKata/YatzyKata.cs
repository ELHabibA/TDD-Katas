
using System.Globalization;
using System.Linq.Expressions;
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

            if((int)eLowerSectionChoosenQueue.Peek() == 10){

              SmallStraight(ScoreList, counter, counter+5, ref result);
            }

            if((int)eLowerSectionChoosenQueue.Peek() == 11){

              LangStraight(ScoreList, counter, counter+5, ref result);
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

private void SmallStraight(int[] arr, int from, int to, ref int  result){
    int key = arr[0];
    int count = 0;
    int[] newArr = new int[3];

    for(int i = 0; i < 3; i++){
         newArr[i] = 0;
    }

    SortDiceValues(ref arr, from, to);

    for(int i = from; i < to; i++){
       
      if(key == (arr[i+1]-1)){
           
           newArr[i] = arr[i+1];
           count++;
      }
      else{
        key = arr[i+1];
        count = 0;
      }

    }

    
    
}

private void LangStraight(int[] arr, int from, int to, ref int  result){
    
    
}

private void SortDiceValues(ref int[] arr, int from, int to){
   int key = 0;

  for(int i = from + 1; i > to; i++){
      
      key = arr[i];

    for(int j = i -1; i >= from; --j){

      if(arr[j] > key) arr[j+1] = arr[j];

      else break;
    }

    arr[i] = key;


  }


}



}
}