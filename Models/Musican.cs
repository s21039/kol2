using System.Collections.Generic;

namespace kol2.Models
{
    public class Musican
    {
        public int IdMusican { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public virtual ICollection<MusicanTrack> MusicanTracks { get; set; }
    }
}
