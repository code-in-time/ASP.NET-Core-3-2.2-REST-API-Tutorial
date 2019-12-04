using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public class IdentityService : IIdentityService
    {
        // https://www.youtube.com/watch?v=ARvsBUBioT0&list=PLUOequmGnXxOgmSDWU7Tl6iQTsOtyjtwU&index=11 8:05 TODO
        private readonly UserManger<IIdentityService> _userManger;

        public IdentityService()
        {
            _userManger = 
        }

        public Task<AuthenticationResult> RegisterAuthAsync(object email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
