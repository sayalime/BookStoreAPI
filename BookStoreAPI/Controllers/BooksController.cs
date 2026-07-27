using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetBooks()
        {
            var Books = _db.Books.ToList();
            return Ok(Books);
        }

        [HttpPost]

        public IActionResult Addbook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return Ok("Inserted");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book Updatedvalues)
        {
            var books = _db.Books.Find(id);
            if (books == null)
            {
                return NotFound();
            }
            else
            {
                books.Title = Updatedvalues.Title;
                books.Author = Updatedvalues.Author;
                books.Price = Updatedvalues.Price;

                _db.SaveChanges();
            }

            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book=_db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
            }
            return NoContent();
        }
    }
}
