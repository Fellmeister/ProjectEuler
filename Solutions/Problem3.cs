using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Test;

public class Problem3
{

    /*

    Largest prime factor
 
    Problem 3
    The prime factors of 13195 are 5, 7, 13 and 29.

    What is the largest prime factor of the number 600851475143 ?
    
    Thoughts:
    
    IsPrime method: Prime is divisible by self and 1? Brute force it!

    */
    
    
    private readonly ITestOutputHelper output;

    public Problem3(ITestOutputHelper output)
    {
        this.output = output;
    }
    
    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(5, true)]
    [InlineData(6, false)]
    [InlineData(7, true)]
    [InlineData(8, false)]
    [InlineData(9, false)]
    [InlineData(10, false)]
    public void ShouldReturnTrueIfPrime(int numToTest, bool expectedResult)
    {
        Problem3Solver.IsPrime(numToTest).ShouldBe(expectedResult);
    }

    [Fact]
    public void ShouldReturnAllPossiblePrimeFactorsOfNumber()
    {
        var result = Problem3Solver.GetAllPrimeFactors(3000);

        result.Count().ShouldBe(4);
    } 
    
    [Fact]
    public void ShouldReturnMaximumPrimeFactorOfNumber()
    {
        var result = Problem3Solver.GetMaxPrimeFactorOfNumber(12345);

        result.ShouldBe(823);
    }
    
    [Fact]
    public void ShouldReturnMaximumPrimeFactorOfNumber_ANSWER()
    {
        var result = Problem3Solver.GetMaxPrimeFactorOfNumber(600851475143);

        result.ShouldBe(6857);
    }
}

public static class Problem3Solver
{
    public static bool IsPrime(long numToCheck)
    {
        if (numToCheck != 2 && numToCheck % 2 == 0) return false;
        // Try and divide it by every number less than itself?
        var hasBeenDivided = false;
        for (long i = numToCheck - 1; i > 1; i--)
        {
            hasBeenDivided = (numToCheck % i) == 0;
            if (hasBeenDivided && i > 1)
            {
                hasBeenDivided = true;
                break;
            }
        }

        return !hasBeenDivided;
    }

    public static List<long> GetAllPrimeFactors(long numToCheck)
    {
        var allPrimeFactors = new List<long>();

        for (long i = 1; i < numToCheck; i++)
        {
            
            if ((numToCheck % i) == 0)
            {
                if (IsPrime(i))
                {
                    allPrimeFactors.Add(i);
                    Console.WriteLine($"i ({i}) has been added");
                }
            }
        }
        
        return allPrimeFactors;
    }

    public static long GetMaxPrimeFactorOfNumber(long numToCheck)
    {
        var allPrimesFactors = GetAllPrimeFactors(numToCheck);
        return allPrimesFactors.TakeLast(1).ToList()[0];
    }
}