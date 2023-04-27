using Shouldly;

namespace Test;

public class Problem1
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
    public void ShouldReturnTrueIfMultipleOf3(int num, bool expectedResult)
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
    public void ShouldReturnTrueIfMultipleOf5(int num, bool expectedResult)
    {
        // Arrange
        
        // Act
        var result = Solver.IsMultipleOf5(num);

        // Assert
        result.ShouldBe(expectedResult);
    }
    
    [Fact]
    public void ShouldReturnAllMultiplesOf3()
    {
        var list = new List<int> { 1, 3, 5, 6, 8, 9 };

        var result = Solver.GetMultiplesOf3(list);

        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        result.Count.ShouldBe(3);
    }
    
    [Fact]
    public void ShouldReturnAllMultiplesOf5()
    {
        var list = new List<int> { 1, 3, 5, 6, 8, 9 };

        var result = Solver.GetMultiplesOf5(list);

        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        result.Count.ShouldBe(1);
    }
    
    [Fact]
    public void ShouldReturnAllMultiplesOf3And5FromNaturalNumber()
    {
        var upperBound = 25;

        var result = Solver.GetAllMultiplesOf3And5FromNaturalNumber(upperBound);

        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();
        result.Count.ShouldBe(12);
    }
    
    [Theory]
    [InlineData(12, 33)]
    [InlineData(1000, 233168)] // ANSWER
    public void ShouldReturnSumOfAllMultiplesOf3And5FromNaturalNumber(int upperBound, int result)
    {
        Solver.GetSumOfAllMultiplesOf3And5FromNaturalNumber(upperBound).ShouldBe(result);
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
        return (numToCheck % multiple) == 0;
    }

    public static List<int> GetMultiplesOf3(List<int> list)
    {
        return list.Where(IsMultipleOf3).ToList();
    }

    public static List<int> GetMultiplesOf5(List<int> list)
    {
        return list.Where(IsMultipleOf5).ToList();
    }

    public static List<int> GetAllMultiplesOf3And5FromNaturalNumber(int upperBound)
    {
        var multiples = new List<int>();
        
        for (int i = 0; i < upperBound; i++)
        {
            if (IsMultipleOf3(i) || IsMultipleOf5(i))
            {
                multiples.Add(i);
            }
        }

        return multiples;
    }

    public static int GetSumOfAllMultiplesOf3And5FromNaturalNumber(int upperBound)
    {
        return GetAllMultiplesOf3And5FromNaturalNumber(upperBound).Sum();
    }
}