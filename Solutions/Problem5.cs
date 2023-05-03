using Shouldly;

namespace Test;

public class Problem5
{
    // Problem 5
    // Smallest multiple
    
    // Problem 5
    // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    
    // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

    // DONE : HasRemainder function
    // TODO : Loop to find first number divisible by all nums from 1 - 20 (Test case : Use 1-10! = 2520)

    // Notes: 
    // The number that is being divided is called the DIVIDEND
    // The number that it is being divided by is called the DIVISOR.
    // The result of the division is the QUOTIENT.
    
    [Theory]
    [InlineData(5, 5, false)]
    [InlineData(3, 5, true)]
    [InlineData(5, 3, true)]
    public void ShouldReturnTrueIfQuotientHasRemainder(int dividend, int divisor, bool expectedResult)
    {
        Problem5Solver.HasRemainder(dividend, divisor).ShouldBe(expectedResult);
    }

    [Fact]
    public void ShouldReturnSmallestPossibleNumberWhenDividingByAllNumbersFrom1To10()
    {
        Problem5Solver.GetSmallestNumberAllNumbersFrom1To10DivideInto().ShouldBe(2520);
    }
}

public static class Problem5Solver
{
    public static bool HasRemainder(int dividend, int divisor)
    {
        return (dividend % divisor != 0);
    }

    public static int GetSmallestNumberAllNumbersFrom1To10DivideInto()
    {
        int[] divisors = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        return SmallestNumberAllDivisorsDivideIntoCompletely(divisors.Max(), divisors);
    }

    private static int SmallestNumberAllDivisorsDivideIntoCompletely(int dividendCandidate, int[] divisors)
    {
        while (true)
        {
            var canDivide = false;
            foreach (var divisor in divisors)
            {
                canDivide = !HasRemainder(dividendCandidate, divisor);

                if (canDivide == false) break;
            }

            if (canDivide) break;
            dividendCandidate++;
        }

        return dividendCandidate;
    }
}