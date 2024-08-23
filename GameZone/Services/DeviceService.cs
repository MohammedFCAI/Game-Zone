using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly ApplicationDbContext _context;

        public DeviceService(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Devices.Select(c => new SelectListItem()
            { Value = c.Id.ToString(), Text = c.Name }).AsNoTracking().OrderBy(c => c.Text).ToList();
        }
    }
}
