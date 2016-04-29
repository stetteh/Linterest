using System;
using System.Collections;
using System.Collections.Generic;

namespace Linterest.Models
{
    public class Lin
    {
        public int Id { get; set; }
        public virtual LinterestUser Author { get; set; }
        public  string Text { get; set; }
        public string ImageUrl { get; set; }
        public string PinImageUrl { get; set; }    
        public DateTime CreatedOn { get; set; }  
        
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();  
    }

    public class Comment
    {
        public int Id { get; set; }
        public string CommentBody { get; set; }
        public virtual LinterestUser Author { get; set; }
        public virtual Lin ParentLin { get; set; }
        public DateTime CommentDate { get; set; }
    }

    public class CreateLinVM
    {
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string PinImageUrl { get; set; }
    }
}