using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SS.Data.Models;

namespace SS.Business.Interfaces
{
    public interface IUtilityDataRepository
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<Usstate>> GetUsStates();
        Task<IEnumerable<City>> GetUSCities(int usStateId);
    }
}