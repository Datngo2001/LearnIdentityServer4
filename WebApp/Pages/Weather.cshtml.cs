using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApp.Model;
using WebApp.Services;

namespace WebApp.Pages
{
    public class Weather : PageModel
    {
        private readonly ILogger<Weather> _logger;
        private readonly ITokenService _tokenService;

        public Weather(ILogger<Weather> logger, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        [BindProperty]
        public List<WeatherInfo> WeatherInfos { get; set; } = new List<WeatherInfo>();

        public async Task<IActionResult> OnGet()
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await _tokenService.GetToken("weatherapi.read");

                client.SetBearerToken(tokenResponse.AccessToken);

                var result = await client.GetAsync("https://localhost:7035/WeatherForecast");

                if (result.IsSuccessStatusCode)
                {
                    var model = await result.Content.ReadAsStringAsync();
                    WeatherInfos = JsonConvert.DeserializeObject<List<WeatherInfo>>(model) ?? new List<WeatherInfo>();
                    return Page();
                }
                else
                {
                    throw new Exception("Unable to get content");
                }
            }
        }
    }
}