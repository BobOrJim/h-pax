using System.Threading.Tasks;

namespace APIGateway3.Services
{
    public interface ITokenFactory
    {
        Task<string> GetAccessToken();
    }
}