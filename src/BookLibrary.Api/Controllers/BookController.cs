using BookLibrary.Application.Books.Commands;
using BookLibrary.Application.Books.Queries;
using BookLibrary.Application.Books.Requests;
using BookLibrary.Application.Interfaces.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;
        public BookController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.SendQuery(new GetAllBooksQuery());
            return Ok(result);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.SendQuery(new GetBookByIdQuery(id)));
        }

        /// <summary>
        /// Find a book by any term.
        /// </summary>
        /// <param name="searchValue">It's used to finding some book by any property. (Optional)</param>
        /// <returns>The action result.</returns>
        [HttpGet("find/{searchValue?}")]
        public async Task<IActionResult> Find(string searchValue = null)
        {
            return Ok(await _mediator.SendQuery(new GetBookByTermQuery(searchValue)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterBookRequest request)
        {
            try
            {
                var command = new RegisterBookCommand(
                    request.Title,
                    request.FirstName,
                    request.LastName,
                    request.TotalCopies,
                    request.CopiesInUse,
                    request.Type,
                    request.Isbn,
                    request.Category);

                var result = await _mediator.SendCommand(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
