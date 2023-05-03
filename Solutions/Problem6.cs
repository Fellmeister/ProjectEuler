using Shouldly;

namespace Test;

public class Problem6
{
    // Sum square difference
    
    // Problem 6
    // The sum of the squares of the first ten natural numbers is 385,
   
    // The square of the sum of the first ten natural numbers is 3025,
   
    // Hence the difference between the sum of the squares of the first ten natural numbers and the
    // square of the sum is 3025 - 385 = 2640
    
    // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    
    // DONE : Sum of Squares for n numbers.
    // DONE : Square Of Sum of n numbers.
    // DONE : Difference of SquareOfSums and SumOfSquares for n numbers.

    [Fact]
    public void ShouldReturnSumOfSquaresForFirstTenNumbers()
    {
        int count = 10;
        var expected = 385;
        
        var result = Problem6Solver.GetSumOfSquares(count);
        
        result.ShouldBe(expected);
    }

    [Fact]
    public void ShouldReturnSquareOfSumForFirstTenNumbers()
    {
        int count = 10;
        var expected = 3025;
        
        var result = Problem6Solver.GetSquareOfSums(count);
        
        result.ShouldBe(expected);
    }

    [Fact]
    public void ShouldReturnDifferenceOfSquareOfSumsAndSumOfSquaresForFirstTenNumbers()
    {
        int count = 10;
        var expected = 2640;
        
        var result = Problem6Solver.GetDifferenceOfSquareOfSumsAndSumOfSquares(count);
        
        result.ShouldBe(expected);
    }
    
    [Fact]
    public void ShouldReturnDifferenceOfSquareOfSumsAndSumOfSquaresForFirstHundredNumbers_ANSWER()
    {
        int count = 100;
        var expected = 25164150;
        
        var result = Problem6Solver.GetDifferenceOfSquareOfSumsAndSumOfSquares(count);
        
        result.ShouldBe(expected);
    }
}

public static class Problem6Solver
{
    public static int GetSumOfSquares(int count)
    {
        var total = 0;
        
        for (int i = 1; i <= count; i++)
        {
            total += i * i;
        }

        return total;
    }

    public static int GetSquareOfSums(int count)
    {
        var total = 0;
        
        for (int i = 1; i <= count; i++)
        {
            total += i;
        }

        return total * total;
    }

    public static int GetDifferenceOfSquareOfSumsAndSumOfSquares(int count)
    {
        return GetSquareOfSums(count) - GetSumOfSquares(count);
    }
}