namespace GameZone.Configurations
{
    public class DeviceConfigurations : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> e)
        {
            e.Property(d => d.Icon)
                .HasMaxLength(50);
        }
    }
}
