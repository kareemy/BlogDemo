using System;
using System.Collections.Generic;

namespace BlogDemo
{
    public class Blog
    {
        public int BlogId {get; set;} // Primary key
        public string Url {get; set;} = string.Empty;
        // One-to-many relationships
        // Setup navigation property on ONE side, List of MANY side
        public List<Post> Posts {get; set;} = new List<Post>();
        public override string ToString()
        {
            return $"({BlogId}) - {Url}";
        }
    }
}