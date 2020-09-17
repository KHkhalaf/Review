using System;
using System.Collections.Generic;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Review.Models
{
    public class Post
    {
        public int userId { get; set; }
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

    }
}
