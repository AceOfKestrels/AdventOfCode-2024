using System.Text.RegularExpressions;

namespace AdventOfCode_2024.Solutions;

public class Day3: ExerciseSolution
{

    public override string Name() => "Day 3 - Mull It Over";

    private string _input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
    private string _regex = @"mul\(([0123456789,]+)\)";

    protected override void Solve()
    {
        int total = 0;
        foreach(Match match in Regex.Matches(_input, _regex))
        {
            if (!match.Success || match.Groups.Count < 2) break;
            total += MultiplyNumbersInString(match.Groups[1].Value);
        }
        
        Console.WriteLine("Input: " + _input);
        Console.WriteLine("Total: " + total);
    }

    private int MultiplyNumbersInString(string input)
    {
        string[] split = input.Split(',');
        int total = 1;

        foreach (string numberStr in split)
        {
            if (int.TryParse(numberStr, out int number)) total *= number;
        }

        return total;
    }
}