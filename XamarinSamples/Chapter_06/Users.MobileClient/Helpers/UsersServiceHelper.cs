using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Users.MobileClient.Models;

namespace Users.MobileClient.Helpers
{
    public static class UsersServiceHelper
    {
        private static readonly HttpClient httpClient;

        static UsersServiceHelper()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://jsonplaceholder.typicode.com/users/")
            };
        }

        public static async Task<IEnumerable<User>> Get()
        {
        	var response = await httpClient.GetAsync(string.Empty);

            CheckStatusCode(response.StatusCode);

            var jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<User>>(jsonString);
        }

        public static async Task Delete(int userId)
        {
            var response = await httpClient.DeleteAsync($"{userId}");

            CheckStatusCode(response.StatusCode);
        }

        public static async Task Update(User user)
        {
            var userJson = JsonConvert.SerializeObject(user);

            var response = await httpClient.PutAsync($"{user.Id}", 
                new StringContent(userJson));

            CheckStatusCode(response.StatusCode);
        }

        public static async Task<User> Get(int userId)
        {
            var response = await httpClient.GetAsync($"{userId}");

            CheckStatusCode(response.StatusCode);

            var jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<User>(jsonString);
        }

        private static void CheckStatusCode(HttpStatusCode statusCode)
        {
            if(statusCode != HttpStatusCode.OK)
            {
        		throw new Exception($"Unexpected status code: {statusCode}");
        	}
        }
    }
}
