using System;
public abstract class Goal
{
    public string Name { get; private set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    protected Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
    }

    public abstract void RecordProgress();
    public abstract string DisplayProgress();
}
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordProgress()
    {
        IsComplete = true;
        Console.WriteLine($"Simple goal '{Name}' completed! You earned {Points} points.");
    }

    public override string DisplayProgress() => IsComplete ? $"[X] {Name}" : $"[ ] {Name}";
}
public class EternalGoal : Goal
{
    private int _count;

    public EternalGoal(string name, int points) : base(name, points)
    {
        _count = 0;
    }

    public override void RecordProgress()
    {
        _count++;
        Console.WriteLine($"Recorded '{Name}'. You earned {Points} points.");
    }

    public override string DisplayProgress() => $"[∞] {Name} - Completed {_count} times";
}
public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override void RecordProgress()
    {
        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            IsComplete = true;
            Console.WriteLine($"Checklist goal '{Name}' completed! You earned {Points + _bonusPoints} points.");
        }
        else
        {
            Console.WriteLine($"Recorded '{Name}'. You earned {Points} points. Progress: {_currentCount}/{_targetCount}");
        }
    }

    public override string DisplayProgress() => IsComplete ? $"[X] {Name} - Completed {_targetCount}/{_targetCount}" : $"[ ] {Name} - Completed {_currentCount}/{_targetCount}";
}
public class User
{
    public string UserName { get; set; }
    public int TotalPoints { get; private set; }
    public int Level { get; private set; }
    private List<Goal> Goals;

    public User(string userName)
    {
        UserName = userName;
        TotalPoints = 0;
        Level = 1;
        Goals = new List<Goal>();
    }

    public void AddGoal(Goal goal) => Goals.Add(goal);

    public void RecordGoal(string goalName)
    {
        Goal goal = Goals.Find(g => g.Name == goalName);
        if (goal != null && !goal.IsComplete)
        {
            goal.RecordProgress();
            TotalPoints += goal.Points;
            CheckLevelUp();
        }
        else
        {
            Console.WriteLine("Goal not found or already completed.");
        }
    }

    private void CheckLevelUp()
    {
        if (TotalPoints >= Level * 1000) // Example leveling threshold
        {
            Level++;
            Console.WriteLine($"Congratulations! You leveled up to Level {Level}!");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Current Goals:");
        foreach (var goal in Goals)
        {
            Console.WriteLine(goal.DisplayProgress());
        }
        Console.WriteLine($"Total Points: {TotalPoints}, Level: {Level}");
    }
}
class Program
{
    static void Main()
    {
        User user = new User("YourName");

        // Adding example goals
        user.AddGoal(new SimpleGoal("Run a Marathon", 1000));
        user.AddGoal(new EternalGoal("Read Scriptures", 100));
        user.AddGoal(new ChecklistGoal("Attend Temple", 50, 10, 500));

        // Display goals and allow the user to record progress
        while (true)
        {
            user.DisplayGoals();
            Console.WriteLine("\nEnter the name of the goal you completed (or type 'exit' to quit):");
            string goalName = Console.ReadLine();

            if (goalName.ToLower() == "exit")
                break;

            user.RecordGoal(goalName);
        }
    }
}
