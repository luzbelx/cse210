using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {

        List<Video> videos = new List<Video>();


        // VIDEO 1

        Video video1 = new Video(
            "Introduction to C# Programming",
            "John Smith",
            300
        );


        video1.AddComment(
            new Comment(
                "Maria",
                "This video helped me understand C#."
            )
        );


        video1.AddComment(
            new Comment(
                "Carlos",
                "Great explanation!"
            )
        );


        video1.AddComment(
            new Comment(
                "Ana",
                "Very useful information."
            )
        );



        // VIDEO 2

        Video video2 = new Video(
            "Object Oriented Programming Basics",
            "Sarah Johnson",
            450
        );


        video2.AddComment(
            new Comment(
                "David",
                "Now I understand classes better."
            )
        );


        video2.AddComment(
            new Comment(
                "Luis",
                "The examples were excellent."
            )
        );


        video2.AddComment(
            new Comment(
                "Sofia",
                "Thank you for this tutorial."
            )
        );



        // VIDEO 3

        Video video3 = new Video(
            "C# Classes and Objects",
            "Robert Brown",
            600
        );


        video3.AddComment(
            new Comment(
                "Peter",
                "Amazing explanation."
            )
        );


        video3.AddComment(
            new Comment(
                "Emma",
                "I learned something new."
            )
        );


        video3.AddComment(
            new Comment(
                "Michael",
                "Very clear and easy to follow."
            )
        );



        // Add videos to list

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);



        // Display all videos

        foreach (Video video in videos)
        {
            video.Display();
        }


    }
}


