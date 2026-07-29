using BookStoreAPI.Models;

namespace BookStoreAPI.Interfaces
{
    public interface IBookRepository
    {
        //Retrieve all books asynchronously and return them as a collection.
        public Task<IEnumerable<Book>> GetAllAsync();

        public Task<Book?> GetByIdAsync(int id);

        public Task AddAsync(Book book);

        public Task UpdateAsync(Book book);
        public Task DeleteAsync(Book book);
    }
}
