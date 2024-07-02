using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace API.TurboSMTP.Client
{
    public partial class ApiClient : ISynchronousClient, IAsynchronousClient
    {
        partial void InterceptRequest(RestRequest request)
        {
            Console.WriteLine($"curl - X '{request.Method}' \"");
            Console.WriteLine(request.Resource);
        }
    }
}
