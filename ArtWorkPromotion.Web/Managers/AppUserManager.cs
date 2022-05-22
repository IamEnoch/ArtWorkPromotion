    
    public class AppUserManager : IUserManager
    {
        private readonly HttpClient _httpClient;

        public AppUserManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }