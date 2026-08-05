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

        public async Task<List<Book>> GetAllAsync()
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
            await Context.SaveChangesAsync();

        }


        public async Task UpdateAsync(Book book)
        {
             Context.Books.Update(book);
            await Context.SaveChangesAsync();

            
        }

        public  async Task DeleteAsync(Book book)
        {
            Context.Books.Remove(book);
            await Context.SaveChangesAsync();


        }
    }
}
