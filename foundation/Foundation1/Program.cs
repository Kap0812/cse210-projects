using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create some videos
        Video video1 = new Video("Introduction to C#", "John Doe", 600);
        Video video2 = new Video("Understanding OOP", "Jane Smith", 800);
        Video video3 = new Video("Design Patterns in C#", "Alice Johnson", 900);

        // Add comments to video1
        video1.addComment(new Comment("Chris", "Great tutorial!"));
        video1.addComment(new Comment("Alex", "Very informative, thanks!"));

        // Add comments to video2
        video2.addComment(new Comment("Sam", "OOP explained well."));
        video2.addComment(new Comment("Taylor", "Good examples!"));

        // Add comments to video3
        video3.addComment(new Comment("Jordan", "Design patterns are so useful."));
        video3.addComment(new Comment("Pat", "Can you explain the strategy pattern in more detail?"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display each video's info and its comments
        foreach (Video video in videos)
        {
            video.displayVideoInfo();
        }
    }
}

class Video
{
    private string title;
    private string author;
    private int length;  // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    // Method to add a comment
    public void addComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Method to get the number of comments
    public int getNumberOfComments()
    {
        return comments.Count;
    }

    // Method to display video information
    public void displayVideoInfo()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {length} seconds");
        Console.WriteLine($"Number of Comments: {getNumberOfComments()}");

        // Display each comment
        foreach (Comment comment in comments)
        {
            comment.displayComment();
        }
        Console.WriteLine();  // Add blank line for readability
    }
}

class Comment
{
    private string commenterName;
    private string text;

    public Comment(string commenterName, string text)
    {
        this.commenterName = commenterName;
        this.text = text;
    }

    // Method to display the comment
    public void displayComment()
    {
        Console.WriteLine($"{commenterName}: {text}");
    }
}
