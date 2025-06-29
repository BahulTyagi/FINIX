﻿using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Comment")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; }= string.Empty;
        public DateTime CreatedOn { get; set; }= new DateTime(2025, 06, 20);
        public int? StockId { get; set; }

        //Navigation property
        public Stock? Stock { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
