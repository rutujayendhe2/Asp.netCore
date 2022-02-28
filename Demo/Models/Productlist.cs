using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Models
{
    public partial class Productlist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
