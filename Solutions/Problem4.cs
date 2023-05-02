using Shouldly;

namespace Test;

public class Problem4
{
    // Largest palindrome product

    // Problem 4
    // A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit
    // numbers is 9009 = 91 × 99.
    
    // Find the largest palindrome made from the product of two 3-digit numbers.
    
    // DONE: IsPalindrome
    // DONE: Loop through all three digits number combos (Brute Force)

    [Theory]
    [InlineData(123321, true)]
    [InlineData(12321, true)]
    [InlineData(12331, false)]
    [InlineData(3321, false)]
    public void ShouldReturnTrueForPalindromeNumber(int numToCheck, bool expectedResult)
    {
        Problem4Solver.IsPalindrome(numToCheck).ShouldBe(expectedResult);
    }

    [Fact]
    public void ShouldReturnHighestThreeDigitFactorsInPalindrome_ANSWER()
    {
        var result = Problem4Solver.HighestDigitList();
        
        result.ShouldBe(906609);
    }

}

public static class Problem4Solver
{
    public static bool IsPalindrome(int numToCheck)
    {
        var charList = numToCheck.ToString().Select(x => x).ToList<char>();
        var reversedCharList = ReverseMyCharList(charList);
        
       return charList.SequenceEqual(reversedCharList);
    }

    private static List<char>? ReverseMyCharList(List<char> charList)
    {
        List<char>? reverseCharList = charList.ToList();
        if (reverseCharList != null)
        {
            reverseCharList.Reverse();
        }

        return reverseCharList;
    }

    public static int HighestDigitList()
    {
        var highestDigitList = new List<int>();
        
        for (int i = 999; i >= 100; i--)
        {
            for (int j = 999; j >= 100; j--)
            {
                if (IsPalindrome(i * j))
                {
                    highestDigitList.Add(i * j);            
         
                }
            }
        }

        return highestDigitList.Max();
    }
}