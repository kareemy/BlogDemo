using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Adding related data
            // Create a blog with a post together
            Blog blog1 = new Blog {
                Url = "http://www.wtamu.edu",
                Posts = new List<Post> {
                    new Post {Title =  "My First Post"}
                }
            };
            // Add a new post to an existing blog
            blog1.Posts.Add(new Post {Title = "My Second Post"});

            // Add a new post to an existing blog using the Post navigation property
            Post myPost = new Post {Title = "My Third Post"};
            myPost.Blog = blog1;

            Blog blog2 = new Blog {Url = "blog2.url"};

            // Add the blog and post like normal
            using (var db = new AppDbContext())
            {
                if (db.Database.EnsureCreated())
                {
                    db.Add(blog1);
                    db.Add(myPost);
                    db.Add(blog2);
                    db.SaveChanges();
                }
            }

            using (var db = new AppDbContext())
            {
                // Create a new post and add it to an existing blog
                // Use the navigation property                
                Post newPost = new Post {Title = "DB Post"};
                newPost.Blog = db.Blogs.First();
                db.Add(newPost);
                db.SaveChanges();
            }

            using (var db = new AppDbContext())
            {
                // Update a post
                // Move it by changing its navigation property                
                Post postToMove = db.Posts.Where(p => p.Title == "DB Post").First();
                Blog blog = db.Blogs.Where(b => b.Url == "blog2.url").First();
                postToMove.Blog = blog;
                db.SaveChanges();
            } 

            using (var db = new AppDbContext())
            {
                // Remove a post from the database
                Post postToRemove = db.Posts.Where(p => p.Title == "My Second Post").Single();
                db.Remove(postToRemove);
                db.SaveChanges();
            } 

            using (var db = new AppDbContext())
            {
                // List all blogs with their posts
                // Use .Include() to bring in the Posts                
                var blogs = db.Blogs.Include(b => b.Posts);
                foreach (Blog blog in blogs)
                {
                    Console.WriteLine(blog);
                    foreach (var post in blog.Posts)
                    {
                        Console.WriteLine($"\t{post}");
                    }
                }
            }                      
        }
    }
}
