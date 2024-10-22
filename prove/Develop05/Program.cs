using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int Duration { get; set; }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {Name}: {Description}");
        Console.Write("Enter the duration of the activity (in seconds): ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);  // Small pause before starting
    }

    public void EndActivity()
    {
        Console.WriteLine($"Well done! You have completed {Name} for {Duration} seconds.");
        ShowSpinner(3);  // Pause before ending
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);  // 1 second delay for each dot
        }
        Console.WriteLine();
    }

    // Abstract method that will be implemented in derived classes
    public abstract void PerformActivity();
}
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by guiding you to breathe in and out slowly.";
    }

    public override void PerformActivity()
    {
        StartActivity();

        for (int i = 0; i < Duration; i += 2)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);  // 4-second countdown for breathing in
            Console.WriteLine("Breathe out...");
            ShowCountdown(4);  // 4-second countdown for breathing out
        }

        EndActivity();
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }
}
public class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection Activity";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    public override void PerformActivity()
    {
        StartActivity();

        Random rand = new Random();
        string prompt = Prompts[rand.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        ShowSpinner(3);

        int timeSpent = 0;
        while (timeSpent < Duration)
        {
            string question = Questions[rand.Next(Questions.Length)];
            Console.WriteLine(question);
            ShowSpinner(5);  // Pause for thinking
            timeSpent += 5;  // Each question allows for 5 seconds of reflection
        }

        EndActivity();
    }
}
public class ListingActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by listing as many things as you can in a certain area.";
    }

    public override void PerformActivity()
    {
        StartActivity();

        Random rand = new Random();
        string prompt = Prompts[rand.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine("You will have time to think and list items for the given prompt.");
        ShowSpinner(3);

        int itemCount = 0;
        int timeSpent = 0;
        while (timeSpent < Duration)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            itemCount++;
            timeSpent += 5;  // Assume each item takes around 5 seconds
        }

        Console.WriteLine($"You listed {itemCount} items.");
        EndActivity();
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid option.");
                    continue;
            }

            activity.PerformActivity();
        }
    }
}
