using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWeb.Data;
using MediaWeb.Domain.Film;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MediaWeb.Models.Film;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace MediaWeb.Controllers
{
    [Authorize]
    public class FilmController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private List<string> _genreList;

        public FilmController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            GetGenres();
        }
        private void GetGenres()
        {
            List<FilmGenre> Genres = _context.FilmGenre.ToList();
            _genreList = new List<string>();
            foreach (FilmGenre item in Genres)
            {
                _genreList.Add(item.Genre);
            }
        }
        public IActionResult Index()
        {
            List<FilmListViewModel> modelList = new List<FilmListViewModel>();
            List<Film> filmsFromDb = _context.Film.Include(x => x.Genres).Where(x => x.Zichtbaar == true).ToList();
            
            foreach (Film item in filmsFromDb)
            {
                List<string> genreList = new List<string>();
                foreach (var genre in item.Genres)
                {
                    genreList.Add(_context.FilmGenre.FirstOrDefault(x => x.Id == genre.GenreId).Genre);
                }
                modelList.Add(new FilmListViewModel()
                {
                    Id = item.Id,
                    FilmArt = item.Foto,
                    Titel = item.Titel,
                    Genres = genreList
                });
            }
            return View(modelList);
        }
        public IActionResult Detail(int Id)
        {
            return View(new FilmDetailViewModel());
        }
    }
}
