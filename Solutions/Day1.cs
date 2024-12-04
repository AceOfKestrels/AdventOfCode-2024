namespace AdventOfCode_2024.Solutions;

public class Day1 : ExerciseSolution
{

    public override string Name() => "Day 1 - Historian Hysteria";

    public override int Day() => 1;

    private List<int> _list1 = [];
    private List<int> _list2 = [];

    private void ParseInput(string input)
    {
        string[] lines = input.Split("\n");

        foreach (string line in lines)
        {
            string[] parts = line.Split("   ");
            int val2 = 0;
            bool success = int.TryParse(parts[0], out int val1) && int.TryParse(parts[1], out val2);

            if (success)
            {
                _list1.Add(val1);
                _list2.Add(val2);
            }
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