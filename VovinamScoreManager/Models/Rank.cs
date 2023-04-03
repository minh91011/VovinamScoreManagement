using System;
using System.Collections.Generic;

#nullable disable

namespace VovinamScoreManager.Models
{
    public partial class Rank
    {
        public Rank()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? LimitScore { get; set; }
        public int? MaxScore { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
