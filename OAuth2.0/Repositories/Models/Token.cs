using System;
using System.Collections.Generic;

namespace OAuth2._0.Repositories.Models
{
    public partial class Token
    {
        public int Id { get; set; }
        public string Source { get; set; } = null!;
        public string? TokenType { get; set; }
        public string AccessToken { get; set; } = null!;
        public long? ExpiresIn { get; set; }
        public long? ExpiresOn { get; set; }
        public string? RefreshToken { get; set; }
        public long? RefreshTokenExpiresIn { get; set; }
        public string? Resource { get; set; }
        public string? ProfileInfo { get; set; }
        public string? Scope { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public bool Active { get; set; }
    }
}
