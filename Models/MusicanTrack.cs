namespace kol2.Models
{
    public class MusicanTrack
    {
        public int IdTrack { get; set; }
        public int IdMusican { get; set; }
        public virtual Track Track { get; set; }
        public virtual Musican Musican { get; set; }
    }
}
