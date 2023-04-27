using System.Security.Cryptography;
using Shouldly;

namespace Test;

public class Problem_1
{
    // Problem 1
    // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    //
    // Find the sum of all the multiples of 3 or 5 below 1000.
    
    [Theory]
    [InlineData(3, true)]
    [InlineData(6, true)]
    [InlineData(30, true)]
    [InlineData(2, false)]
    [InlineData(22, false)]
    public void ShouldReturnMultipleOf3(int num, bool expectedResult)
    {
        // Arrange
        
        // Act
        var result = Solver.IsMultipleOf3(num);

        // Assert
        result.ShouldBe(expectedResult);
    } 
    
    [Theory]
    [InlineData(5, true)]
    [InlineData(25, true)]
    [InlineData(30, true)]
    [InlineData(2, false)]
    [InlineData(22, false)]
    public void ShouldReturnMultipleOf5(int num, bool expectedResult)
    {
        // Arrange
        
        // Act
        var result = Solver.IsMultipleOf5(num);

        // Assert
        result.ShouldBe(expectedResult);
    }
    
    
}

public static class Solver
{
    public static bool IsMultipleOf3(int numToCheck)
    {
        return IsMultipleOf(3, numToCheck);
    }
    
    public static bool IsMultipleOf5(int numToCheck)
    {
        return IsMultipleOf(5, numToCheck);
    }
    
    private static bool IsMultipleOf(int multiple, int numToCheck)
    { 
        return (numToCheck % multiple) == 0;return false;
    }
}