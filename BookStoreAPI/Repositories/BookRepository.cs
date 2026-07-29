using BookStoreAPI.Data;
using BookStoreAPI.Interfaces;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly BookDbContext Context;

        public BookRepository(BookDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await Context.Books.FindAsync(id);
        }

        public async Task AddAsync(Book book)
        {
            await Context.Books.AddAsync(book);
            
        }


        public Task UpdateAsync(Book book)
        {
             Context.Books.Update(book);
            return Task.CompletedTask;
        }

        public  Task DeleteAsync(Book book)
        {
             Context.Books.Remove(book);
            return Task.CompletedTask;
        }
    }
}
