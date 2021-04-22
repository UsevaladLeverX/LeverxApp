using System;
using System.Collections.Generic;

#nullable disable

namespace Leverx
{
    public partial class Level
    {
        public Level()
        {
            Mentees = new HashSet<Mentee>();
        }

        public int LevelId { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Mentee> Mentees { get; set; }
    }
}
