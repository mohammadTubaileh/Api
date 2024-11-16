using Api.Models;

namespace Api.Interface
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersByCountry(int countryId);
        bool CountryExist(int id);
        bool CreateCountry(Country country);
        bool DeleteCountry(Country country);
        bool UpdateCountry(Country country);
        bool Save();
    }
}
