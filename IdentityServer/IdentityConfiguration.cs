using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                     SubjectId = "1144",
                     Username = "macoratti",
                     Password = "numsey",
                     Claims =
                     {
                        new Claim(JwtClaimTypes.Name, "Macoratti Net"),
                        new Claim(JwtClaimTypes.GivenName, "Macoratti"),
                        new Claim(JwtClaimTypes.FamilyName, "Net"),
                        new Claim(JwtClaimTypes.WebSite, "http://macoratti.net"),
                     }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
            };

        // Escopos que são papéis, permissões (emails.read) por exemplo
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
               new ApiResource("myApi")
               {
                   Scopes = new List<string>{ "myApi.read","myApi.write" },
                   ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
               }
            };

        //Configuração dos cliente que irão ter acesso como Id e Chave
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    //Fluxo de Autenticação 
                    //Password -> cliente direto no server (evitar pois cliente conehce a senha, apenas para confiaveis)
                    //** ClientCredentials -> Comunicação entre servicós
                    //** Code -> SPAs : Não entendi direito
                    //Implicits -> SPAs : Não entendi direito (Vulneravel)
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.read" }
                },
            };
    }
}

