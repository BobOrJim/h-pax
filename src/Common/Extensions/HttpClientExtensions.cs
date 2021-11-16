using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common.Extensions
{

    public static class HttpClientExtensions
    {
        public static HttpClient HttpClientPrep(this HttpClient httpClient, string uri, string accessToken)
        {
            httpClient.BaseAddress = new Uri(uri);
            httpClient.SetBearerToken(accessToken);
            return httpClient;
        }
    }
}

