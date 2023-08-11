using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Services.SuperHeroServices
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeros.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeros.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeros.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            _context.SuperHeros.Remove(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeros.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeros()
        {
            return await _context.SuperHeros.ToListAsync();
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero =await _context.SuperHeros.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            return hero;
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {
            var hero = await _context.SuperHeros.FindAsync(id);
            if (hero is null)
            {
                return null;
            }
            if (request.Name is not null && request.Name != "")
            {
                hero.Name = request.Name;
            }

            if (request.FirstName is not null && request.FirstName != "")
            {
                hero.FirstName = request.FirstName;
            }

            if (request.LastName is not null && request.LastName != "")
            {
                hero.LastName = request.LastName;
            }

            if (request.Place is not null && request.Place != "")
            {
                hero.Place = request.Place;
            }
            await _context.SaveChangesAsync();

            return await _context.SuperHeros.ToListAsync();
        }

    }
}
