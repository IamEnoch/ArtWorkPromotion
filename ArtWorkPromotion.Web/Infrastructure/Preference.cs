    public record Preference : IPreference
    {
        public bool IsDarkMode { get; set; } = false;
        public bool IsRTL { get; set; }
        public bool IsDrawerOpen { get; set; }
        public string? PrimaryColor { get; set; }
        public string LanguageCode { get; set; } =  "en-US";
    }
