using GameZone.ViewModels;

namespace GameZone.Services
{
    public interface IGameService
    {
        Task Create(CreateGameViewModel game);
        IEnumerable<Game> GetAll();

        Game? GetById(int id);
    }
}
