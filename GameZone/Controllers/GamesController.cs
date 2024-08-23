using GameZone.Services;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly ICategoryService _categoryService;
        private readonly IGameService _gameService;

        public GamesController(ICategoryService categoryService, IDeviceService deviceService, IGameService gameService)
        {
            _categoryService = categoryService;
            _deviceService = deviceService;
            _gameService = gameService;
        }


        public IActionResult Index()
        {
            var games = _gameService.GetAll();
            return View(games);
        }


        public IActionResult Details(int id)
        {
            var game = _gameService.GetById(id);

            if (game is null)
                return NotFound();


            return View(game);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryService.GetSelectList();

            var devices = _deviceService.GetSelectList();

            var gameView = new CreateGameViewModel()
            {
                Categories = categories,

                Devices = devices
            };
            return View(gameView);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoryService.GetSelectList();

                model.Devices = _deviceService.GetSelectList();

                return View(model);
            }
            // Save Game In Db
            // Save Cover In Server
            await _gameService.Create(model);


            return RedirectToAction(nameof(Index));
        }


    }
}
