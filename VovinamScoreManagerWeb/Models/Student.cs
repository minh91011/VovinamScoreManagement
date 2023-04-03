using System;
using System.Collections.Generic;

#nullable disable

namespace VovinamScoreManagerWeb.Models
{
    public partial class Student
    {
        public Student()
        {
            Scores = new HashSet<Score>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? ClassId { get; set; }
        public int? RankId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Rank Rank { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
