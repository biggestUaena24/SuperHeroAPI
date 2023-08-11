namespace SuperHeroAPI.Services.SuperHeroServices
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeros();
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero hero);
        Task<List<SuperHero>?> DeleteHero(int id);
    }
}
