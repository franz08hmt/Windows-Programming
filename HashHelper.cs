using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLySinhVien
{
    internal static class HashHelper
    {
        internal static string HashSHA256(string plaintext)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plaintext));
                var sb = new StringBuilder(64);
                foreach (byte b in bytes) sb.AppendFormat("{0:x2}", b);
                return sb.ToString();
            }
        }

        // SHA-256 hex strings are exactly 64 lowercase hex characters
        internal static bool IsHash(string stored)
            => stored != null && stored.Length == 64 && Regex.IsMatch(stored, "^[0-9a-f]{64}$");

        // Ẩn một phần email để bảo mật: abc@example.com → ab****@example.com
        internal static string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
                return email;

            int atIndex = email.IndexOf('@');
            string localPart = email.Substring(0, atIndex);
            string domain = email.Substring(atIndex); // Includes the @

            if (localPart.Length <= 2)
                return email; // Show full email if too short

            // Show first 2 characters + **** + domain
            return localPart.Substring(0, 2) + "****" + domain;
        }
    }
}
