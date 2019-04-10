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
        public virtual DbSet<AlbumTags> AlbumTags { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<ArtistTags> ArtistTags { get; set; }
        public virtual DbSet<Play> Play { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Track> Track { get; set; }
        public virtual DbSet<TrackArtists> TrackArtists { get; set; }
        public virtual DbSet<TrackTags> TrackTags { get; set; }

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

                entity.Property(e => e.Image).HasColumnName("image");

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

            modelBuilder.Entity<AlbumTags>(entity =>
            {
                entity.HasKey(e => new { e.AlbumId, e.TagId });

                entity.ToTable("album_tags");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumTags)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("fk_album_tags_album_id");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.AlbumTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("fk_album_tags_tag_id");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SpotifyId).HasColumnName("spotify_id");
            });

            modelBuilder.Entity<ArtistTags>(entity =>
            {
                entity.HasKey(e => new { e.ArtistId, e.TagId });

                entity.ToTable("artist_tags");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.ArtistTags)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("fk_artist_tags_artist_id");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ArtistTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("fk_artist_tags_tag_id");
            });

            modelBuilder.Entity<Play>(entity =>
            {
                entity.ToTable("play");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumImage).HasColumnName("album_image");

                entity.Property(e => e.AlbumName).HasColumnName("album_name");

                entity.Property(e => e.AlbumSpotifyId).HasColumnName("album_spotify_id");

                entity.Property(e => e.ArtistNames)
                    .IsRequired()
                    .HasColumnName("artist_names");

                entity.Property(e => e.ArtistSpotifyIds).HasColumnName("artist_spotify_ids");

                entity.Property(e => e.Dirty).HasColumnName("dirty");

                entity.Property(e => e.ListenTime)
                    .HasColumnName("listen_time")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Popularity).HasColumnName("popularity");

                entity.Property(e => e.SourceOf)
                    .IsRequired()
                    .HasColumnName("source_of")
                    .HasColumnType("character(50)");

                entity.Property(e => e.TrackDuration).HasColumnName("track_duration");

                entity.Property(e => e.TrackId).HasColumnName("track_id");

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasColumnName("track_name");

                entity.Property(e => e.TrackSpotifyId).HasColumnName("track_spotify_id");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.Play)
                    .HasForeignKey(d => d.TrackId)
                    .HasConstraintName("fk_play_track_id");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tag");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("track");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.SourceTrackId).HasColumnName("source_track_id");

                entity.Property(e => e.SpotifyId).HasColumnName("spotify_id");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Track)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_track_album_id");

                entity.HasOne(d => d.SourceTrack)
                    .WithMany(p => p.InverseSourceTrack)
                    .HasForeignKey(d => d.SourceTrackId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_track_source_track_id");
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

            modelBuilder.Entity<TrackTags>(entity =>
            {
                entity.HasKey(e => new { e.TrackId, e.TagId });

                entity.ToTable("track_tags");

                entity.Property(e => e.TrackId).HasColumnName("track_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TrackTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("fk_track_tags_tag_id");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.TrackTags)
                    .HasForeignKey(d => d.TrackId)
                    .HasConstraintName("fk_track_tags_track_id");
            });
        }
    }
}
