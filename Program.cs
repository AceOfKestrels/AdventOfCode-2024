using AdventOfCode_2024.Solutions;

namespace AdventOfCode_2024;

class Program
{

    private static readonly List<ExerciseSolution> Solutions =
    [
        new Day1(),
        new Day2(),
        new Day3()
    ];

    public static string SessionCookie = string.Empty;

    static async Task Main()
    {
        while (!await AskForSessionCookie())
        {
        }

        while (Start())
        {
        }
    }

    private static async Task<bool> AskForSessionCookie()
    {
        Console.Clear();
        Console.WriteLine("Please enter an AoC session cookie: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input)) return false;

        SessionCookie = input.StartsWith("session=") ? input : "session=" + input;

        return await TestSession();
    }

    private static bool Start()
    {
        Console.Clear();
        Console.WriteLine("Please select an exercise to run:");
        Console.WriteLine();
        Console.WriteLine("0 - Exit");

        for (int i = 1; i <= Solutions.Count; i++)
        {
            Console.WriteLine($"{i} - {Solutions[i - 1].Name()}");
        }

        Console.WriteLine();
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int inputValue))
            return true;

        if (inputValue == 0)
            return false;

        Solutions[inputValue - 1].Run();

        return true;
    }

    private static async Task<bool> TestSession()
    {
        Console.WriteLine("Testing connection to adventofcode.com");
        HttpClient http = new();
        http.DefaultRequestHeaders.Add("Cookie", SessionCookie);

        HttpResponseMessage response = await http.GetAsync("https://adventofcode.com/2024/day/1/input");

        Console.WriteLine(response.IsSuccessStatusCode ? "Connection successful." : "Connection failed. Please try again.");
        Console.WriteLine("Press any key to continue.");
        
        Console.ReadKey();
        
        return response.IsSuccessStatusCode;
    }
}