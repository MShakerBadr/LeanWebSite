using System;
using System.IO;

namespace lean.UI.Helpers.Methods
{
    public static class IOHelper
    {
        public static string ReadFile(string path)
        {
            if (FileExists(path))
                return File.ReadAllText(path);
            else return string.Empty;
        }

        public static string ReadFileStream(string path)
        {
            if (FileExists(path))
            {
                StreamReader sr = new StreamReader(path.MapPath());
                return sr.ReadToEnd();
            }
            else return string.Empty;
        }

        public static void WriteToFile(string path, string content)
        {
            CreateFileIfNotExist(path);
            File.WriteAllText(path, content);
        }

        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public static void CreateDirectoryIfNotExist(string path)
        {
            try { if (!Directory.Exists(path)) Directory.CreateDirectory(path); } catch { }
        }

        public static void CreateFileIfNotExist(string path)
        {
            try { if (!File.Exists(path)) File.Create(path).Dispose(); } catch { }
        }

        public static void DeleteDirectoryIfExist(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    foreach (var file in Directory.GetFiles(path))
                    {
                        File.Delete(file);
                    }
                    Directory.Delete(path);
                }
            }
            catch { }
        }

        public static void DeleteDirectoryFiles(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    foreach (var file in Directory.GetFiles(path))
                    {
                        File.Delete(file);
                    }
                }
            }
            catch { }
        }

        public static void DeleteDirectoryChildrens(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    DirectoryInfo directory = new DirectoryInfo(path);
                    foreach (DirectoryInfo dir in directory.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    foreach (var file in Directory.GetFiles(path))
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("معلش");
            }
        }

        public static void DeleteFileIfExist(string path)
        {
            try { if (File.Exists(path)) File.Delete(path); } catch { }
        }
    }
}