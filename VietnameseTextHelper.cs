using System;
using System.Data;
using System.Text;

namespace QuanLySinhVien
{
    internal static class VietnameseTextHelper
    {
        private static readonly string[] MojibakeMarkers =
        {
            "Ã", "Â", "Ä", "Å", "Æ", "Ð", "Ø", "áº", "á»", "â€™", "â€œ", "â€", "�", "©"
        };

        public static string Normalize(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string best = input;
            int bestScore = ScoreTextQuality(input);

            foreach (int codePage in new[] { 1252, 28591 })
            {
                try
                {
                    string candidate = FixFromCodePage(input, codePage);
                    int score = ScoreTextQuality(candidate);
                    if (score > bestScore)
                    {
                        best = candidate;
                        bestScore = score;
                    }
                }
                catch
                {
                    // Ignore unsupported encodings on this machine.
                }
            }

            return best;
        }

        public static void NormalizeColumns(DataTable table, params string[] columns)
        {
            if (table == null || columns == null || columns.Length == 0)
            {
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                foreach (string column in columns)
                {
                    if (!table.Columns.Contains(column) || row[column] == DBNull.Value)
                    {
                        continue;
                    }

                    row[column] = Normalize(row[column].ToString());
                }
            }
        }

        private static string FixFromCodePage(string input, int codePage)
        {
            Encoding source = Encoding.GetEncoding(codePage);
            byte[] bytes = source.GetBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }

        private static int ScoreTextQuality(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            int score = 0;
            if (ContainsVietnameseDiacritics(text))
            {
                score += 20;
            }

            score -= CountMojibakeMarkers(text) * 8;

            foreach (char ch in text)
            {
                if (ch >= 0x0080 && ch <= 0x024F)
                {
                    score += 1;
                }
            }

            return score;
        }

        private static bool ContainsVietnameseDiacritics(string text)
        {
            foreach (char ch in text)
            {
                switch (ch)
                {
                    case 'à': case 'á': case 'ả': case 'ã': case 'ạ':
                    case 'ă': case 'ằ': case 'ắ': case 'ẳ': case 'ẵ': case 'ặ':
                    case 'â': case 'ầ': case 'ấ': case 'ẩ': case 'ẫ': case 'ậ':
                    case 'è': case 'é': case 'ẻ': case 'ẽ': case 'ẹ':
                    case 'ê': case 'ề': case 'ế': case 'ể': case 'ễ': case 'ệ':
                    case 'ì': case 'í': case 'ỉ': case 'ĩ': case 'ị':
                    case 'ò': case 'ó': case 'ỏ': case 'õ': case 'ọ':
                    case 'ô': case 'ồ': case 'ố': case 'ổ': case 'ỗ': case 'ộ':
                    case 'ơ': case 'ờ': case 'ớ': case 'ở': case 'ỡ': case 'ợ':
                    case 'ù': case 'ú': case 'ủ': case 'ũ': case 'ụ':
                    case 'ư': case 'ừ': case 'ứ': case 'ử': case 'ữ': case 'ự':
                    case 'ỳ': case 'ý': case 'ỷ': case 'ỹ': case 'ỵ':
                    case 'đ':
                    case 'À': case 'Á': case 'Ả': case 'Ã': case 'Ạ':
                    case 'Ă': case 'Ằ': case 'Ắ': case 'Ẳ': case 'Ẵ': case 'Ặ':
                    case 'Â': case 'Ầ': case 'Ấ': case 'Ẩ': case 'Ẫ': case 'Ậ':
                    case 'È': case 'É': case 'Ẻ': case 'Ẽ': case 'Ẹ':
                    case 'Ê': case 'Ề': case 'Ế': case 'Ể': case 'Ễ': case 'Ệ':
                    case 'Ì': case 'Í': case 'Ỉ': case 'Ĩ': case 'Ị':
                    case 'Ò': case 'Ó': case 'Ỏ': case 'Õ': case 'Ọ':
                    case 'Ô': case 'Ồ': case 'Ố': case 'Ổ': case 'Ỗ': case 'Ộ':
                    case 'Ơ': case 'Ờ': case 'Ớ': case 'Ở': case 'Ỡ': case 'Ợ':
                    case 'Ù': case 'Ú': case 'Ủ': case 'Ũ': case 'Ụ':
                    case 'Ư': case 'Ừ': case 'Ứ': case 'Ử': case 'Ữ': case 'Ự':
                    case 'Ỳ': case 'Ý': case 'Ỷ': case 'Ỹ': case 'Ỵ':
                    case 'Đ':
                        return true;
                }
            }

            return false;
        }

        private static int CountMojibakeMarkers(string text)
        {
            int count = 0;
            foreach (string marker in MojibakeMarkers)
            {
                int index = 0;
                while ((index = text.IndexOf(marker, index, StringComparison.Ordinal)) >= 0)
                {
                    count++;
                    index += marker.Length;
                }
            }

            return count;
        }
    }
}
