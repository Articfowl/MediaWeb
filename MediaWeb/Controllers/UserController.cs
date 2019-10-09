using MediaWeb.Data;
using MediaWeb.Domain.Muziek;
using MediaWeb.Domain.Serie;
using MediaWeb.Domain.Film;
using MediaWeb.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MediaWeb.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index() {
            string userId = _userManager.GetUserId(User);
            IndexListViewModel model = new IndexListViewModel();
            List<UserListViewModel> mList = new List<UserListViewModel>();
            List<UserListViewModel> sList = new List<UserListViewModel>();
            List<UserListViewModel> fList = new List<UserListViewModel>();
            var muList = _context.MuziekPlaylist.Where(mp => mp.UserId == userId);
            var seList = _context.SeriePlaylist.Where(sp => sp.UserId == userId);
            var fiList = _context.FilmPlaylist.Where(fp => fp.UserId == userId);
            foreach (var item in muList)
            {
                mList.Add(new UserListViewModel() { Id = item.Id, Titel = item.Titel, Type = "Mu" });
            }
            foreach (var item in seList)
            {
                sList.Add(new UserListViewModel() { Id = item.Id, Titel = item.Titel, Type = "Se" });
            }
            foreach (var item in fiList)
            {
                fList.Add(new UserListViewModel() { Id = item.Id, Titel = item.Titel, Type = "Fi" });
            }
            model.MuziekList = mList;
            model.FilmList = fList;
            model.SerieList = sList;
            return View(model);
        }
        public IActionResult Create()
        {
            ListCreateViewModel model = new ListCreateViewModel() {TypeList = new List<SelectListItem>()};
            model.TypeList.Add(new SelectListItem("Muziek", "Mu"));
            model.TypeList.Add(new SelectListItem("Film", "Fi"));
            model.TypeList.Add(new SelectListItem("Serie", "Se"));
            return View(model);

        }
        [HttpPost]
        public IActionResult Create(ListCreateViewModel model)
        {
            int id;
            switch (model.Type)
            {
                case "Mu":
                    _context.MuziekPlaylist.Add(new MuziekPlaylist() { Titel = model.Titel, UserId = _userManager.GetUserId(User) });
                    _context.SaveChanges();
                    id = _context.MuziekPlaylist.FirstOrDefault(mp => mp.Titel == model.Titel && mp.UserId == _userManager.GetUserId(User)).Id;
                    break;
                case "Fi":
                    _context.FilmPlaylist.Add(new FilmPlaylist() { Titel = model.Titel, UserId = _userManager.GetUserId(User) });
                    _context.SaveChanges();
                    id = _context.FilmPlaylist.FirstOrDefault(fp => fp.Titel == model.Titel && fp.UserId == _userManager.GetUserId(User)).Id;
                    break;
                case"Se":
                    _context.SeriePlaylist.Add(new SeriePlaylist() { Titel = model.Titel, UserId = _userManager.GetUserId(User) });
                    _context.SaveChanges();
                    id = _context.SeriePlaylist.FirstOrDefault(sp => sp.Titel == model.Titel && sp.UserId == _userManager.GetUserId(User)).Id;
                    break;
                default:
                    id = -1;
                    break;
            }
            return RedirectToAction("Detail", new { id, model.Type });
        }
        public IActionResult Detail(int id, string type)
        {
            ListDetailViewModel model = new ListDetailViewModel() { Id = id, Type = type, Items = new List<ListItemViewModel>() };
            switch (type)
            {
                case "Mu":
                    var mList = _context.MuziekPlaylist.FirstOrDefault(mp => mp.Id == id);
                    foreach (var item in _context.UserMuziekPlaylist.Where(ump => ump.UserId == _userManager.GetUserId(User) && ump.PlaylistId == id))
                    {
                        model.Items.Add(new ListItemViewModel() { Id = item.MuziekId, Titel = _context.Nummer.FirstOrDefault(n => n.Id == item.MuziekId).Titel });
                    }
                    model.Titel = mList.Titel;
                    break;
                case "Fi":
                    var fList = _context.FilmPlaylist.FirstOrDefault(fp => fp.Id == id);
                    foreach (var item in _context.UserFilmPlaylist.Where(ufp => ufp.UserId == _userManager.GetUserId(User) && ufp.PlaylistId == id))
                    {
                        model.Items.Add(new ListItemViewModel() { Id = item.FilmId, Titel = _context.Film.FirstOrDefault(f => f.Id == item.FilmId).Titel });
                    }
                    model.Titel = fList.Titel;
                    break;
                case "Se":
                    var sList = _context.SeriePlaylist.FirstOrDefault(sp => sp.Id == id);
                    foreach (var item in _context.UserSeriePlaylist.Where(usp => usp.UserId == _userManager.GetUserId(User) && usp.PlaylistId == id))
                    {
                        model.Items.Add(new ListItemViewModel() { Id = item.SerieEpisodeId, Titel = _context.SerieEpisode.FirstOrDefault(se => se.Id == item.SerieEpisodeId).Titel });
                    }
                    model.Titel = _context.SeriePlaylist.FirstOrDefault(sp => sp.Id == id).Titel;
                    break;
                default:
                    break;
            }
            return View(model);
        }
        public IActionResult Edit(int id, string type)
        {
            ListEditViewModel model = new ListEditViewModel() { Id = id, Type = type };
            switch (type)
            {
                case "Mu":
                    model.Titel = _context.MuziekPlaylist.FirstOrDefault(mp => mp.Id == id).Titel;
                    break;
                case "Fi":
                    model.Titel = _context.FilmPlaylist.FirstOrDefault(fp => fp.Id == id).Titel;
                    break;
                case "Se":
                    model.Titel = _context.SeriePlaylist.FirstOrDefault(sp => sp.Id == id).Titel;
                    break;
                default:
                    break;
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ListEditViewModel model)
        {
            switch (model.Type)
            {
                case "Mu":
                    MuziekPlaylist mList = _context.MuziekPlaylist.FirstOrDefault(mp => mp.Id == model.Id);
                    mList.Titel = model.Titel;
                    _context.SaveChanges();
                    break;
                case "Fi":
                    FilmPlaylist fList = _context.FilmPlaylist.FirstOrDefault(fp => fp.Id == model.Id);
                    fList.Titel = model.Titel;
                    _context.SaveChanges();
                    break;
                case "Se":
                    MuziekPlaylist sList = _context.MuziekPlaylist.FirstOrDefault(sp => sp.Id == model.Id);
                    sList.Titel = model.Titel;
                    _context.SaveChanges();
                    break;
                default:
                    break;
            }
            return RedirectToAction("Detail", new { model.Id, model.Type });
        }
        
        public IActionResult Delete(int id, string type)
        {
            switch (type)
            {
                case "Mu":
                   MuziekPlaylist mModel = _context.MuziekPlaylist.FirstOrDefault(mp => mp.Id == id);
                    _context.MuziekPlaylist.Remove(mModel);
                    _context.SaveChanges();
                    break;
                case "Fi":
                    FilmPlaylist fModel = _context.FilmPlaylist.FirstOrDefault(fp => fp.Id == id);
                    _context.FilmPlaylist.Remove(fModel);
                    _context.SaveChanges();
                    break;
                case "Se":
                   SeriePlaylist sModel = _context.SeriePlaylist.FirstOrDefault(sp => sp.Id == id);
                    _context.SeriePlaylist.Remove(sModel);
                    _context.SaveChanges();
                    break;
                default:
                    break;
            }

            return RedirectToAction("Index");
        }
    }
}
    