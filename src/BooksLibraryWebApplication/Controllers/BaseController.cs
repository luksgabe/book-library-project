using BookLibrary.WebApplication.ApiConnection;
using Microsoft.AspNetCore.Mvc;

namespace BooksLibraryWebApplication.Controllers
{
    public class BaseController : Controller
    {
        public readonly IWebApiService _webApi;
        public IConfiguration _configuration;
        public string _urlRedirect;


        public BaseController(IWebApiService webApi, IConfiguration configuration)
        {
            _webApi = webApi;
            _configuration = configuration;
            string urlApi = configuration.GetValue<string>("WebApi-Url");

            _webApi.UriBase = new Uri(urlApi);
        }
    }
}
