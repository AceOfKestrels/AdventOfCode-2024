namespace AdventOfCode_2024;

class Program
{

    private static readonly List<ExerciseSolution> Solutions =
    [
    ];

    static void Main()
    {
        while (Start())
        {
        }
    }

    private static bool Start()
    {
        Console.WriteLine("0 - Exit");

        for (int i = 1; i <= Solutions.Count; i++)
        {
            Console.WriteLine($"{i} - {Solutions[i - 1].Name}");
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