using API_codefirst.Models;

namespace API_codefirst.Interface
{
    public interface IBook
    {
        Task<IEnumerable<Book>> Getallbook();
    }
}
