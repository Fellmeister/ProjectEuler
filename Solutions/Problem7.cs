using Shouldly;

namespace Test;

public class Problem7
{
    // Problem 7
    // 10001st prime

    // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    //
    // What is the 10001st prime number?
    
    // DONE : Create collection of Prime Numbers upto N

    [Fact]
    public void ShouldCreateCollectionOfPrimeNumbersFor10PrimeNumbers()
    {
        var count = 10;
        
        var result = Problem7Solver.GetCollectionOfPrimeNumbers(count);

        result.Count.ShouldBe(count);
    }
    
}

public static class Problem7Solver
{
    public static List<int> GetCollectionOfPrimeNumbers(int count)
    {
        var primeList = new List<int>();
        var i = 2;
        while (primeList.Count < count)
        {
            if (Problem3Solver.IsPrime(i)) primeList.Add(i);
            i++;
        }

        return primeList;
    }
}