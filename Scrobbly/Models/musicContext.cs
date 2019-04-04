using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Scrobbly.Models
{
    public partial class musicContext : DbContext
    {
        public musicContext()
        {
        }

        public musicContext(DbContextOptions<musicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<AlbumArtists> AlbumArtists { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Play> Play { get; set; }
        public virtual DbSet<Track> Track { get; set; }
        public virtual DbSet<TrackAlbums> TrackAlbums { get; set; }
        public virtual DbSet<TrackArtists> TrackArtists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=music;Username=postgres;Password=Vanilla!16");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("album");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AltNames).HasColumnName("alt_names");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SpotifyId).HasColumnName("spotify_id");
            });

            modelBuilder.Entity<AlbumArtists>(entity =>
            {
                entity.HasKey(e => new { e.AlbumId, e.ArtistId });

                entity.ToTable("album_artists");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumArtists)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("fk_album_artists_album_id");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.AlbumArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("fk_album_artists_artist_id");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AltNames).HasColumnName("alt_names");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SpotifyId).HasColumnName("spotify_id");
            });

            modelBuilder.Entity<Play>(entity =>
            {
                entity.ToTable("play");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasColumnName("album_name");

                entity.Property(e => e.ArtistIds)
                    .IsRequired()
                    .HasColumnName("artist_ids");

                entity.Property(e => e.ArtistNames)
                    .IsRequired()
                    .HasColumnName("artist_names");

                entity.Property(e => e.Dirty).HasColumnName("dirty");

                entity.Property(e => e.ListenTime)
                    .HasColumnName("listen_time")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Popularity).HasColumnName("popularity");

                entity.Property(e => e.SourceOf)
                    .IsRequired()
                    .HasColumnName("source_of")
                    .HasColumnType("character(50)");

                entity.Property(e => e.TrackId).HasColumnName("track_id");

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasColumnName("track_name");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("track");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AltNames).HasColumnName("alt_names");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SpotifyId).HasColumnName("spotify_id");
            });

            modelBuilder.Entity<TrackAlbums>(entity =>
            {
                entity.HasKey(e => new { e.TrackId, e.AlbumId });

                entity.ToTable("track_albums");

                entity.Property(e => e.TrackId).HasColumnName("track_id");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.TrackAlbums)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("fk_track_albums_album_id");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.TrackAlbums)
                    .HasForeignKey(d => d.TrackId)
                    .HasConstraintName("fk_track_albums_track_id");
            });

            modelBuilder.Entity<TrackArtists>(entity =>
            {
                entity.HasKey(e => new { e.TrackId, e.ArtistId });

                entity.ToTable("track_artists");

                entity.Property(e => e.TrackId).HasColumnName("track_id");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.TrackArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("fk_track_artists_artist_id");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.TrackArtists)
                    .HasForeignKey(d => d.TrackId)
                    .HasConstraintName("fk_track_artists_track_id");
            });
        }
    }
}
