using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public JournalEntry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Convert the entry to a string format for displaying
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    // Add a new entry
    public void WriteEntry()
    {
        Random random = new Random();
        string selectedPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine("Prompt: " + selectedPrompt);
        Console.Write("Your Response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();
        JournalEntry entry = new JournalEntry(selectedPrompt, response, date);
        entries.Add(entry);
        Console.WriteLine("Entry saved!\n");
    }

    // Display all journal entries
    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
        }
        else
        {
            foreach (JournalEntry entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
    }

    // Save journal entries to a file
    public void SaveJournal()
    {
        Console.Write("Enter a filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in entries)
            {
                outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved!\n");
    }

    // Load journal entries from a file
    public void LoadJournal()
    {
        Console.Write("Enter a filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            entries.Clear(); // Clear current entries before loading
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new JournalEntry(parts[1], parts[2], parts[0]));
                }
            }
            Console.WriteLine("Journal loaded!\n");
        }
        else
        {
            Console.WriteLine("File not found.\n");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option (1-5): ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                journal.WriteEntry();
            }
            else if (option == "2")
            {
                journal.DisplayJournal();
            }
            else if (option == "3")
            {
                journal.SaveJournal();
            }
            else if (option == "4")
            {
                journal.LoadJournal();
            }
            else if (option == "5")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option, please try again.");
            }
        }
    }
}
