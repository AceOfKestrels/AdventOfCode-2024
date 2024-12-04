namespace AdventOfCode_2024.Solutions;

public class Day1 : ExerciseSolution
{

    public override string Name()
    {
        return "Day 1 - Historian Hysteria";
    }

    private List<int> _list1 = [3, 4, 2, 1, 3, 3];
    private List<int> _list2 = [4, 3, 5, 3, 9, 3];
    
    private void Setup()
    {
        Random rand = new();
        int amount = rand.Next(5, 20);

        for (int i = 0; i < amount; i++)
        {
            _list1.Add(rand.Next(5, 20));
            _list2.Add(rand.Next(5, 20));
        }
    }

    protected override void Solve()
    {
        Setup();
        
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