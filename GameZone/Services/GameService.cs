using GameZone.Settings;
using GameZone.ViewModels;

namespace GameZone.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public GameService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagePath}";
        }

        public async Task Create(CreateGameViewModel model)
        {
            // Generate name for image.
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";

            var path = Path.Combine(_imagesPath, coverName);

            using var stream = File.Create(path);
            await model.Cover.CopyToAsync(stream);


            // Save in Db

            var game = new Game()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = coverName,
                Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
            };

            _context.Games.Add(game);
            _context.SaveChanges();

        }

        public IEnumerable<Game> GetAll()
        {
            return _context.Games
                .Include(g => g.Category)
                .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .ToList();
        }

        public Game? GetById(int id)
        {
            return _context.Games
                .Include(g => g.Category)
                .Include(g => g.Devices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .SingleOrDefault(g => g.Id == id);
        }
    }
}
