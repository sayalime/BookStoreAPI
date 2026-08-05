using BookStoreAPI.DTOs;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;

namespace BookStoreAPI.Services
{
    public class BookService : IBookService
    {

        public readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<List<BookDto>> GetAllAsync()
        {
            List<Book> books = await bookRepository.GetAllAsync();

            List<BookDto> bookdto = new List<BookDto>();
            foreach (var book in books)
            {
                bookdto.Add(new BookDto
                {
                    Id=book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Price = book.Price
                });
            }
            return bookdto;
        }

        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var Book = await bookRepository.GetByIdAsync(id);
            if (Book == null)
            {
                return null;
            }
           return MapToBookDto(Book);
        }


        public async Task<BookDto> AddAsync(CreateBookDto bookdto)
        {
            if (bookdto.Price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }

            //await bookRepository.AddAsync(book);
            //return book;

            var Book = MapToBook(bookdto);

            await bookRepository.AddAsync(Book);

           return MapToBookDto(Book);


        }


        public async Task<BookDto?> UpdateAsync(int id, UpdateBookDto dto)
        {
            var Book = await bookRepository.GetByIdAsync(id);
            if (Book == null) { 
                return null;
            }
            Book.Title = dto.Title;
            Book.Author = dto.Author;
            Book.Price = dto.Price;


            await bookRepository.UpdateAsync(Book);
             
            return MapToBookDto(Book);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return false;
            }


            await bookRepository.DeleteAsync(book);
            return true;
        }

        private BookDto MapToBookDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };
        }

        private Book MapToBook(CreateBookDto bookdto)
        {
            return new Book
            {
                Title = bookdto.Title,
                Author = bookdto.Author,
                Price = bookdto.Price
            };
        }




        }
}
