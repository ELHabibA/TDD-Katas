



public class RomanNumeralsKata
{




    public string ConvertToRoman(int num)
    {

      string result = "";
      int k = 0;
      string[] romans = {"I", "X"};

      for (int i = num; i > 0; --i)
      {
            if (i >= 10)
            {
              k = 1;
              result += romans[k];
              i -= 9;
            }
            else{
            
            k = 0;
            result += romans[k];

            }
      }


      return result;
    }
}