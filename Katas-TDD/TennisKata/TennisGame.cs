

class TennisGame
{

    private string? player1 = "player1";
    private string? player2 = "player2";

    private int player1points = 0;
    private int player2points = 0;

public void WonPoint(string winner){
    
    if (winner == player1)
    {
         if (player1points == 30 || player1points == 40)
         {

            if (player2points == 50 && player1points == 40)
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
            if (player2points == 40 && player1points == 50)
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

    
    return $"{player1points}-{player2points}";
}
  
}