using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLySinhVien
{
    public static class TotpHelper
    {
        private const string B32 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        public static string GenerateSecret()
        {
            var b = new byte[20];
            using (var rng = new RNGCryptoServiceProvider()) rng.GetBytes(b);
            return ToBase32(b);
        }

        // Verify with ±1 window for clock drift
        public static bool Verify(string secret, string code)
        {
            if (string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(code)) return false;
            long t = DateTimeOffset.UtcNow.ToUnixTimeSeconds() / 30;
            for (long i = t - 1; i <= t + 1; i++)
                if (Compute(secret, i) == code.Trim()) return true;
            return false;
        }

        // Returns QR code image URL (api.qrserver.com — Google Charts was deprecated)
        public static string GetQrUrl(string secret, string accountLabel, string issuer = "HCMUTE")
        {
            string uri = $"otpauth://totp/{Uri.EscapeDataString(issuer + ":" + accountLabel)}" +
                         $"?secret={secret}&issuer={Uri.EscapeDataString(issuer)}&digits=6&period=30";
            return "https://api.qrserver.com/v1/create-qr-code/?size=220x220&format=png&data=" +
                   Uri.EscapeDataString(uri);
        }

        private static string Compute(string secret, long counter)
        {
            byte[] key = FromBase32(secret);
            byte[] msg = BitConverter.GetBytes(counter);
            if (BitConverter.IsLittleEndian) Array.Reverse(msg);
            using (var hmac = new HMACSHA1(key))
            {
                byte[] h = hmac.ComputeHash(msg);
                int off = h[19] & 0x0F;
                int code = ((h[off] & 0x7F) << 24) | ((h[off + 1] & 0xFF) << 16) |
                           ((h[off + 2] & 0xFF) << 8) | (h[off + 3] & 0xFF);
                return (code % 1_000_000).ToString("D6");
            }
        }

        private static string ToBase32(byte[] data)
        {
            var sb = new StringBuilder();
            int buf = 0, bits = 0;
            foreach (byte b in data)
            {
                buf = (buf << 8) | b; bits += 8;
                while (bits >= 5) { bits -= 5; sb.Append(B32[(buf >> bits) & 31]); }
            }
            if (bits > 0) sb.Append(B32[(buf << (5 - bits)) & 31]);
            return sb.ToString();
        }

        private static byte[] FromBase32(string s)
        {
            s = s.ToUpperInvariant().TrimEnd('=');
            var result = new byte[s.Length * 5 / 8];
            int buf = 0, bits = 0, idx = 0;
            foreach (char c in s)
            {
                int v = B32.IndexOf(c);
                if (v < 0) continue;
                buf = (buf << 5) | v; bits += 5;
                if (bits >= 8) { bits -= 8; result[idx++] = (byte)(buf >> bits); }
            }
            return result;
        }
    }
}
