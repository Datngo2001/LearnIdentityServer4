using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class WeatherInfo
    {
        public DateTime Date { get; set; }
        public string Summary { get; set; }
        public int TemperatureF { get; set; }
        public int TemperatureC { get; set; }
    }
}