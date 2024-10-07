public class ScriptureReference
{
    public string Book { get; private set; }
    public int StartChapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndChapter { get; private set; } // Nullable for single verse cases
    public int? EndVerse { get; private set; }

    // Constructor for a single verse
    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        StartChapter = chapter;
        StartVerse = verse;
        EndChapter = null;
        EndVerse = null;
    }

    // Constructor for a verse range
    public ScriptureReference(string book, int startChapter, int startVerse, int endChapter, int endVerse)
    {
        Book = book;
        StartChapter = startChapter;
        StartVerse = startVerse;
        EndChapter = endChapter;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndChapter == null || EndVerse == null)
            return $"{Book} {StartChapter}:{StartVerse}";
        else
            return $"{Book} {StartChapter}:{StartVerse}-{EndChapter}:{EndVerse}";
    }
}

public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public string Display()
    {
        return IsHidden ? "_____" : Text;
    }
}
public class Scripture
{
    private List<Word> words;
    private ScriptureReference reference;

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(reference.ToString());
        Console.WriteLine(string.Join(" ", words.Select(w => w.Display())));
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        var visibleWords = words.Where(w => !w.IsHidden).ToList();
        
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AreAllWordsHidden()
    {
        return words.All(w => w.IsHidden);
    }
}
class Program
{
    static void Main(string[] args)
    {
        var reference = new ScriptureReference("3 Nephi", 5, 13);
        var scripture = new Scripture(reference, "Behold I am a disciple of Jesus Christ, The son of God. I have been called of him to declare his word among his people, that they might have everlasting life.");

        while (true)
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords(3);

            if (scripture.AreAllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine("All words are hidden.");
                break;
            }
        }
    }
}
