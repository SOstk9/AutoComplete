using System.Diagnostics;
using AutoComplete.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoComplete.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AutoComplete(string suche)
        {
            MoviesContext context = new MoviesContext();

            var films = from f in context.Films
                        where f.Titel.Contains(suche)
                        select f.Titel;


            List<string>filme = new List<string>();


            foreach (var film in films)
            {
                filme.Add(film);
            }

            return PartialView(filme);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
