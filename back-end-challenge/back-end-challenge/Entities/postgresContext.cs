using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace back_end_challenge.Entities
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Follower> Followers { get; set; }
        public virtual DbSet<Following> Followings { get; set; }
        public virtual DbSet<PgBuffercache> PgBuffercaches { get; set; }
        public virtual DbSet<PgStatStatement> PgStatStatements { get; set; }
        public virtual DbSet<Timeline> Timelines { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=ConnectionDBPostgreServer");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements")
                .HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Follower>(entity =>
            {
                entity.HasKey(e => e.IdFollower)
                    .HasName("followers_pkey");

                entity.ToTable("followers");

                entity.Property(e => e.IdFollower)
                    .HasColumnName("id_follower")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 999999999L, null, null);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("Creation_date");

                entity.Property(e => e.UserFollower)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("user_follower");

                entity.Property(e => e.UserMaster)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("user_master");

                entity.HasOne(d => d.UserMasterNavigation)
                    .WithMany(p => p.Followers)
                    .HasForeignKey(d => d.UserMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_master_user");
            });

            modelBuilder.Entity<Following>(entity =>
            {
                entity.HasKey(e => e.IdFollowing)
                    .HasName("following_pkey");

                entity.ToTable("following");

                entity.Property(e => e.IdFollowing)
                    .HasColumnName("id_following")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 999999999L, null, null);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("Creation_date");

                entity.Property(e => e.UserFollowing)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("user_following");

                entity.Property(e => e.UserMaster)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("user_master");

                entity.HasOne(d => d.UserMasterNavigation)
                    .WithMany(p => p.Followings)
                    .HasForeignKey(d => d.UserMaster)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_master_user_following");
            });

            modelBuilder.Entity<PgBuffercache>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_buffercache");

                entity.Property(e => e.Bufferid).HasColumnName("bufferid");

                entity.Property(e => e.Isdirty).HasColumnName("isdirty");

                entity.Property(e => e.PinningBackends).HasColumnName("pinning_backends");

                entity.Property(e => e.Relblocknumber).HasColumnName("relblocknumber");

                entity.Property(e => e.Reldatabase)
                    .HasColumnType("oid")
                    .HasColumnName("reldatabase");

                entity.Property(e => e.Relfilenode)
                    .HasColumnType("oid")
                    .HasColumnName("relfilenode");

                entity.Property(e => e.Relforknumber).HasColumnName("relforknumber");

                entity.Property(e => e.Reltablespace)
                    .HasColumnType("oid")
                    .HasColumnName("reltablespace");

                entity.Property(e => e.Usagecount).HasColumnName("usagecount");
            });

            modelBuilder.Entity<PgStatStatement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnType("oid")
                    .HasColumnName("dbid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnType("oid")
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Timeline>(entity =>
            {
                entity.HasKey(e => e.IdTimeline)
                    .HasName("timeline_pkey");

                entity.ToTable("timeline");

                entity.Property(e => e.IdTimeline)
                    .HasColumnName("id_timeline")
                    .UseIdentityAlwaysColumn()
                    .HasIdentityOptions(null, null, null, 999999999L, null, null);

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("comment");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("creation_date");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("user");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Timelines)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_user");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("user_pkey");

                entity.ToTable("user");

                entity.Property(e => e.IdUser)
                    .HasMaxLength(20)
                    .HasColumnName("id_user");

                entity.Property(e => e.Activate).HasColumnName("activate");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasColumnName("Creation_date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .HasColumnName("First_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .HasColumnName("Last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.Thought)
                    .HasMaxLength(40)
                    .HasColumnName("thought");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
