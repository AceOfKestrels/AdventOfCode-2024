namespace AdventOfCode_2024.Solutions;

public class Day2 : ExerciseSolution
{

    public override string Name() => "Day 2 - Red-Nosed Reports";
    public override int Day() => 2;

    private int[][] _reports = [];

    private void ParseInput(string input)
    {
        string[] reports = input.Split(Environment.NewLine);
        _reports = new int[reports.Length][];

        for (int i = 0; i < reports.Length; i++)
        {
            string[] levels = input.Split(" ");
            _reports[i] = new int[levels.Length];

            for (int j = 0; j < levels.Length; j++)
            {
                _reports[i][j] = int.Parse(levels[j]);
            }
        }
    }

    protected override void Solve()
    {
        ParseInput(_input);
        
        foreach (int[] report in _reports)
        {
            foreach (int level in report)
            {
                Console.Write(level);
                Console.Write(" ");
            }

            Console.WriteLine(IsSafe(report) ? "Safe" : "Unsafe");
        }
    }

    private bool IsSafe(int[] report)
    {
        int increasing = 0;

        for (int i = 0; i < report.Length - 1; i++)
        {
            int difference = report[i] - report[i + 1];

            if (Math.Abs(difference) < 1 || Math.Abs(difference) > 3) return false;

            switch (increasing)
            {
                case 1:
                    if (difference < 0) return false;
                    break;
                case 2:
                    if (difference > 0) return false;
                    break;
                default:
                    increasing = difference > 0 ? 1 : 2;
                    break;
            }
        }

        return true;
    }
}