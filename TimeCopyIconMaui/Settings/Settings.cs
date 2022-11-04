using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TimeCopyIconMaui.Settings
{
    public class Settings
    {
        [JsonPropertyName("TOTP")]
        public NestedSettings TOTP { get; set; } = null!;
    }

    public class NestedSettings
    {
        public string Secret { get; set; } = null!;
        public string Algorithm { get; set; } = "SHA1";
        public int Digits { get; set; } = 6;
        public int Period { get; set; } = 30;
        public string Issuer { get; set; } = null!;
        public string Account { get; set; } = null!;
 }

}
