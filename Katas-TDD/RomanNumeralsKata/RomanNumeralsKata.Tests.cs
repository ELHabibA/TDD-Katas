public class RomanNumeralsKataTests
{
    private readonly RomanNumeralsKata Roman;

    public RomanNumeralsKataTests()
    {
        Roman = new RomanNumeralsKata();
    }

    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(11, "XI")]
    [InlineData(14, "XIV")]
    [InlineData(20, "XX")]
    [InlineData(27, "XXVII")]
    [InlineData(36, "XXXVI")]
    [InlineData(39, "XXXIX")]
    [InlineData(43, "XLIII")]
    [InlineData(60, "LX")]
    [InlineData(70, "LXX")]
    [InlineData(86, "LXXXVI")]
    [InlineData(99, "XCIX")]
    [InlineData(350, "CCCL")]
    [InlineData(430, "CDXXX")]
    [InlineData(623, "DCXXIII")]
    [InlineData(1980, "MCMLXXX")]
    [InlineData(1991, "MCMXCI")]
    public void ConvertToRoman_ReturnsExpectedResult(int number, string expectedRoman)
    {
        string actualRoman = Roman.ConvertToRoman(number);
        Assert.Equal(expectedRoman, actualRoman);
    }
}
