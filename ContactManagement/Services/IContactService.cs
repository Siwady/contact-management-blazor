using ContactManagement.Data.Models;
namespace ContactManagement.Services
{
    public interface IContactService
    {
        Task<List<ContactModel>> GetAll();
        Task<ContactModel> Get(int id);
        Task<ContactModel> Create(ContactModel contact);
        Task<ContactModel> Update(ContactModel contact);
        Task<ContactModel> Delete(int id);
       
    }
}
