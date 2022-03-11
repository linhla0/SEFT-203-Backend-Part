using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IContactService
    {
        Contact Create(Contact model);
        Contact Update(int id, Contact model);
        Contact Delete(int id);
        Contact Get(int id);
        IEnumerable<Contact> GetAll(string keyword);
    }
}
