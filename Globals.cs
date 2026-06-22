namespace QuanLySinhVien
{
    internal static class Globals
    {
        public static string GlobalUserId { get; private set; }
        public static string GlobalUserName { get; private set; }
        public static int GlobalPosition { get; private set; }
        public static string GlobalEmail { get; private set; }

        public static void SetGlobalUserID(string id)
        {
            GlobalUserId = id;
        }

        public static void SetSession(string id, string name, int position, string email = null)
        {
            GlobalUserId = id;
            GlobalUserName = VietnameseTextHelper.Normalize(name);
            GlobalPosition = position;
            GlobalEmail = email ?? "";
        }

        public static void ClearSession()
        {
            GlobalUserId = null;
            GlobalUserName = null;
            GlobalPosition = 0;
            GlobalEmail = null;
        }
    }
}