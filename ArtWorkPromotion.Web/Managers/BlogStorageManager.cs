 public class BlobStorageManager : IBlobStorageManager
    {
        private readonly HttpClient _httpClient;

        public BlobStorageManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }