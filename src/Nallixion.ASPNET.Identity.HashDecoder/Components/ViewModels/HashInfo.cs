namespace Nallixion.ASPNET.Identity.HashDecoder.Components.ViewModels {
    public class HashInfo {
        public string PasswordHash { get; set; } = string.Empty;
        public string ShaType { get; set; } = string.Empty;

        public string HashcatFormat { get; set; } = string.Empty;

        public string SubKey { get; set; } = string.Empty;

        public string Salt { get; set; } = string.Empty;

        public int SaltLength { get; set; }

        public int IterCount { get; set; }

        public string HexSubKey { get; set; } = string.Empty;

        public string HexSalt { get; set; } = string.Empty;

        public string HexSaltLength { get; set; } = string.Empty;

        public string HexIterCount { get; set; } = string.Empty;

        public string HexPrf { get; set; } = string.Empty;

        public string HashVersion { get; set; } = string.Empty;
        public string HexHash { get; set; } = string.Empty;
        public string Hash { get; set; } = string.Empty;
    }
}
