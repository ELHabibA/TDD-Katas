


public class RomanNumeralsKataTests
{

  [Fact]
  public void When_NumIs1()
  {
    var Roman = new RomanNumeralsKata();
  
    string expectedRoman = Roman.ConvertToRoman(1);  
    string actualRoman = "I";

    Assert.Equal(actualRoman, expectedRoman);
  }

    [Fact]
  public void When_NumIs2()
  {
    var Roman = new RomanNumeralsKata();
  
    string expectedRoman = Roman.ConvertToRoman(2);  
    string actualRoman = "II";

    Assert.Equal(actualRoman, expectedRoman);
  }

  [Fact]
  public void When_NumIs3()
  {
    var Roman = new RomanNumeralsKata();
  
    string expectedRoman = Roman.ConvertToRoman(3);  
    string actualRoman = "III";

    Assert.Equal(actualRoman, expectedRoman);
  }

  [Fact]
  public void When_NumIs10()
  {
    var Roman = new RomanNumeralsKata();
  
    string expectedRoman = Roman.ConvertToRoman(10);  
    string actualRoman = "X";

    Assert.Equal(actualRoman, expectedRoman);
  }

  [Fact]
  public void When_NumIs11()
  {
    var Roman = new RomanNumeralsKata();
  
    string expectedRoman = Roman.ConvertToRoman(11);  
    string actualRoman = "XI";

    Assert.Equal(actualRoman, expectedRoman);
  }

  [Fact]
  public void When_NumIs20()
  {
    var Roman = new RomanNumeralsKata();
  
    string expectedRoman = Roman.ConvertToRoman(20);  
    string actualRoman = "XX";

    Assert.Equal(actualRoman, expectedRoman);
  }
  
}