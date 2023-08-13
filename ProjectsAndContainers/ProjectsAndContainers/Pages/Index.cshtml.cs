using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectsAndContainers.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The service increments a counter every time the page is accessed and stores the counter in the Redis cache.
        /// </summary>
        /// <returns></returns>
        public async Task OnGet()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                // Call *mywebapi*, and display its response in the page
                var request = new System.Net.Http.HttpRequestMessage();
                // webapi is the container name
                request.RequestUri = new Uri("http://webapi/Counter");
                var response = await client.SendAsync(request);
                string counter = await response.Content.ReadAsStringAsync();
                ViewData["Message"] = $"Counter value from cache :{counter}";
            }
        }
    }
}