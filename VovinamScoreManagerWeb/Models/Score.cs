using System;
using System.Collections.Generic;

#nullable disable

namespace VovinamScoreManagerWeb.Models
{
    public partial class Score
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? Score1 { get; set; }

        public virtual Student Student { get; set; }
    }
}
