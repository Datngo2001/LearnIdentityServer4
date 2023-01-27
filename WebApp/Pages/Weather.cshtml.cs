using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApp.Pages
{
    public class Weather : PageModel
    {
        private readonly ILogger<Weather> _logger;

        public Weather(ILogger<Weather> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}