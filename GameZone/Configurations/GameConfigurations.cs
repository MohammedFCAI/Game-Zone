namespace GameZone.Configurations
{
    public class GameConfigurations : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> e)
        {
            e.Property(g => g.Name)
                .HasMaxLength(250);

            e.Property(g => g.Description)
                .HasMaxLength(2500);

            e.Property(g => g.Cover)
              .HasMaxLength(500);

        }
    }
}
