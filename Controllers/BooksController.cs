using find_book.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using find_book.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace find_book.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly RoyalLibraryContext _dbcontext;

        public BooksController(RoyalLibraryContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] string? type, [FromQuery] string? value)
        {

            IEnumerable<Book> res = null;

            if(string.IsNullOrEmpty(value))
            {
                return Ok(await _dbcontext.Books.ToListAsync());
            }

            if(type.ToUpper() == "AUTHOR")
            {
                res = await _dbcontext.Books.Where(b =>
                        (b.FirstName +" "+ b.LastName).ToUpper().Contains(value.ToUpper())
                    ).ToListAsync();
            }
            else if(type.ToUpper() == "ISBN")
            {
                res = await _dbcontext.Books.Where(b => b.Isbn == value).ToListAsync();
            }
            else if(type.ToUpper() == "TITLE")
            {
                res = await _dbcontext.Books.Where(b => b.Title.ToUpper().Contains(value.ToUpper())).ToListAsync();
            }

            
            return Ok(res);   
        }
    }
}
