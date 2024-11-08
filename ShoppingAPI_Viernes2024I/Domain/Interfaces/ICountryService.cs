using ShoppingAPI_Viernes2024I.DAL.Entities;

namespace ShoppingAPI_Viernes2024I.Domain.Interfaces
{
    public interface ICountryService
    {
       Task<IEnumerable<Country>> GetCountriesAsync(); //una de las firmas del metodo

       Task<Country>CreateCountryAsync(Country country);

        Task<Country> GetCountryByIdAsync(Guid id);

        Task<Country> EditCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Guid id);
    }
}
