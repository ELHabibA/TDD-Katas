

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
          
  ProcessUpperSectionChoice(ref result, ref counter);

  ProcessLowerSectionChoice(ref result, ref counter);

      
  return result;

}

private void AddSimilarDice(ref int result, int counter, int dice){
  
  bool IsBoxAvailable = CheckBoxAvailability();

 if(IsBoxAvailable){

    for(int i = 0; i < 5; i++) {

    if(ScoreList[counter + i] == dice){

      result += ScoreList[counter + i];

    }

 }
        
}

}

private bool CheckBoxAvailability(){

    if(eUpperSectionChoosenQueue == null){
    
    return false;

    }

    else if ((passedBox & (int)eUpperSectionChoosenQueue.Peek()) == 1 && (int)eUpperSectionChoosenQueue.Peek() == 1)
    {
        return false;
    }

    else if ((passedBox & (int)eUpperSectionChoosenQueue.Peek()) == 2 && (int)eUpperSectionChoosenQueue.Peek() == 2)
    {
        return false;
    }

    else if ((passedBox & 4) == 4 && (int)eUpperSectionChoosenQueue.Peek() == 3)
    {
        return false;
    }

    else if ((passedBox & 8) == 8 && (int)eUpperSectionChoosenQueue.Peek() == 4)
    {
        return false;
    }

    else if ((passedBox & 16) == 6 && (int)eUpperSectionChoosenQueue.Peek() == 5)
    {
        return false;
    }

    else if ((passedBox & 32) == 32 && (int)eUpperSectionChoosenQueue.Peek() == 6)
    {
        return false;
    }

    return true;

}

private void ProcessUpperSectionChoice(ref int result, ref int counter){

  if(eUpperSectionChoosenQueue == null){
    
    return;

  }

    while(counter < 30 && eUpperSectionChoosenQueue.Count > 0){

    switch ((int)eUpperSectionChoosenQueue.Peek())
      {
                case 1:
                    AddSimilarDice(ref result, counter, (int)eUpperSectionChoosenQueue.Peek());
                    passedBox += (int)eChoosedBox.ones;
                    break;
                case 2:
                    AddSimilarDice(ref result, counter, (int)eUpperSectionChoosenQueue.Peek());
                    passedBox += (int)eChoosedBox.twos;
                    break;
                case 3:
                    AddSimilarDice(ref result, counter, (int)eUpperSectionChoosenQueue.Peek());
                    passedBox += (int)eChoosedBox.threes;
                    break;
                case 4:
                    AddSimilarDice(ref result, counter, (int)eUpperSectionChoosenQueue.Peek());
                    passedBox += (int)eChoosedBox.fours;
                    break;
                case 5:
                    AddSimilarDice(ref result, counter, (int)eUpperSectionChoosenQueue.Peek());
                    passedBox += (int)eChoosedBox.five;
                    break;
                case 6:
                    AddSimilarDice(ref result, counter, (int)eUpperSectionChoosenQueue.Peek());
                    passedBox += (int)eChoosedBox.six;
                    break;
    }

     counter += 5;
     eUpperSectionChoosenQueue.Dequeue();
    }
      
    if(result >= 63){   //Bonus

        result += 35;
    }

}

public void ProcessLowerSectionChoice(ref int result, ref int counter)
{

    while (counter < ScoreList.Length)
    {
        if (eLowerSectionChoosenQueue == null || eLowerSectionChoosenQueue.Count == 0)
        {
            break;
        }

        switch ((int)eLowerSectionChoosenQueue.Peek())
        {
            case 7:
                ThreeOfAKind(ScoreList, counter, counter + 5, ref result);
                passedBox += (int)eChoosedBox.threeOfaKind;
                break;

            case 8:
                FourOfAKind(ScoreList, counter, counter + 5, ref result);
                passedBox += (int)eChoosedBox.fourOfaKind;
                break;

            case 9:
                FullHouse(ScoreList, counter, counter + 5, ref result);
                passedBox += (int)eChoosedBox.fullHouse;
                break;

            case 10:
                SmallStraight(ScoreList, counter, counter + 5, ref result);
                passedBox += (int)eChoosedBox.smStraight;
                break;

            case 11:
                LangStraight(ScoreList, counter, counter + 5, ref result);
                passedBox += (int)eChoosedBox.lgStraight;
                break;

            case 12:
                yahtzee(ScoreList, counter, counter + 5, ref result);
                passedBox += (int)eChoosedBox.yahtzee;
                break;

            case 13:
                Chance(ScoreList, counter, counter + 5, ref result);
                passedBox += (int)eChoosedBox.chance;
                break;
        }

        counter += 5;
        eLowerSectionChoosenQueue.Dequeue();
    }
}


 private void ThreeOfAKind(int[] arr, int from, int to, ref int  result){
  
  if ((passedBox & 64) == 64)
  {
      return;
  }

    int[] tmparr = new int[5];
    int count = 0;

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

  if ((passedBox & 128) == 128)
  {
      return;
  }

    int[] tmparr = new int[5];
    int count = 0;

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

  if ((passedBox & 256) == 256)
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
  
  if ((passedBox & 512) == 512)
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
  
  if ((passedBox & 1024) == 1024)
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

if ((passedBox & 2048) == 2048)
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

if ((passedBox & 4096) == 4096)
{
    return;
}

  for(int i = from; i <= to; i++){

   result += arr[i];
  }
 

}


}
}