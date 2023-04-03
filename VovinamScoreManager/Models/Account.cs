using System;
using System.Collections.Generic;

#nullable disable

namespace VovinamScoreManager.Models
{
    public partial class Account
    {
        public Account()
        {
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AccRule { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
