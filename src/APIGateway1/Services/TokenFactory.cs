﻿using Common;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIGateway1.Services
{
    public class TokenFactory : ITokenFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TokenFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetAccessToken()
        {
            var IDPClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await IDPClient.GetDiscoveryDocumentAsync(uri.IDP);

            var TokenResponse = await IDPClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest //Flow = ClientCredentials, aka machine to machine
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "client_APIGateway1",
                    ClientSecret = "APIGateway1_secret", 
                    Scope = "API_Mountain API_Forest"
                });

            return TokenResponse.AccessToken;
        }

    }
}
