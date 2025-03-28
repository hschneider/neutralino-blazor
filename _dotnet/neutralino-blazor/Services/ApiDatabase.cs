
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;
using neutralino_blazor.Models;

namespace neutralino_blazor.Services

{
    public class ApiDatabase
    {
        private readonly string _auth = "Bearer XXX.XXX";
        private readonly string _url = "https://192.168.0.20:3001";
        private readonly HttpClient _httpClient;

        public ApiDatabase()
        {
            _httpClient = new HttpClient();
        }
        
        public void PrepareAuth()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", _auth);
        }
    }
}
