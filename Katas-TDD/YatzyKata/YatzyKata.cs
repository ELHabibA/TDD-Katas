

namespace Katas_TDD.YatzyKata

{
 public class YatzyKata
{
       
    private int[]  ScoreList = new int[65];
    public Queue<eUpperSectionChoosen>? eUpperSectionChoosenQueue = null; 
    public Queue<eLowerSectionChoosen>? eLowerSectionChoosenQueue = null; 
    private int counter1 = 0;

    private int passedBox = 0;

    public enum eUpperSectionChoosen {
    ones = 1, twos, threes, fours, five, six
    }
    public enum eLowerSectionChoosen {
     threeOfaKind = 7, fourOfaKind, fullHouse, smStraight, lgStraight, yahtzee, chance
    }

    public enum eChoosedBox {
     ones = 1, twos = 2, threes = 4, fours = 8, five = 16, six = 32, threeOfaKind = 64, fourOfaKind = 128, fullHouse= 256, smStraight = 512, lgStraight = 1024, yahtzee = 2048, chance = 4096
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
              passedBox += (int)eChoosedBox.threeOfaKind;
            }

            if((int)eLowerSectionChoosenQueue.Peek() == 8){

              FourOfAKind(ScoreList, counter, counter+5, ref result);
              passedBox += (int)eChoosedBox.fourOfaKind;
            }

            if((int)eLowerSectionChoosenQueue.Peek() == 9){

              FullHouse(ScoreList, counter, counter+5, ref result);
              passedBox += (int)eChoosedBox.fullHouse;
            }

            if((int)eLowerSectionChoosenQueue.Peek() == 10){

              SmallStraight(ScoreList, counter, counter+5, ref result);
              passedBox += (int)eChoosedBox.smStraight;
            }

            if((int)eLowerSectionChoosenQueue.Peek() == 11){

              LangStraight(ScoreList, counter, counter+5, ref result);
              passedBox += (int)eChoosedBox.lgStraight;
            }

            if((int)eLowerSectionChoosenQueue.Peek() == 12){

              yahtzee(ScoreList, counter, counter+5, ref result);
              passedBox += (int)eChoosedBox.yahtzee;
            }

            if((int)eLowerSectionChoosenQueue.Peek() == 13){

              Chance(ScoreList, counter, counter+5, ref result);
              passedBox += (int)eChoosedBox.chance;
            }


           counter += 5;
           eLowerSectionChoosenQueue.Dequeue();
         }

      
          return result;
        }

 private void ThreeOfAKind(int[] arr, int from, int to, ref int  result){
  
  if ((Convert.ToInt32(Convert.ToString(passedBox, 2), 2) & Convert.ToInt32(Convert.ToString(64, 2), 2)) == 64)
  {
      return;
  }
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

  if ((Convert.ToInt32(Convert.ToString(passedBox, 2), 2) & Convert.ToInt32(Convert.ToString(128, 2), 2)) == 128)
  {
      return;
  }
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

  if ((Convert.ToInt32(Convert.ToString(passedBox, 2), 2) & Convert.ToInt32(Convert.ToString(256, 2), 2)) == 256)
  {
      return;
  }
    
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

  if ((Convert.ToInt32(Convert.ToString(passedBox, 2), 2) & Convert.ToInt32(Convert.ToString(512, 2), 2)) == 512)
  {
      return;
  }


    string str = "";
        int key;

        int[] arr2 = SortDiceValues(arr, from, to);

        for (int i = from; i < to -1; i++)
        {
            key = arr2[i];

            if (arr2[i + 1] == key+1)
            {

                str += arr2[i + 1];

            }

            else
            {
                continue;
            }

        }


        if(str.Length == 3) result += 30;

    
    
}

private void LangStraight(int[] arr, int from, int to, ref int  result){

  if ((Convert.ToInt32(Convert.ToString(passedBox, 2), 2) & Convert.ToInt32(Convert.ToString(1024, 2), 2)) == 1024)
  {
    return;
  }

    
        string str = "";
        int key;

        int[] arr2 = SortDiceValues(arr, from, to);

        for (int i = from; i < to -1; i++)
        {
            key = arr2[i];

            if (arr2[i + 1] == key+1)
            {

                str += arr2[i + 1];

            }

            else
            {
                continue;
            }

        }


        if(str.Length == 4) result += 40;
}

private int[] SortDiceValues(int[] arr, int from, int to){
   int key = 0;

  for(int i = from + 1; i < to; i++){
      
      key = arr[i];

    for(int j = i -1; j >= from; --j){

      if(arr[j] > key) arr[j+1] = arr[j];

      else break;
    }

    arr[i] = key;


  }

  return arr;


}

private void yahtzee(int[] arr, int from, int to, ref int  result){

if ((Convert.ToInt32(Convert.ToString(passedBox, 2), 2) & Convert.ToInt32(Convert.ToString(2048, 2), 2)) == 2048)
{
    return;
}


  for(int i = from; i > to; i++){

    if(arr[i] != arr[i +1]){
       return;
    }
  }

  result += 40;
 

}

private void Chance(int[] arr, int from, int to, ref int  result){

if ((Convert.ToInt32(Convert.ToString(passedBox, 2), 2) & Convert.ToInt32(Convert.ToString(4096, 2), 2)) == 4096)
{
    return;
}

  for(int i = from; i <= to; i++){

   result += arr[i];
  }
 

}


}
}