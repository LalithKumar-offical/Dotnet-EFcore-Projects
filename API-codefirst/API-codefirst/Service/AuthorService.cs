using API_codefirst.Interface;
using API_codefirst.Models;
using Microsoft.EntityFrameworkCore;

namespace API_codefirst.Service
{
    public class AuthorService : IAuthor
    {
        private readonly CodeContext _context;
        public AuthorService(CodeContext context)
        {
            _context=context;
        }
        
        public async Task<IEnumerable<Author>> Getallauthor()
        {
         return await _context.Authors.Include(p=>p.Books).ToListAsync();
        }
    }
}
