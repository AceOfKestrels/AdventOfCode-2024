namespace AdventOfCode_2024.Solutions;

public class Day2 : ExerciseSolution
{

    public override string Name() => "Day 2 - Red-Nosed Reports";

    private int[][] _reports = [];

    private void Setup()
    {
        Random rand = new();
        int amount = rand.Next(5, 20);

        _reports = new int[amount][];

        for (int i = 0; i < amount; i++)
        {
            int levelsAmount = rand.Next(3, 10);
            _reports[i] = new int[levelsAmount];

            for (int j = 0; j < levelsAmount; j++)
            {
                _reports[i][j] = rand.Next(1, 10);
            }
        }
    }

    protected override void Solve()
    {
        Setup();

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