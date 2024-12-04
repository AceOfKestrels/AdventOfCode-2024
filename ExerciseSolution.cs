namespace AdventOfCode_2024;

public abstract class ExerciseSolution
{
    private const string Exercises = "Exercises";

    public void Run()
    {
        Console.Clear();
        
        string fileName = Path.Combine(Exercises, Name() + ".txt");
        using FileStream readStream = File.OpenRead(fileName);
        using StreamReader reader = new(readStream);
        Console.WriteLine(reader.ReadToEnd());

        Solve();

        Console.WriteLine("Press any key to return.");
        Console.ReadKey();
    }

    public abstract string Name();

    protected abstract void Solve();
}