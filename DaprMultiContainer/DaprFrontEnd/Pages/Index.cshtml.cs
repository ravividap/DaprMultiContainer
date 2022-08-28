using Microsoft.AspNetCore.Mvc;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Api;

namespace DaprFrontEnd.Pages
{
    public class IndexModel : PageModel
    {

        private readonly DaprClient _daprClient;

        public IndexModel(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public async Task OnGet()
        {
            var forcasts = await _daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(
                HttpMethod.Get,
                "DaprBackEnd",
                "weatherforecast"
                );

            ViewData["WeatherForecastData"] = forcasts;
        }
    }
}