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
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace MediaWeb.Controllers
{
    [Authorize]
    public class FilmController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private List<string> _genreList;
        private List<string> _statusList;
        private List<SelectListItem> _statusItemList;

        public FilmController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            GetGenres();
            GetStatus();
        }

        private void GetGenres()
        {
            //Get list Film Genres from DB
            List<FilmGenre> Genres = _context.FilmGenre.ToList();
            _genreList = new List<string>();
            foreach (FilmGenre item in Genres)
            {
                _genreList.Add(item.Genre);
            }
        }
        private void GetStatus()
        {
            //Get list Film Statuses from DB
            _statusItemList = new List<SelectListItem>();
            _statusList = new List<string>();
            foreach (var item in _context.FilmGezienStatus) 
            {
                _statusItemList.Add(new SelectListItem( item.Status, item.Id.ToString()));
                _statusList.Add(item.Status);
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
            string Userid = _userManager.GetUserId(User);
            List<FilmPlaylist> filmPlaylists = _context.FilmPlaylist.Where(fp => fp.UserId == _userManager.GetUserId(User)).ToList();
            Film filmFromDb = _context.Film.Include(f => f.Favourites).Include(f => f.FilmGezienStatuses).Include(f => f.Genres)
                .Include(f => f.Regisseurs).FirstOrDefault(x => x.Id == Id);
            //Als film niet zichtbaar is en user is geen admin redirecten naar index;
            if (!filmFromDb.Zichtbaar && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Index");
            }
            FilmDetailViewModel myModel = new FilmDetailViewModel()
            {
                Id = filmFromDb.Id,
                FilmArt = filmFromDb.Foto,
                AantalFavoriet = filmFromDb.Favourites.Count,
                Titel = filmFromDb.Titel,
                AantalGezien = 0,
                GezienStatusList = _statusItemList,
                Beschrijving = filmFromDb.Beschrijving,
                UserPlaylists = new List<SelectListItem>()

            };
            //Favoriet + user checken.
            UserFilmFavourite UFF = filmFromDb.Favourites.FirstOrDefault(x => x.UserId == Userid && x.FilmId == Id);
            if (UFF != null )
            {
                myModel.Favoriet = true;
            }
            //Gezienstatus+ user checken.
            UserFilmGezienStatus UFG = _context.UserFilmGezienStatus.FirstOrDefault(x => x.UserId == _userManager.GetUserId(User) && x.FilmId == Id);
            if (UFG != null){
                myModel.GezienStatusList[UFG.StatusId - 1].Selected = true;
            }
            foreach (var item in filmFromDb.FilmGezienStatuses)
            {
                if(item.StatusId == 3)
                {
                    myModel.AantalGezien++;
                }
            }
            //Genres toevoegen
            foreach (var genre in filmFromDb.Genres)
            {
                myModel.Genres.Add(_context.FilmGenre.FirstOrDefault(fg => fg.Id == genre.GenreId).Genre);
            }
            //Regisseurs toevoegen
            foreach (var regi in filmFromDb.Regisseurs)
            {
                myModel.Regisseurs.Add(_context.FilmRegisseur.FirstOrDefault(fr => fr.Id == regi.RegisseurId).Naam);
            }
            //Playlists toevoegen
            foreach (var item in filmPlaylists)
            {
                if (!_context.UserFilmPlaylist.Any(ufp => ufp.FilmId == Id &&  ufp.PlaylistId == item.Id)){
                    myModel.UserPlaylists.Add(new SelectListItem(item.Titel, item.Id.ToString()));
                }
            }
            return View(myModel);
        }
        [HttpPost]
        public IActionResult Detail(int Id, string status , int typ) {
            if (typ == 1)
            {
                UserFilmFavourite UFF = _context.UserFilmFavourite.FirstOrDefault(x => x.UserId == _userManager.GetUserId(User) && x.FilmId == Id);
                if (UFF == null)
                {
                    _context.UserFilmFavourite.Add(new UserFilmFavourite() { UserId = _userManager.GetUserId(User), FilmId = Id });
                }
                else
                {
                    _context.UserFilmFavourite.Remove(UFF);
                }
            }
            else
            {
                UserFilmGezienStatus UFGS = _context.UserFilmGezienStatus.FirstOrDefault(x => x.UserId == _userManager.GetUserId(User) && x.FilmId == Id);
                if (UFGS == null)
                {
                    _context.UserFilmGezienStatus.Add(new UserFilmGezienStatus() { UserId = _userManager.GetUserId(User),
                        FilmId = Id , StatusId=Convert.ToInt32(status)});
                }
                else
                {
                    UFGS.StatusId = Convert.ToInt32(status);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Detail");
        }
        public IActionResult Create()
        {
            return View(new FilmCreateViewModel() { GenresList = _genreList });
        }
        [HttpPost]
        public async Task<IActionResult> Create(FilmCreateViewModel model, List<int> Genres, List<string> Regi)
        {
            Regi.RemoveAt(Regi.Count()-1);
            Film film = new Film()
            {
                Beschrijving = model.Beschrijving,
                Titel = model.Titel,
                Lengte = model.Lengte,
                Zichtbaar = true,
            };
            if (model.Foto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Foto.CopyToAsync(memoryStream);
                    film.Foto = memoryStream.ToArray();
                }
            }
            _context.Film.Add(film);
            _context.SaveChanges();
            Film newFilm = _context.Film.FirstOrDefault(x => x.Titel == film.Titel && x.Beschrijving == film.Beschrijving && x.Lengte == film.Lengte);
            foreach (var genre in Genres)
            {
                _context.GenreFilm.Add(new GenreFilm() { FilmId = newFilm.Id, GenreId = genre });
            }
            foreach (var regisseur in Regi)
            {
                FilmRegisseur FR = _context.FilmRegisseur.FirstOrDefault(x => x.Naam == regisseur);
                if(FR != null)
                {
                    _context.RegisseurFilm.Add(new RegisseurFilm() { FilmId = newFilm.Id, RegisseurId = FR.Id });
                    _context.SaveChanges();
                }
                else
                {
                    _context.FilmRegisseur.Add(new FilmRegisseur() { Naam = regisseur });
                    _context.SaveChanges();
                    _context.RegisseurFilm.Add(new RegisseurFilm() { FilmId = newFilm.Id, RegisseurId = _context.FilmRegisseur.FirstOrDefault(x => x.Naam == regisseur).Id });
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Detail", new { newFilm.Id });
        }
        public IActionResult Edit(int Id)
        {
            Film filmFromDb = _context.Film.Include(f => f.Regisseurs).Include(f => f.Genres).FirstOrDefault(f => f.Id == Id);
            FilmEditViewModel fevModel = new FilmEditViewModel()
            {
                Id = Id,
                Beschrijving = filmFromDb.Beschrijving,
                Titel = filmFromDb.Titel,
                HuidigeFoto = filmFromDb.Foto,
                GenresList = _genreList,
                SelectedGenres = new List<string>(),
                Lengte = filmFromDb.Lengte,
                Regisseurs = new List<string>()
            };
            foreach (var genr in filmFromDb.Genres)
            {
                fevModel.SelectedGenres.Add(_context.FilmGenre.FirstOrDefault(fg => fg.Id == genr.GenreId).Genre);
            }
            foreach (var regi in filmFromDb.Regisseurs)
            {
                FilmRegisseur freg = _context.FilmRegisseur.FirstOrDefault(fr => fr.Id == regi.RegisseurId);
                fevModel.Regisseurs.Add(freg.Naam);
            }
            return View(fevModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FilmEditViewModel model, List<int> Genres, List<string> Regi)
        {
            Regi.RemoveAt(Regi.Count() - 1);
            Film film = _context.Film.Include(f => f.Regisseurs).FirstOrDefault(f => f.Id == model.Id);
            film.Lengte = model.Lengte;
            film.Beschrijving = model.Beschrijving;
            film.Titel = model.Titel;
            _context.GenreFilm.RemoveRange(_context.GenreFilm.Where(gf => gf.FilmId == model.Id));
            _context.RegisseurFilm.RemoveRange(_context.RegisseurFilm.Where(rf => rf.FilmId == model.Id));
            foreach (var genre in Genres)
            {
                _context.GenreFilm.Add(new GenreFilm() { FilmId = model.Id, GenreId = genre });
            }
            foreach (var regisseur in Regi)
            {
                FilmRegisseur FR = _context.FilmRegisseur.FirstOrDefault(x => x.Naam == regisseur);
                if (FR != null)
                {
                    _context.RegisseurFilm.Add(new RegisseurFilm() { FilmId = model.Id, RegisseurId = FR.Id });
                    _context.SaveChanges();
                }
                else
                {
                    _context.FilmRegisseur.Add(new FilmRegisseur() { Naam = regisseur });
                    _context.SaveChanges();
                    _context.RegisseurFilm.Add(new RegisseurFilm() { FilmId = model.Id, RegisseurId = _context.FilmRegisseur.FirstOrDefault(x => x.Naam == regisseur).Id });
                    _context.SaveChanges();
                }
            }
            if (model.Foto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Foto.CopyToAsync(memoryStream);
                    film.Foto = memoryStream.ToArray();
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Detail", new { model.Id });
        }
        
        public IActionResult Delete(int Id)
        {
            Film filmToRemove = _context.Film.FirstOrDefault(f => f.Id == Id);
            _context.Film.Remove(filmToRemove);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult AddItem(FilmDetailViewModel model)
        {
            int id = int.Parse(model.PlaylistId);
            int movieId = model.Id;
            string type = "Fi";
            _context.UserFilmPlaylist.Add(new UserFilmPlaylist() { FilmId = movieId, PlaylistId = id, UserId = _userManager.GetUserId(User) });
            _context.SaveChanges();
            return RedirectToAction("Detail", "User", new { id, type});
        }
    }
}
