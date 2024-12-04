using System.Text.RegularExpressions;

namespace AdventOfCode_2024.Solutions;

public class Day3: ExerciseSolution
{

    public override string Name() => "Day 3 - Mull It Over";
    public override int Day() => 3;

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