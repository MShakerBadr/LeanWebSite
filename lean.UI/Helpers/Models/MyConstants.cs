using System.IO;

namespace lean.UI.Helpers.Models
{
    public static class MyConstants
    {
        public static int PageSize10 => 10;
        public static int PageSize25 => 25;

        #region cookies
        public static string ArabicLanguage => "ar-EG";
        public static string EnglishLanguage => "en-US";
        public static string DefaultLanguage => EnglishLanguage;
        public static string CultureCookieName => "SysLanguage";
        public static string CurrrentLanguage { get; set; } = EnglishLanguage;
        #endregion

        #region sessions
        public static string SessionInfoName => "SessionInfo";
        #endregion

        #region files
        public static string Root => "~/";
        public static string AssetsRootPath => Path.Combine(Root, "Assets");

        public static string UploadsPath => Path.Combine(Root, "Uploads");
        #endregion

        #region seed
        public static string SeedRootPath => Path.Combine(AssetsRootPath, "seed");
        #endregion

        #region DefaultImage
        public static string DefaultImage => "/Assets/imgs/default-photo-square.png";
        #endregion

    }
}
