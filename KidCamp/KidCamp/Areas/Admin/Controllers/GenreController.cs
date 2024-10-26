using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidCamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IActionResult Index()
        {
            var listGenre = _genreService.TGetList();
            return View(listGenre);
        }
        [HttpGet]
        public IActionResult AddGenre()
        {
            return View();

        }
        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre); 
            }
            _genreService.TAdd(genre);
            return RedirectToAction("Index", "Activities", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult UpdateGenre(int id)
        {

            var updateGenre = _genreService.TGetByID(id);
            return View(updateGenre);
        }
        [HttpPost]
        public IActionResult UpdateGenre(Genre g)
        {
        
            _genreService.TUpdate(g);
            return RedirectToAction("Index", "Activities", new { area = "Admin" });
        }
        public IActionResult DeleteGenre(int id)
        {

            var deleteGenre = _genreService.TGetByID(id);
            _genreService.TDelete(deleteGenre);
            return RedirectToAction("Index", "Activities", new { area = "Admin" });
        }
    }
}
