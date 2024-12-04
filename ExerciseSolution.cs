namespace AdventOfCode_2024;

public abstract class ExerciseSolution
{
    private const string Exercises = "Exercises";

    protected string _input = string.Empty;

    public async void Run()
    {
        Console.Clear();

        string fileName = Path.Combine(Exercises, Name() + ".txt");
        await using FileStream readStream = File.OpenRead(fileName);
        using StreamReader reader = new(readStream);
        Console.WriteLine(await reader.ReadToEndAsync());

        await FetchInput();

        Console.WriteLine("Solution:");

        Solve();

        Console.WriteLine();
        Console.WriteLine("Press any key to return.");
        Console.ReadKey();
    }

    private async Task FetchInput()
    {
        Console.WriteLine("Fetching input...");
        HttpClient http = new();
        http.DefaultRequestHeaders.Add("Cookie", Program.SessionCookie);

        try
        {
            _input = await http.GetStringAsync($"https://adventofcode.com/2024/day/{Day()}/input");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public abstract string Name();

    public abstract int Day();

    protected abstract void Solve();
}