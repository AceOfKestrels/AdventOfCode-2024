using AdventOfCode_2024.Solutions;

namespace AdventOfCode_2024;

class Program
{

    private static readonly List<ExerciseSolution> Solutions =
    [
        new Day1()
    ];

    static void Main()
    {
        while (Start())
        {
        }
    }

    private static bool Start()
    {
        Console.Clear();
        Console.WriteLine("0 - Exit");

        for (int i = 1; i <= Solutions.Count; i++)
        {
            Console.WriteLine($"{i} - {Solutions[i - 1].Name()}");
        }

        Console.WriteLine();
        string? input = Console.ReadLine();

        int inputValue;

        if (!int.TryParse(input, out inputValue))
            return true;

        if (inputValue == 0)
            return false;

        Solutions[inputValue-1].Run();
        
        return true;
    }
}