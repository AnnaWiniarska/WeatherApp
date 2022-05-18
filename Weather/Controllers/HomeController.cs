using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Weather.Models;
using Weather.OpenWeatherMapModels;
using Weather.Repositories;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;
        public HomeController(IWeatherRepository weatherAppRepo)
        {
            _weatherRepository = weatherAppRepo;
        }
        public IActionResult Index()
        {
            var viewModel = new SearchCity();
            return View(viewModel);
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Save()
        {
            var viewModel = new City();
            return View(viewModel);
        }
        public IActionResult ViewAll()
        {
            var viewModel = new City();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Home", new { city = model.CityName });
            }
            return View(model);
        }
        public IActionResult City(string city)
        {
            WeatherResponse weatherResponse = _weatherRepository.GetForecast(city);
            City viewModel = new City();
            if (weatherResponse != null)
            {
                viewModel.Name = weatherResponse.Name;
                viewModel.Humidity = weatherResponse.Main.Humidity;
                viewModel.Pressure = weatherResponse.Main.Pressure;
                viewModel.Temp = weatherResponse.Main.Temp;
                viewModel.Weather = weatherResponse.Weather[0].Main;
                viewModel.Wind = weatherResponse.Wind.Speed;
            }
            return View(viewModel);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
   

    }
}
