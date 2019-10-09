using MediaWeb.Data;
using MediaWeb.Domain.Muziek;
using MediaWeb.Models.Muziek;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Controllers
{
    [Authorize]
    public class MuziekController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private List<string> _genreList;
        private List<string> _statusList;
        private List<SelectListItem> _statusItemList;

        public MuziekController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
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
            List<MuziekGenre> Genres = _context.MuziekGenre.ToList();
            _genreList = new List<string>();
            foreach (MuziekGenre item in Genres)
            {
                _genreList.Add(item.Genre);
            }
        }
        private void GetStatus()
        {
            //Get list Film Statuses from DB
            _statusItemList = new List<SelectListItem>();
            _statusList = new List<string>();
            foreach (var item in _context.MuziekGeluisterdStatus)
            {
                _statusItemList.Add(new SelectListItem(item.Status, item.Id.ToString()));
                _statusList.Add(item.Status);
            }
        }
        
        [HttpGet]
        public IActionResult Index(List<string> selectedGenres)
        {
            List<Nummer> Nummers = _context.Nummer.Include(n => n.Album).ThenInclude(a => a.Artiest).Include(n => n.Genres).Include(n => n.Favourites).Include(n => n.GeluisterdStatus).ToList();
            List<MuziekListViewModel> modelList = new List<MuziekListViewModel>();
            foreach (Nummer item in Nummers)
            {
                MuziekListViewModel mLVM = new MuziekListViewModel()
                {
                    Id = item.Id,
                    Titel = item.Titel,
                    Artiest= item.Album.Artiest.Naam,
                    ArtiestId = item.Album.ArtiestId,
                    AlbumArt = item.Album.AlbumArt,
                    AlbumTitel = item.Album.Titel,
                    AlbumId = item.Album.Id,
                    Genres = new List<string>()
                };
                foreach (GenreMuziek genre in item.Genres)
                {
                    mLVM.Genres.Add(_context.MuziekGenre.FirstOrDefault(mg => mg.Id == genre.GenreId).Genre);
                }

                modelList.Add(mLVM);
            }
            MuziekIndexViewModel model = new MuziekIndexViewModel() { Genres = _genreList, MuziekListViewModels = modelList, SelectedGenres = new List<string>() };
            foreach (var item in selectedGenres)
            {
                model.SelectedGenres.Add(_context.MuziekGenre.FirstOrDefault(mg => mg.Id == Convert.ToInt32(item)).Genre);
            }
            return View(model);
        }
        public IActionResult CreateArtiest(string inputStr = "")
        {
            AlbumCreateViewModel model = new AlbumCreateViewModel { Titel = inputStr };
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateAlbum(string inputStr)
        {
            AlbumCreateViewModel model = new AlbumCreateViewModel() { Artiest = inputStr };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlbum(AlbumCreateViewModel model)
        {
            MuziekArtiest artiest = _context.MuziekArtiest.FirstOrDefault(ma => ma.Naam == model.Artiest);
            if (artiest == null)
            {
                _context.MuziekArtiest.Add(new MuziekArtiest() { Naam = model.Artiest });
                artiest = _context.MuziekArtiest.FirstOrDefault(ma => ma.Naam == model.Artiest);
                _context.SaveChanges();
            }
            MuziekAlbum album = _context.MuziekAlbum.FirstOrDefault(ma => ma.ArtiestId == _context.MuziekArtiest.FirstOrDefault(mar => mar.Naam == model.Artiest).Id && ma.Titel == model.Titel);
            int id;
            if (album == null)
            {
                MuziekAlbum muziekAlbum = new MuziekAlbum()
                {
                    ArtiestId = _context.MuziekArtiest.FirstOrDefault(ma => ma.Naam == model.Artiest).Id,
                    Titel = model.Titel
                };
                if (model.AlbumArt != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.AlbumArt.CopyToAsync(memoryStream);
                        muziekAlbum.AlbumArt = memoryStream.ToArray();
                    }
                }
                _context.MuziekAlbum.Add(muziekAlbum);
                _context.SaveChanges();
                id = _context.MuziekAlbum.FirstOrDefault(ma => ma.Titel == model.Titel).Id;
            }
            else
            {
                id = album.Id;
            }
            return RedirectToAction("AlbumDetail", new {id});
        }
        [HttpGet]
        public IActionResult Find(string inputStr)
        {

            MuziekArtiest muziekArtiest = _context.MuziekArtiest.FirstOrDefault(ma => ma.Naam == inputStr);
            if (muziekArtiest == null)
            {
                return RedirectToAction("Artiest", new { inputStr });
            }
            else
            {
                return RedirectToAction("ArtiestDetail", new { muziekArtiest.Id });
            }

        }
        //[HttpGet]
        public IActionResult Create(string inputStr, string album)
        {
            MuziekArtiest muziekArtiest = _context.MuziekArtiest.FirstOrDefault(ma => ma.Naam == inputStr);
            MuziekCreateViewModel model = new MuziekCreateViewModel() { Artiest = inputStr, AlbumTitel = album, AllGenres = _genreList };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(MuziekCreateViewModel model, List<int> genres)
        {
            _context.Nummer.Add(new Nummer { Lengte = model.Lengte, Titel = model.Titel, AlbumId = _context.MuziekAlbum.FirstOrDefault(x => x.Titel == model.AlbumTitel).Id });
            _context.SaveChanges();
            Nummer newNummer = _context.Nummer.FirstOrDefault(n => n.Titel == model.Titel && n.Lengte == model.Lengte);
            foreach (int item in genres)
            {
                _context.GenreMuziek.Add(new GenreMuziek() { MuziekId = newNummer.Id, GenreId = item });
            }
            _context.SaveChanges();
            int id = newNummer.Id;
            return RedirectToAction("NummerDetail", new { id });
        }
        public IActionResult Artiest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Artiest(ArtiestCreateViewModel model)
        {
            _context.MuziekArtiest.Add(new MuziekArtiest() { Naam = model.Naam });
            _context.SaveChanges();
            return RedirectToAction("ArtiestDetail", new { _context.MuziekArtiest.FirstOrDefault(ma => ma.Naam == model.Naam).Id });
        }
        public IActionResult ArtiestDetail(int id)
        {
            ArtiestDetailViewModel model = new ArtiestDetailViewModel() { Id = id, Albums = new List<string>(), AlbumIds = new List<int>(), Naam = _context.MuziekArtiest.FirstOrDefault(ma => ma.Id == id).Naam };
            foreach (var item in _context.MuziekAlbum.Where(ma => ma.ArtiestId == id))
            {
                model.Albums.Add(item.Titel);
                model.AlbumIds.Add(item.Id);
            }
            return View(model);
        }
        public IActionResult AlbumDetail(int id)
        {
            MuziekAlbum album = _context.MuziekAlbum.Include(ma => ma.Artiest).Include(ma => ma.Nummer).FirstOrDefault(ma => ma.Id == id);
            AlbumDetailViewModel model = new AlbumDetailViewModel() { Id = id, ArtiestId = album.ArtiestId, Artiest = album.Artiest.Naam, AlbumArt = album.AlbumArt, Titel = album.Titel, Nummers = new List<string>(), NummersId = new List<int>() };
            if (album.Nummer.Count > 0)
            {
                model.Artiest = _context.MuziekArtiest.FirstOrDefault(ma => ma.Id == album.ArtiestId).Naam;
                foreach (var item in album.Nummer)
                {
                    model.Nummers.Add(item.Titel);
                    model.NummersId.Add(item.Id);
                }
            }
            return View(model);
        }
        public IActionResult NummerDetail(int id)
        {
            Nummer nummer = _context.Nummer.Include(n => n.Album).ThenInclude(a => a.Artiest).FirstOrDefault(n => n.Id == id);
            MuziekDetailViewModel model = new MuziekDetailViewModel()
            {
                Id = id,
                Titel = nummer.Titel,
                Lengte = nummer.Lengte,
                Artiest = nummer.Album.Artiest.Naam,
                ArtiestId = nummer.Album.ArtiestId,
                Album = nummer.Album.Titel,
                AlbumId = nummer.AlbumId,
                Zichtbaar = nummer.Zichtbaar
            };
            return View(model);
        }
        public IActionResult Edit(int id, int type)
        {
            MuziekEditViewModel model = new MuziekEditViewModel() { Type = type, Id = id };
            switch (type)
            {
                case 0:
                    model.Artiest = _context.MuziekArtiest.FirstOrDefault(ma => ma.Id == id).Naam;
                    break;
                case 1:
                    MuziekAlbum album = _context.MuziekAlbum.FirstOrDefault(ma => ma.Id == id);
                    model.CurrentArt = album.AlbumArt;
                    model.AlbumTitel = album.Titel;
                    break;
                case 2:
                    Nummer nummer = _context.Nummer.FirstOrDefault(n => n.Id == id);
                    model.SongTitel = nummer.Titel;
                    model.Lengte = nummer.Lengte;
                    model.Zichtbaar = nummer.Zichtbaar;
                    break;
                default:
                    return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MuziekEditViewModel model, int type)
        {
            switch (type)
            {
                case 0:
                    MuziekArtiest artiest = _context.MuziekArtiest.FirstOrDefault(ma => ma.Id == model.Id);
                    artiest.Naam = model.Artiest;
                    _context.SaveChanges();
                    return RedirectToAction("ArtiestDetail", new { model.Id });
                case 1:
                    MuziekAlbum muziekAlbum = _context.MuziekAlbum.FirstOrDefault(ma => ma.Id == model.Id);
                    muziekAlbum.Titel = model.AlbumTitel;
                    if (model.AlbumArt != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await model.AlbumArt.CopyToAsync(memoryStream);
                            muziekAlbum.AlbumArt = memoryStream.ToArray();
                        }
                    }
                    _context.SaveChanges();
                    return RedirectToAction("AlbumDetail", new { model.Id });
                case 2:
                    Nummer nummer = _context.Nummer.FirstOrDefault(n => n.Id == model.Id);
                    nummer.Titel = model.SongTitel;
                    nummer.Lengte = model.Lengte;
                    nummer.Zichtbaar = model.Zichtbaar;
                    _context.SaveChanges();
                    return RedirectToAction("NummerDetail", new { model.Id });
                default:
                    return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id, int type)
        {

            switch (type)
            {
                case 0:
                    MuziekArtiest artiest = _context.MuziekArtiest.FirstOrDefault(ma => ma.Id == id);
                    _context.MuziekArtiest.Remove(artiest);
                    break;
                case 1:
                    MuziekAlbum album = _context.MuziekAlbum.FirstOrDefault(ma => ma.Id == id);
                    _context.MuziekAlbum.Remove(album);
                    break;
                case 2:
                    Nummer nummer = _context.Nummer.FirstOrDefault(n => n.Id == id);
                    _context.Nummer.Remove(nummer);
                    break;
                default:
                    return RedirectToAction("Index");
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
