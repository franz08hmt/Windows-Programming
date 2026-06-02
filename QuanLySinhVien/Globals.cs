namespace QuanLySinhVien
{
    internal static class Globals
    {
        public static string GlobalUserId { get; private set; }
        public static string GlobalUserName { get; private set; }
        public static int GlobalPosition { get; private set; }

        public static void SetGlobalUserID(string id)
        {
            GlobalUserId = id;
        }

        public static void SetSession(string id, string name, int position)
        {
            GlobalUserId = id;
            GlobalUserName = name;
            GlobalPosition = position;
        }

        public static void ClearSession()
        {
            GlobalUserId = null;
            GlobalUserName = null;
            GlobalPosition = 0;
        }
    }
}