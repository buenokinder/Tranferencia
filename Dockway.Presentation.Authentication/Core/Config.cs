using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dockway.Presentation.Authentication
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("PatientApi", "PatientApi")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "PatientApp",

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "PatientApi" }
                },

                // resource owner password grant client
                new Client
                {
                    ClientId = "SasApp",

                    ClientSecrets =
                    {
                        new Secret("1BA741F0-97AF-4FF3-B0B5-BE2E5E002161".Sha256())
                    },
                    AllowedScopes = { "PatientApi" }
                },

             
                new Client
                {
                    ClientId = "DoctorApp",
                    ClientName = "Doctor Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = true,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "PatientApi"
                    },
                    AllowOfflineAccess = true
                }
            };
        }
    }
}
