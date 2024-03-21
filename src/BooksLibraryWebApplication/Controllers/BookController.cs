using BookLibrary.Application.DataTransferObjects;
using BookLibrary.WebApplication.ApiConnection;
using BooksLibraryWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace BooksLibraryWebApplication.Controllers
{
    public class BookController : BaseController
    {
        public BookController(IWebApiService webApi, IConfiguration configuration) : base(webApi, configuration)
        {
            _configuration = configuration;
        }

        // GET: BookController
        public async Task<IActionResult> Index()
        {
            _urlRedirect = "api/Book";
            var result = await _webApi.GetAsync<IEnumerable<BookDto>>(_urlRedirect);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchValue)
        {

            if(string.IsNullOrEmpty(searchValue)) 
                return RedirectToAction("Index");

            _urlRedirect = $"api/Book/find/{searchValue}";
            var result = await _webApi.GetAsync<IEnumerable<BookDto>>(_urlRedirect);
            return View(result);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
