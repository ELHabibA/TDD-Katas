

public class RomanNumeralsKata
{
    

    public string ConvertToRoman(int num)
    {

      int[] numbers = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
      string[] romanNumerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        string result = "";
        int remainingValue = num;

        for (int i = 0; i < numbers.Length; i++)
        {
            while (remainingValue >= numbers[i])
            {
                result += romanNumerals[i];
                remainingValue -= numbers[i];
            }
        }

        return result;
    }
}
