using System;
using PostProject.Models;

namespace PostProject.ViewModel
{
    public class AboutVM
    {
        public List<Post> Posts { get; set; }

        public List<Tag> Tags { get; set; }
        public List<Category> categories { get; set; }

        public Post post { get; set; }
        public Category Category { get; set; }
    }

    
}

