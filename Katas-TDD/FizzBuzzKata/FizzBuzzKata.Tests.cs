

using Shouldly;

public class FizzBuzzKataTests
{
  
[Theory]
[InlineData(1)]
public void ConvertMthod_TakesIntegerAndReturnString(int num){

  FizzBuzzKata Num = new FizzBuzzKata();

  string str = Num.Convert(num);

  Assert.Equal("1", str);
}

[Theory]
[InlineData(2)]
public void When_TheInputIs2_ConverterReturns2(int num){

  FizzBuzzKata Num = new FizzBuzzKata();

  string str = Num.Convert(num);

  Assert.Equal("2", str);
}

[Theory]
[InlineData(3)]
public void When_TheInputIs3_ConverterReturnsFizz(int num){

  FizzBuzzKata Num = new FizzBuzzKata();

  string str = Num.Convert(num);

  Assert.Equal("Fizz", str);
}


[Theory]
[InlineData(9)]
public void When_TheInputIs9_ConverterReturnsFizz(int num){

  FizzBuzzKata Num = new FizzBuzzKata();

  string str = Num.Convert(num);

  Assert.Equal("Fizz", str);
}

[Theory]
[InlineData(5, 10, 55)]
public void When_TheInputIsMultipleOf5_ConverterReturnsBuzz(int num1, int num2, int num3){

  FizzBuzzKata Num = new FizzBuzzKata();

  string str1 = Num.Convert(num1);
  string str2 = Num.Convert(num2);
  string str3 = Num.Convert(num3);
  

  Assert.Equal("Buzz", str1);
  Assert.Equal("Buzz", str2);
  Assert.Equal("Buzz", str3);

}

[Theory]
[InlineData(30, 60, 90)]
public void When_TheInputIsMultipleOf5AndMultipleOf3_ConverterReturnsFizzBuzz(int num1, int num2, int num3){

  FizzBuzzKata Num = new FizzBuzzKata();

  string str1 = Num.Convert(num1);
  string str2 = Num.Convert(num2);
  string str3 = Num.Convert(num3);
  

  Assert.Equal("FizzBuzz", str1);
  Assert.Equal("FizzBuzz", str2);
  Assert.Equal("FizzBuzz", str3);

}
}