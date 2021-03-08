namespace lean.UI.Helpers.Models
{
    public class MySession
    {
        #region culture
        public static string Culture { get; set; }
        public static string xCulture { get; set; }
        public static bool IsRTL { get; set; }
        public static bool IsArabic { get; set; }
        #endregion

        #region session info
        public static SessionUser User { get; set; } = new SessionUser();
        #endregion
    }

    /// <summary>
    /// Only used for serialization
    /// </summary>
    public class SessionInfo
    {
        public SessionUser User { get; set; }
    }

    public class SessionUser
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public int Role { get; set; }
    }
}