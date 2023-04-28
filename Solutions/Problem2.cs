using Shouldly;

namespace Test;

public class Problem2
{
    // Even Fibonacci numbers
    // Problem 2
    
    // Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
    
    // 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    
    // By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.

    // Thoughts....
    
    // Generate Fibonacci Numbers where fN < 4M
    // Gather even numbers
    // Sum them

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(3, false)]
    [InlineData(4, true)]
    [InlineData(5, false)]
    public void ShouldReturnTrueWhenNumberIsEven(int numToTest, bool expected)
    {
        Problem2Solver.IsEven(numToTest).ShouldBe(expected);
    }

    [Fact]
    public void ShouldGenerateFibonacciSequenceFromTwoStartingNumbers()
    {
        var firstNum = 1;
        var secondNum = 2;
        var numOfSequenceItems = 10;

        List<int> result = Problem2Solver.GenerateFibonacciSequence(firstNum, secondNum, numOfSequenceItems).ToList();
        
        result.Count().ShouldBe(10);
    }
}

public static class Problem2Solver
{
    public static bool IsEven(int i)
    {
        return (i % 2) == 0;
    }

    public static List<int> GenerateFibonacciSequence(int firstNum, int secondNum, int numOfSequenceItems)
    {
        List<int> fibSeq = new List<int>();
        
        fibSeq.Add(firstNum);
        fibSeq.Add(secondNum);

        var firstPrevNum = firstNum;
        var secondPrevNum = secondNum;
        
        for (int i = 0; i < numOfSequenceItems - 2; i++)
        {
            var result = firstPrevNum + secondPrevNum;
            fibSeq.Add(result);
            firstPrevNum = secondPrevNum;
            secondPrevNum = result;
        }
        
        return fibSeq;
    }
    
    
}