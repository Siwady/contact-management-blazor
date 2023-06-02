using ContactManagement.Data.Models;
using System.Net.Http.Json;

namespace ContactManagement.Services
{
    public class ContactService : IContactService
    {
        private HttpClient _httpClient;
        public ContactService(HttpClient httpClient) 
        {
            _httpClient = httpClient;    
        }

        public async Task<List<ContactModel>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ContactModel>>("api/Contact");

            if (result == null)
            {
                throw new Exception("Something failed when trying to fetch Contacts!!");
            } 
            else 
            { 
                return result; 
            }  
        }

        public async Task<ContactModel> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ContactModel>($"api/Contact/{id}");

            if (result == null)
            {
                throw new Exception("Something failed when trying to fetch Contact!!");
            }
            else
            {
                return result;
            }
        }

        public async Task<ContactModel> Create(ContactModel contact)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/Contact", contact);
            var response = await result.Content.ReadFromJsonAsync<ContactModel>();

            if (response == null)
            {
                throw new Exception("Something failed when trying to create Contact!!");
            }
            else
            {
                return response;
            }
        }

        public async Task<ContactModel> Update(ContactModel contact)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Contact/{contact.Id}", contact);
            var response = await result.Content.ReadFromJsonAsync<ContactModel>();

            if (response == null)
            {
                throw new Exception("Something failed when trying to update Contact!!");
            }
            else
            {
                return response;
            }
        }

        public async Task<ContactModel> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Contact/{id}");
            var response = await result.Content.ReadFromJsonAsync<ContactModel>();

            if (response == null)
            {
                throw new Exception("Something failed when trying to delete Contact!!");
            }
            else
            {
                return response;
            }
        }
    }
}
