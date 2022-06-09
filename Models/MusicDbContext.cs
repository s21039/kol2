using Microsoft.EntityFrameworkCore;

namespace kol2.Models
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<MusicanTrack> MusicanTracks { get; set; }
        public DbSet<Musican> Musicans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.ToTable("MusicLabel");
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).IsRequired().HasMaxLength(50);
                e.HasData(
                    new MusicLabel
                    {
                        IdMusicLabel = 1,
                        Name = "Garage"
                    }
                );
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.ToTable("Album");
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                e.Property(e => e.PublishDate).IsRequired();
                e.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);
                e.HasData(
                    new Album
                    {
                        IdAlbum = 1,
                        AlbumName = "Night",
                        PublishDate = new System.DateTime(2022, 2, 2),
                        IdMusicLabel = 1
                    }
                );
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.ToTable("Track");
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                e.Property(e => e.Duration).IsRequired();
                e.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdMusicAlbum);
                e.HasData(
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "Sky",
                        Duration = 30,
                        IdMusicAlbum = 1,
                    }
                );
            });

            modelBuilder.Entity<MusicanTrack>(e =>
            {
                e.ToTable("MusicanTrack");
                e.HasKey(e => new {e.IdMusican, e.IdTrack});
                e.HasOne(e => e.Musican).WithMany(e => e.MusicanTracks).HasForeignKey(e => e.IdMusican);
                e.HasOne(e => e.Track).WithMany(e => e.MusicanTracks).HasForeignKey(e => e.IdTrack).IsRequired(false);
                e.HasData(
                    new MusicanTrack
                    {
                        IdTrack = 1,
                        IdMusican = 1
                    }
                );
            });

            modelBuilder.Entity<Musican>(e =>
            {
                e.ToTable("Musican");
                e.HasKey(e => e.IdMusican);
                e.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                e.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                e.Property(e => e.Nickname).HasMaxLength(20);
                e.HasData(
                    new Musican
                    {
                        IdMusican = 1,
                        FirstName = "Krzysztof",
                        LastName = "Krawczyk",
                        Nickname = "KKraw"
                    }
                );
            });

        }
    }
}
