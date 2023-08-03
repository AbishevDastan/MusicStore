using Diploma.Domain;
using Diploma.DTO.User;
using System.Net.Http.Json;

namespace Diploma.Client.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseFromServer<string>> Login(AuthenticateUserDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/authentication/login", request);
            return await result.Content.ReadFromJsonAsync<ResponseFromServer<string>>();
        }

        public async Task<bool> IsAuthenticated()
        {
            var response = await _httpClient.GetAsync($"api/authentication/is-authenticated");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Something went wrong...");
                Console.WriteLine(await response.Content.ReadFromJsonAsync<bool>());
            }
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
