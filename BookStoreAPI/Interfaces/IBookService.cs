using BookStoreAPI.DTOs;
using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface IBookService
    {

        public Task<List<BookDto>> GetAllAsync();

        public Task<BookDto?> GetByIdAsync(int id);

        public Task<BookDto> AddAsync(CreateBookDto book);

        public Task<BookDto?> UpdateAsync(int id, UpdateBookDto dto);

        public Task<bool> DeleteAsync(int id);
    }
}
