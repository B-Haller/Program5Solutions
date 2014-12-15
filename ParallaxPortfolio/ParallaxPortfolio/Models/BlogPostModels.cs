using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParallaxPortfolio.Models
{
    [MetadataType(typeof(BlogPostModels))]

    public partial class BlogPosts
        {
        }
    
    public class BlogPostModels
    {   
        [Required(ErrorMessage="Title Required"), Display(Name="Title:")]
        public string Title { get; set; }
        [Required(ErrorMessage="Post Content Required"), Display(Name="Post Content:"), DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
    

}