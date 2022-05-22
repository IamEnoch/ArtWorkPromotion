  public class ArtManager : IArtManager
    {
        private readonly HttpClient _httpClient;

        public ArtManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }