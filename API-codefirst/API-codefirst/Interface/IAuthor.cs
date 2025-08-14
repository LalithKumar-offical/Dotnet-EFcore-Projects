using API_codefirst.Models;

namespace API_codefirst.Interface
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> Getallauthor();
      
    }
}
