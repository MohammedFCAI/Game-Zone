
namespace GameZone.Configurations
{
    public class GameDeviceConfigurations : IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> e)
        {
            e.HasKey(d => new { d.GameId, d.DeviceId });
        }
    }
}
