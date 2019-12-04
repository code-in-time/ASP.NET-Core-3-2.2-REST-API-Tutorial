using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tweetbook.Controllers.V1.Response
{
    public class AuthFailResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
