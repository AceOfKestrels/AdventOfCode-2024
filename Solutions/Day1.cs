namespace AdventOfCode_2024.Solutions;

public class Day1 : ExerciseSolution
{

    public override string Name() => "Day 1 - Historian Hysteria";

    public override int Day() => 1;

    private List<int> _list1 = [];
    private List<int> _list2 = [];

    private void ParseInput(string input)
    {
        string[] lines = input.Split(Environment.NewLine);

        foreach (string line in lines)
        {
            string[] parts = line.Split("   ");
            _list1.Add(int.Parse(parts[0]));
            _list2.Add(int.Parse(parts[1]));
        }
    }
    
    protected override void Solve()
    {
        ParseInput(_input);
        
        Console.WriteLine("List 1: " + string.Join(',', _list1));
        Console.WriteLine("List 2: " + string.Join(',', _list2));
        
        _list1.Sort();
        _list2.Sort();

        int totalDistance = 0;

        for (int i = 0; i < _list1.Count; i++)
        {
            totalDistance += Math.Abs(_list1[i] - _list2[i]);
        }
        
        Console.WriteLine("Total Distance: " + totalDistance);
    }
}