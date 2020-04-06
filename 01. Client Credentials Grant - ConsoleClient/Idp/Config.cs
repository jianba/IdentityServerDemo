﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;
using Newtonsoft.Json;

namespace Idp
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var datas = new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

            var strDatas = JsonConvert.SerializeObject(datas);

            return datas;
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            var datas =  new ApiResource[]
            {
                new ApiResource("api1", "My API #1")
            };
            var strDatas = JsonConvert.SerializeObject(datas);

            return datas;
        }

        public static IEnumerable<Client> GetClients()
        {
            var datas =  new[]
            {
                // client credentials flow client
                new Client
                {
                    ClientId = "console client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "api1" }
                }
            };
            var strDatas = JsonConvert.SerializeObject(datas);

            return datas;
        }
    }
}