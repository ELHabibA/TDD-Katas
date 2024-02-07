

using System.Diagnostics.Metrics;

class TennisGame
{

    private string? player1 = "player1";
    private string? player2 = "player2";

    private int[] player1Sets = new int[4];
    private int[] player2Sets = new int[4];
    private int player1points = 0;
    private int player2points = 0;
    private  int counter = 0;

public void WonPoint(string winner){
    
    if (winner == player1)
    {
         if (player1points >= 30)
         {
             if(player2points < 40 && player1points == 40){

                player1points = 0;
                player2points = 0;

                AddOnePointToSet(ref player1Sets, ref player2Sets);
                return;

             }

            else if(player2points == 40 && player1points == 50){

                player1points = 0;
                player2points = 0;
                AddOnePointToSet(ref player1Sets, ref player2Sets);
                return;

             }

            else if (player2points == 50 && player1points == 40)
            {
                player1points = 40;
                player2points = 40;
                return;
            }

            player1points += 10;
         }
        else
        {
            player1points += 15;
        }
       
    }

    else if (winner == player2)
    {

        if (player2points >= 30)
        {
            if(player1points < 40 && player2points == 40){

                player1points = 0;
                player2points = 0;
                AddOnePointToSet(ref player2Sets, ref player1Sets);
                return;

            }

            else if(player2points == 50 && player1points == 40){

                player1points = 0;
                player2points = 0;
                 AddOnePointToSet(ref player2Sets, ref player1Sets);

                return;

            }

            else if (player2points == 40 && player1points == 50)
            {
                player1points = 40;
                player2points = 40;
                return;
            }

            player2points += 10;

        }

         else {

             player2points += 15;

         }
    }


}

public string Score(){
      
    int player1FirstSet = player1Sets[0];
    int Player2FirstSet = player2Sets[0];
    int player1SecondSet = player1Sets[1];
    int Player2SecondSet = player2Sets[1];
    int player1ThirdSet = player1Sets[2];
    int Player2ThirthSet = player2Sets[2];

    if (counter == 2)
    {
        return $"{player1FirstSet}-{Player2FirstSet} | {player1SecondSet}-{Player2SecondSet} | {player1ThirdSet}-{Player2ThirthSet} || {player1points}-{player2points}";
    }
    
    if (counter == 1)
    {
        return $"{player1FirstSet}-{Player2FirstSet} | {player1SecondSet}-{Player2SecondSet} || {player1points}-{player2points}";
    }


    else{

        return $"{player1FirstSet}-{Player2FirstSet} || {player1points}-{player2points}";

    }
}


private void AddOnePointToSet(ref int[] winner, ref int[] looser){

    if (winner[counter] < 6 || looser[counter] == 5 || looser[counter] == 6)
    {
        if (winner[counter] == 7)
        {
            counter += 1;
             if (counter > 2)
                {
                    counter = 2;
                    return;
                }
        }
        winner[counter] += 1;
    }

    else if (winner[counter] == 6 && looser[counter] < 5)
    {
        counter += 1;
         if (counter > 2)
            {
                counter = 2;
                return;
            }
        winner[counter] += 1;
    }

    
}
  
}