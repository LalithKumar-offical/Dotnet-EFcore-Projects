using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using praticerolebasedauthorization.Models;

namespace praticerolebasedauthorization.Services
{
    public class WebseriesServices
    {
        private readonly CodeContext? _codeContext;
        public WebseriesServices(CodeContext? codeContext)
        {
            _codeContext = codeContext;
        }

        public async Task<IEnumerable<Webseries>> get()
        {
            return await _codeContext.DbWebSeries.ToListAsync();
        }
        public async Task<Webseries> getbyid(int id) 
        {
            return await _codeContext.DbWebSeries.FirstOrDefaultAsync(p=>p.webseriesId==id);
        }
        public async Task<Webseries> addwebseries(Webseries webseries) { 
            _codeContext.DbWebSeries.Add(webseries);
            await _codeContext.SaveChangesAsync();
            return webseries;   
        }
    }
}
