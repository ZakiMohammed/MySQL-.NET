using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Whale.Website.AppCode
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

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PostContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}