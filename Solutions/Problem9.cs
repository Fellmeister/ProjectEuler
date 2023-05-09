using Shouldly;

namespace Test;

public class Problem9
{
    // Problem 9
    // Special Pythagorean triplet

    // A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

    //          a² + b² = c²
    
    //          For example, 3² + 4² = 5²
    //                      = 9 + 16 = 25 .
    
    // There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    // Find the product abc.

    // Thoughts/rules...
    //      a < b < c
    //      a + b + c = 1000
    //      a² + b² = c²
    // Answer: Find product of abc =  a * b * c 
    
    // TODO: Find all combos of  a + b + c = 1000
    // TODO: Find combos of  a + b + c = 1000 where a² + b² = c²
    // TODO: Find product of abc =  a * b * c

    [Fact]
    public void ShouldReturnCombinationsOfThreeNaturalNumbersThatEqual1000()
    {
        var result = Problem9Solver.GetThreeNumbersThatAddTo1000();

        result.ShouldNotBeNull();
        result.Count().ShouldNotBe(0);
        foreach (var multiple in result)
        {
            multiple.Sum.ShouldBe(1000);
        }
    }
}

public static class Problem9Solver
{
    
    public static List<Multiples> GetThreeNumbersThatAddTo1000()
    {
        List<int> numbers = new List<int>();

        for (int i = 1; i < 700; i++)
        {
            numbers.Add(i);
        }
        
        int target = 1000;
        sum_up(numbers, target);
        
        
        return new List<Multiples>();
    }
    
    

    private static void sum_up(List<int> numbers, int target)
    {
        sum_up_recursive(numbers, target, new List<int>());
    }

    private static void sum_up_recursive(List<int> numbers, int target, List<int> partial)
    {
        int s = 0;
        foreach (int x in partial) s += x;

        if (s == target && partial.Count() == 3)
            Console.WriteLine("sum(" + string.Join(",", partial.ToArray()) + ")=" + target);

        if (s >= target)
            return;

        for (int i = 0; i < numbers.Count; i++)
        {
            List<int> remaining = new List<int>();
            int n = numbers[i];
            for (int j = i + 1; j < numbers.Count; j++) remaining.Add(numbers[j]);

            List<int> partial_rec = new List<int>(partial);
            partial_rec.Add(n);
            sum_up_recursive(remaining, target, partial_rec);
        }
    }
}

public class Multiples
{
    public int A;
    public int B;
    public int C;

    public int Sum => A + B + C;
}