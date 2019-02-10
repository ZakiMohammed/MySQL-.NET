using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whale.Model
{
    [Table("post")]
    public class Post
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("author")]
        public string Author { get; set; }
        [Column("short_content")]
        public string ShortContent { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("create_at")]
        public DateTime CreateAt { get; set; }
    }
}
