using System;
using System.IO;
using System.Threading;

namespace QuanLySinhVien
{
    // Ghi log tự động mỗi lần mở/đóng kết nối DB và cảnh báo connection leak
    internal static class ConnectionLogger
    {
        private static readonly string _logDir = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "logs");

        private static string LogFile =>
            Path.Combine(_logDir, $"db_{DateTime.Now:yyyyMMdd}.log");

        // Số kết nối đang mở — nếu >= LEAK_THRESHOLD thì ghi cảnh báo
        private static int _activeCount = 0;
        private const int LEAK_THRESHOLD = 5;

        static ConnectionLogger()
        {
            try { Directory.CreateDirectory(_logDir); } catch { }
        }

        public static void LogOpen(DateTime openedAt, string callerClass)
        {
            try
            {
                int count = Interlocked.Increment(ref _activeCount);
                string line = $"[OPEN ] {openedAt:HH:mm:ss.fff} | caller={callerClass,-30} | active={count}";
                if (count >= LEAK_THRESHOLD)
                    line += $"  *** CANH BAO: {count} ket noi dang mo - co the bi connection leak! ***";
                Append(line);
            }
            catch { }
        }

        public static void LogClose(DateTime openedAt, string callerClass)
        {
            try
            {
                int count = Interlocked.Decrement(ref _activeCount);
                double ms = (DateTime.Now - openedAt).TotalMilliseconds;
                Append($"[CLOSE] {DateTime.Now:HH:mm:ss.fff} | caller={callerClass,-30} | duration={ms:F0}ms | active={count}");
            }
            catch { }
        }

        private static void Append(string line)
        {
            try { File.AppendAllText(LogFile, line + Environment.NewLine); }
            catch { }
        }
    }
}
