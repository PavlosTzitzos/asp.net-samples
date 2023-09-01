using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class config : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
        new Client
        {
            // unique ID for this client
            ClientId = "wewantdoughnuts", 
            // human-friendly name displayed in IS
            ClientName = "We Want Doughnuts", 
            // URL of client
            ClientUri = "http://localhost:3000", 
            // how client will interact with our identity server (Implicit is basic flow for web apps)
            AllowedGrantTypes = GrantTypes.Implicit, 
            // don't require client to send secret to token endpoint
            RequireClientSecret = false,
            RedirectUris =
            {             
                // can redirect here after login                     
                "http://localhost:3000/signin-oidc",
            },
            // can redirect here after logout
            PostLogoutRedirectUris = { "http://localhost:3000/signout-oidc" }, 
            // builds CORS policy for javascript clients
            AllowedCorsOrigins = { "http://localhost:3000" }, 
            // what resources this client can access
            AllowedScopes = { "openid", "profile", "doughnutapi" }, 
            // client is allowed to receive tokens via browser
            AllowAccessTokensViaBrowser = true
        }
    };
        }
    }
}
