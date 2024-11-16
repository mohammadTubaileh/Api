using Api.Dto;
using Api.Models;

namespace Api.Interface
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokeMonRating(int PokeId);
        bool PokemonExists(int PokeId);
        bool CreatePokemon(int ownerId , int categoryId , Pokemon pokemon);
        bool UpdatePokemon(int ownerId,int categoryId,Pokemon pokemon);
        bool DeletePokemon(Pokemon pokemon);
        bool Save();
        
    }
}
