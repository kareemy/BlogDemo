using System;
using System.Collections.Generic;

namespace BlogDemo
{
    public class Post
    {
        public int PostId {get; set;}
        public string Title {get; set;}
        // Add navigation property to MANY side
        // Each Post belongs to ONE Blog        
        public Blog Blog {get; set;} // Navigation property
        public int BlogId {get; set;} // Foreign Key

        public override string ToString()
        {
            return $"({PostId}) - {Title}";
        }


    }
}