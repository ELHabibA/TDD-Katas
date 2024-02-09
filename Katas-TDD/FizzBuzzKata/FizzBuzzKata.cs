class FizzBuzzKata
{


  public string Convert(int num){
    

    if (IsFizzBuzz(num))
    {
       return "FizzBuzz";
    }

    else if (IsFizz(num))
    {
      return "Fizz";
    }

    else if (IsBuzz(num))
    {
      return "Buzz";
    }

    return num.ToString();

  }

  private bool IsFizzBuzz(int num){

    return (num % 3 == 0) && (num % 5 == 0);
  }

  private bool IsFizz(int num){

    return (num % 3 == 0);
  }

  private bool IsBuzz(int num){

    return (num % 5 == 0);
  }
  
}