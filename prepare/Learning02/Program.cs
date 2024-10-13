using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Learning C#", "John Doe", 600);
        Video video2 = new Video("Design Patterns", "Jane Smith", 720);
        Video video3 = new Video("Introduction to OOP", "Alice Johnson", 840);

        // Add comments to video1
        video1.addComment(new Comment("Chris", "Great tutorial!"));
        video1.addComment(new Comment("Sam", "Very helpful, thanks!"));
        video1.addComment(new Comment("Alex", "I enjoyed the examples."));

        // Add comments to video2
        video2.addComment(new Comment("Taylor", "Informative video."));
        video2.addComment(new Comment("Jordan", "Can you explain the strategy pattern?"));
        video2.addComment(new Comment("Pat", "Clear and concise explanation."));

        // Add comments to video3
        video3.addComment(new Comment("Jamie", "Love this content!"));
        video3.addComment(new Comment("Robin", "Please make a video on interfaces."));
        video3.addComment(new Comment("Casey", "This was well explained!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through videos and display their information
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
    private int length;
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    public void addComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int getNumberOfComments()
    {
        return comments.Count;
    }

    public void displayVideoInfo()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {length} seconds");
        Console.WriteLine($"Number of Comments: {getNumberOfComments()}");

        foreach (Comment comment in comments)
        {
            comment.displayComment();
        }
        Console.WriteLine();
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

    public void displayComment()
    {
        Console.WriteLine($"{commenterName}: {text}");
    }
}
