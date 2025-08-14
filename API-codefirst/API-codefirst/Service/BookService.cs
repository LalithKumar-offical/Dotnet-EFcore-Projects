using API_codefirst.Interface;
using API_codefirst.Models;
using Microsoft.EntityFrameworkCore;

namespace API_codefirst.Service
{
    public class BookService : IBook
    {
        private readonly CodeContext _context;
        public BookService(CodeContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Book>> Getallbook()
        {
            return await _context.Books.Include(a => a.Author).ToListAsync();
        }
    }
}
