namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OwDBContext : DbContext
    {
        public OwDBContext()
            : base("name=OwDBContext")
        {
        }

        public virtual DbSet<Hero> Hero { get; set; }
        public virtual DbSet<Map> Map { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .Property(e => e.HeroId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Hero>()
                .Property(e => e.HeroName)
                .IsUnicode(false);

            modelBuilder.Entity<Hero>()
                .Property(e => e.HeroType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Map>()
                .Property(e => e.MapId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Map>()
                .Property(e => e.MapName)
                .IsUnicode(false);

            modelBuilder.Entity<Map>()
                .Property(e => e.MapType)
                .IsUnicode(false);

            modelBuilder.Entity<Skill>()
                .Property(e => e.SkillId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Skill>()
                .Property(e => e.SkillName)
                .IsUnicode(false);

            modelBuilder.Entity<Skill>()
                .Property(e => e.SkillDetail)
                .IsUnicode(false);

            modelBuilder.Entity<Skill>()
                .Property(e => e.HeroId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminName)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminPwd)
                .IsUnicode(false);
        }
    }
}
