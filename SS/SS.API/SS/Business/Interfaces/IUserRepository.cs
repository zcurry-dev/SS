using System.Threading.Tasks;
using SS.API.Business.Dtos.Return;

namespace SS.API.Business.Interfaces
{
    public interface IUserRepository
    {
        Task<UserForDetailDto> GetUserById(int userId);
    }
}