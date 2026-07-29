using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _db;

        public BooksController(BookDbContext context)
        {
            _db = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()

        {
            try
            {
                var Books = await _db.Books.ToListAsync();
                return Ok(Books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

            [HttpPost]

        public async Task<IActionResult> Addbook(Book book)
        {
           await  _db.Books.AddAsync(book);
           await _db.SaveChangesAsync();
            return CreatedAtAction(nameof (GetBooks), new {id=book.Id},book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book Updatedvalues)
        {
            var books = await _db.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            else
            {
                books.Title = Updatedvalues.Title;
                books.Author = Updatedvalues.Author;
                books.Price = Updatedvalues.Price;

               await _db.SaveChangesAsync();
            }

            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book=await _db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _db.Books.Remove(book);
                await _db.SaveChangesAsync();
            }
            return NoContent();
        }
    }
}
