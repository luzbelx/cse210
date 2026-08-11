using System;

class Program
{
    static void Main(string[] args)
    {
        // Video 1
        Video video1 = new Video(
            "Learn C# Programming",
            "Eidhan",
            600
        );

        video1.AddComment(new Comment(
            "John",
            "This video was very helpful!"
        ));

        video1.AddComment(new Comment(
            "Maria",
            "I learned a lot from this video."
        ));

        video1.AddComment(new Comment(
            "David",
            "Great explanation!"
        ));

        // Video 2
        Video video2 = new Video(
            "Object Oriented Programming",
            "Eidhan",
            720
        );

        video2.AddComment(new Comment(
            "Carlos",
            "Excellent tutorial."
        ));

        video2.AddComment(new Comment(
            "Ana",
            "Very easy to understand."
        ));

        video2.AddComment(new Comment(
            "Luis",
            "Thank you for explaining this."
        ));

        // Video 3
        Video video3 = new Video(
            "C# Classes and Objects",
            "Eidhan",
            480
        );

        video3.AddComment(new Comment(
            "Sofia",
            "This helped me understand classes."
        ));

        video3.AddComment(new Comment(
            "Michael",
            "Good examples!"
        ));

        video3.AddComment(new Comment(
            "Daniel",
            "Looking forward to the next video."
        ));

        // Display Video 1
        Console.WriteLine("========================================");
        Console.WriteLine("VIDEO 1");
        Console.WriteLine("========================================");

        video1.DisplayVideo();

        // Display Video 2
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("VIDEO 2");
        Console.WriteLine("========================================");

        video2.DisplayVideo();

        // Display Video 3
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("VIDEO 3");
        Console.WriteLine("========================================");

        video3.DisplayVideo();
    }
}