using System.Threading.Tasks;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAuthAsync(object email, string password);
    }
}