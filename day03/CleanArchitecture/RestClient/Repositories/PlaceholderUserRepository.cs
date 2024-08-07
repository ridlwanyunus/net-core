using Application.Repositories;
using Domain.ValuesObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.Repositories
{
    public class PlaceholderUserRepository(RestClient _restClient) : IPlaceholderUserRepository
    {
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/";
        private const string path = "users";
        public async Task<List<PlaceholderUser>> GetAll()
        {
            return await _restClient.Get<List<PlaceholderUser>>(BaseUrl + path);
        }

        public async Task<PlaceholderUser> GetById(int Id)
        {
            return await _restClient.Get<PlaceholderUser>($"{BaseUrl}{path}/{Id}");
        }
    }
}
