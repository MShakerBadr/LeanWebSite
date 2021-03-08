using lean.UI.Models.Entities;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Net;

namespace lean.UI.Helpers.Methods
{
    public static class MySQLTransactions
    {
       public static bool InsertIntoContactUsRequest (ContactUsRequest mailinfo)
        {


            MySqlConnection connection = new MySqlConnection("Server=160.153.246.233;DataBase=theleanp_LDVRBS_DB;Uid=theleanplus;Password=P@ssw0rdFAWRY");

            string InsertQry = "INSERT INTO ContactUsRequests (Name,Email,MobileNumber,ContactUsReasonID,Message,RequestDate,ContactUsReasonTextEn,ContactUsReasonTextAr) " +
                                " Values(@Name,@Email,@MobileNumber,@ContactUsReasonID,@Message,@RequestDate,@ContactUsReasonTextEn,@ContactUsReasonTextAr)";

            MySqlCommand cmd = new MySqlCommand(InsertQry, connection);

            cmd.Parameters.AddWithValue("@Name", mailinfo.Name);
            cmd.Parameters.AddWithValue("@Email", mailinfo.Email);
            cmd.Parameters.AddWithValue("@MobileNumber", mailinfo.MobileNumber);
            cmd.Parameters.AddWithValue("@ContactUsReasonID", mailinfo.ContactUsReasonId);
            cmd.Parameters.AddWithValue("@Message", mailinfo.Message);
            cmd.Parameters.AddWithValue("@RequestDate", mailinfo.RequestDate);
            cmd.Parameters.AddWithValue("@ContactUsReasonTextEn", mailinfo.ContactUsReasonTextEn);
            cmd.Parameters.AddWithValue("@ContactUsReasonTextAr", mailinfo.ContactUsReasonTextAr);



            connection.Open();
            var rowsAdded= cmd.ExecuteNonQuery();
            connection.Close();
            if (rowsAdded > 0) 
                return true;
            return false;
        }


        public static bool InsertIntoJobRequest(JobRequest request)
        {


            MySqlConnection connection = new MySqlConnection("Server=160.153.246.233;DataBase=theleanp_LDVRBS_DB;Uid=theleanplus;Password=P@ssw0rdFAWRY");

            string InsertQry = "INSERT INTO JobRequest (Name,Email,MobileNumber,Job,AvilableJobId,CvUrl, Message,RequestDate) " +
                                " Values(@Name,@Email,@MobileNumber,@Job,@AvilableJobId,@CvUrl, @Message,@RequestDate)";

            MySqlCommand cmd = new MySqlCommand(InsertQry, connection);

            cmd.Parameters.AddWithValue("@Name", request.Name);
            cmd.Parameters.AddWithValue("@Email", request.Email);
            cmd.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
            cmd.Parameters.AddWithValue("@Job", request.Job);
            cmd.Parameters.AddWithValue("@AvilableJobId", request.AvilableJobId);
            cmd.Parameters.AddWithValue("@CvUrl", "~/LandUpload/"+ Path.GetFileName(request.CvUrl));
            cmd.Parameters.AddWithValue("@Message", request.Message);
            cmd.Parameters.AddWithValue("@RequestDate", request.RequestDate);


            connection.Open();
            var rowsAdded = cmd.ExecuteNonQuery();
            connection.Close();
            if (rowsAdded > 0)
            {
                UploadFileToFTP(request.CvUrl);
                return true;
            }
            return false;
        }


        private static void UploadFileToFTP(string filepath)
        {
            try
            {

                String sourcefilepath = filepath;                   // e.g. "d:/test.docx"
                String ftpurl = "ftp://theleanplus.live/" + Path.GetFileName(filepath);                  // e.g. ftp://serverip/foldername/foldername
                String ftpusername = "Ftpland@theleanplus.live";    // e.g. username
                String ftppassword = "~Em7wg25";                    // e.g. password


                //String sourcefilepath = filepath.MapPath();
                //String ftpurl = "theleanplus.live/landupload"; 
                //String ftpusername = "Ftpland@theleanplus.live"; 
                //String ftppassword = "~Em7wg25"; 



                //string filename = Path.GetFileName(sourcefilepath);
                //string ftpfullpath = "ftp://" + ftpurl + "/" + filename;
                //FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                //ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

                //ftp.KeepAlive = true;
                //ftp.UseBinary = true;
                //ftp.Method = WebRequestMethods.Ftp.UploadFile;

                //FileStream fs = File.OpenRead(sourcefilepath); // here, use sourcefilepath insted of source.
                //byte[] buffer = new byte[fs.Length];
                //fs.Read(buffer, 0, buffer.Length);
                //fs.Close();

                //Stream ftpstream = ftp.GetRequestStream();
                //ftpstream.Write(buffer, 0, buffer.Length);
                //ftpstream.Close();


                FtpWebRequest myFtpWebRequest;
                FtpWebResponse myFtpWebResponse;
                StreamWriter myStreamWriter;

                myFtpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://theleanplus.live/"+ Path.GetFileName(filepath));

                myFtpWebRequest.Credentials = new NetworkCredential(ftpusername,ftppassword);

                myFtpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
                myFtpWebRequest.UseBinary = true;

                myStreamWriter = new StreamWriter(myFtpWebRequest.GetRequestStream());
                myStreamWriter.Write(new StreamReader(filepath.MapPath()).ReadToEnd());
                myStreamWriter.Close();

                myFtpWebResponse = (FtpWebResponse)myFtpWebRequest.GetResponse();

                

                myFtpWebResponse.Close();
            }
            catch (WebException ex)
            {
                String status = ((FtpWebResponse)ex.Response).StatusDescription;
            }
        }
    }
}