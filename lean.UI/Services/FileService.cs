using lean.UI.Helpers.Methods;
using lean.UI.Helpers.Models;
using lean.UI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Helpers;

namespace lean.UI.Services
{
    public class FileService
    {
        public FileService()
        {
            IOHelper.CreateDirectoryIfNotExist(MyConstants.UploadsPath.MapPath());
        }


        public FileDTO UploadFile(string path, HttpPostedFileBase file)
        {
            if (file == null)
                return null;

            IOHelper.CreateDirectoryIfNotExist(path.MapPath());

            WebImage compressedFile = new WebImage(file.InputStream);
            if (compressedFile.Width >= 1500 || compressedFile.Height >= 1500)
                compressedFile.Resize(compressedFile.Width.GetCompressValue(55), compressedFile.Height.GetCompressValue(55));

            var fileName = (Guid.NewGuid() + file.FileName).Replace(" ", "");
            var filePath = Path.Combine(path, fileName);
            compressedFile.Save(HttpContext.Current.Server.MapPath(filePath));
            return new FileDTO { Name = fileName, Path = filePath.Replace("~", "") };
        }

        public FileDTO UploadFile(string path, byte[] bytes, string fileName)
        {
            IOHelper.CreateDirectoryIfNotExist(path.MapPath());

            var filePath = Path.Combine(path, fileName);
            File.WriteAllBytes(HttpContext.Current.Server.MapPath(filePath), bytes);
            return new FileDTO { Name = fileName, Path = filePath.Replace("~", "") };
        }


        public List<FileDTO> UploadFiles(string path, HttpFileCollectionBase files)
        {
            var resFiles = new List<FileDTO>();
            for (int i = 0; i < files.Count; i++)
            {
                resFiles.Add(UploadFile(path, files[i]));
            }
            return resFiles;
        }

        public List<FileDTO> UploadFiles(string path, HttpPostedFileBase[] files)
        {
            if (files == null)
                return null;

            IOHelper.CreateDirectoryIfNotExist(path.MapPath());
            var resFiles = new List<FileDTO>();
            foreach (HttpPostedFileBase file in files)
            {
                resFiles.Add(UploadFile(path, file));
            }
            return resFiles;
        }

    }
}