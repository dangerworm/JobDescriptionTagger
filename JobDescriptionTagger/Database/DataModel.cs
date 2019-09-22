namespace JobDescriptionTagger.Database
{
    using System.Data.Entity;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Inference> Inferences { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .Property(e => e.TagName)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.Inferences)
                .WithOptional(e => e.Tag)
                .HasForeignKey(e => e.SourceTagId);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.Inferences1)
                .WithOptional(e => e.Tag1)
                .HasForeignKey(e => e.TargetTagId);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Tags)
                .Map(m => m.ToTable("UserTags").MapLeftKey("TagId").MapRightKey("UserId"));

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);
        }
    }
}
