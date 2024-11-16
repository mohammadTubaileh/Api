using Api.Data;
using Api.Interface;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        { 
            _context = context;
        }

        public bool CreateOwner(Pokemon pokemon)
        {
            _context.Add(pokemon);
            return Save();
        }

        public bool CreatePokemon(Pokemon pokemon)
        {
            _context.Add(pokemon);
                return Save();
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
             var pokemonOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };

            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };

            _context.Add(pokemonCategory);

            _context.Add(pokemon);

            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            
            _context.Remove(pokemon);
            return Save();
        }
        

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p=>p.Id ==id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p=>p.Name == name).FirstOrDefault();
        }

        public decimal GetPokeMonRating(int PokeId)
        {
            var review = _context.Reviews.Where(p=>p.Pokemon.Id == PokeId);
            if(review.Count() <= 0)
                return 0;
            return ((decimal)(review.Sum(r => r.Rating) / review.Count()));

        }

        public ICollection<Pokemon> GetPokemons() 
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int PokeId)
        {
            return _context.Pokemon.Any(p => p.Id == PokeId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;    
        }

       

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}
