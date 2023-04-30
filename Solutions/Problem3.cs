using Shouldly;
using Xunit;

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

}

public static class Problem3Solver
{
    public static bool IsPrime(int numToCheck)
    {
        // Try and divide it by every number less than itself?
        var hasBeenDivided = false;
        for (int i = numToCheck - 1; i > 1; i--)
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
}