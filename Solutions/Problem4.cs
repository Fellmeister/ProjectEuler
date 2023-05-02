using Shouldly;
using Xunit.Sdk;

namespace Test;

public class Problem4
{
    // Largest palindrome product

    // Problem 4
    // A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit
    // numbers is 9009 = 91 × 99.
    //
    // Find the largest palindrome made from the product of two 3-digit numbers.
    
    // DONE: IsPalindrome
    // TODO: Loop through all three digits number combos (Brute Force)

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
        
       
        var retVal = true;
        
        for (int i = 0; i < charList.Count / 2; i++)
        {
            if (DoIndexCharAndInverseIndexCharMatch(charList, i) && retVal) continue;
            retVal = false;
            break;
        }

        return retVal;
    }

    private static List<char>? ReverseMyCharList(List<char> charList)
    {
        List<char>? reverseCharList = charList;
        if (reverseCharList != null)
        {
            reverseCharList.Reverse();
        }

        return reverseCharList;
    }

    private static bool DoIndexCharAndInverseIndexCharMatch(List<char> charList, int i)
    {
        return charList[i] == charList[charList.Count - 1 - i];
    }

    public static int HighestDigitList()
    {
        var highestDigitList = new List<int>();
        
        for (int i = 999; i >= 100; i--)
        {
            for (int j = 999; j >= 100; j--)
            {
                var temp = i * j;
                if (IsPalindrome(temp))
                {
                    highestDigitList.Add(temp);            
         
                }
            }
        }

        return highestDigitList.Max();
    }
}