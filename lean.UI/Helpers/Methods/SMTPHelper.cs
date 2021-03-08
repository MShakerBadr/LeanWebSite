
using lean.UI.Models.DTOs;

using System.Threading.Tasks;

namespace lean.UI.Helpers.Methods
{
    public class SMTPHelper
    {


        public static bool sendEmail(ContactUsInfoMail mailInfo)
        {

            //String filePath = "";
            //System.Net.Mail.Attachment data = null;
            //if (!string.IsNullOrWhiteSpace(mailInfo.attachmentPath))
            //{
            //    filePath = mailInfo.attachmentPath.Replace(@"\",@"/");
            //    data = new System.Net.Mail.Attachment(HostingEnvironment.MapPath(filePath), MediaTypeNames.Application.Octet);
            //}

            //MailAddress to = new MailAddress(mailInfo.ReceiverMail);
            //MailAddress from = new MailAddress(mailInfo.SenderMail);

            //MailMessage message = new MailMessage(from, to);
            //message.Subject = mailInfo.MailSubject;
            //message.Body = mailInfo.EmailBody;
            //message.IsBodyHtml = false;
            //if (!string.IsNullOrWhiteSpace(mailInfo.attachmentPath))
            //{
            //    message.Attachments.Add(data);
            //}

            //SmtpClient client = new SmtpClient("smtp.office365.com", 587)
            //{
            //    Timeout=1000000,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    Credentials = new NetworkCredential(mailInfo.SenderMail, mailInfo.Password),
            //    UseDefaultCredentials = false,
            //    TargetName="STARTTLS/smtp.office365.com",
            //};

            //try
            //{

            //    client.Send(message);
            //    return true;
            //}
            //catch (SmtpException ex)
            //{
            //    //Console.WriteLine(ex.ToString());
            //    return false;
            //}
            return false;

        }
        public static bool sendEmail_Gmail(ContactUsInfoMail mailInfo)
        {

            //String filePath = "";
            //System.Net.Mail.Attachment data = null;
            //if (!string.IsNullOrWhiteSpace(mailInfo.attachmentPath))
            //{
            //    filePath = mailInfo.attachmentPath.Replace(@"\", @"/");
            //    data = new Attachment(HostingEnvironment.MapPath(filePath), MediaTypeNames.Application.Octet);
            //}

            //MailAddress to = new MailAddress(mailInfo.ReceiverMail);
            //MailAddress from = new MailAddress(mailInfo.SenderMail);

            //MailMessage message = new MailMessage(from, to);
            //message.Subject = mailInfo.MailSubject;
            //message.Body = mailInfo.EmailBody;
            //message.IsBodyHtml = false;
            //if (!string.IsNullOrWhiteSpace(mailInfo.attachmentPath))
            //{
            //    message.Attachments.Add(data);
            //}

            //SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            //{

            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    EnableSsl = true,
            //    Credentials = new NetworkCredential(mailInfo.SenderMail, mailInfo.Password),

            //};

            //try
            //{

            //    client.Send(message);
            //    return true;
            //}
            //catch (SmtpException ex)
            //{
            //    //Console.WriteLine(ex.ToString());
            //    return false;
            //}

            return false;
        }



        public static async Task sendEmail_SendGrid(ContactUsInfoMail mailInfo)
        {

            //try
            //{
            //    var client = new  SendGrid.SendGridClient("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");
            //    var from = new EmailAddress(mailInfo.SenderMail);
            //    var to= new EmailAddress(mailInfo.ReceiverMail);


            //    var msg = MailHelper.CreateSingleEmail(from,to,mailInfo.MailSubject,mailInfo.EmailBody,"");

            //    String filePath = "";

            //    if (!string.IsNullOrWhiteSpace(mailInfo.attachmentPath))
            //    {
            //        filePath = mailInfo.attachmentPath.Replace(@"\", @"/");
            //        var data = new SendGrid.Helpers.Mail.Attachment()
            //        {
            //            Filename = HostingEnvironment.MapPath(filePath)
            //        };

            //        msg.AddAttachment( data);

            //    }


            //    var result =await client.SendEmailAsync(msg);



            //}
            //catch (SmtpException ex)
            //{
            //    //Console.WriteLine(ex.ToString());

            //}


        }

        public static bool sendEmail_MailKit(ContactUsInfoMail mailInfo)
        {
            //var mailMessage = new MimeMessage();
            //var builder = new BodyBuilder();

            //String filePath = "";
            //Attachment data = null;
            //if (!string.IsNullOrWhiteSpace(mailInfo.attachmentPath))
            //{
            //    filePath = mailInfo.attachmentPath.Replace(@"\", @"/");
            //    data = new Attachment(HostingEnvironment.MapPath(filePath), MediaTypeNames.Application.Octet);
            //    builder.Attachments.Add(HostingEnvironment.MapPath(filePath));
            //}
            //mailMessage.From.Add(new MailboxAddress("Sender", mailInfo.SenderMail));
            //mailMessage.To.Add(new MailboxAddress("Rec", mailInfo.ReceiverMail));
            //mailMessage.Subject = mailInfo.MailSubject;
            //builder.TextBody = mailInfo.EmailBody;

            //mailMessage.Body = builder.ToMessageBody();

            //try
            //{
            //    using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
            //    {
            //        smtpClient.ServerCertificateValidationCallback = (s, c, h, e) => true;
            //        smtpClient.CheckCertificateRevocation = false;
            //        smtpClient.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Ssl2 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12;
            //        //smtpClient.Connect("smtp.gmail.com", 465, options: SecureSocketOptions.StartTls);
            //        smtpClient.Connect("smtp.gmail.com", 587, false);
            //        smtpClient.Authenticate(mailInfo.SenderMail, mailInfo.Password);
            //        smtpClient.Send(mailMessage);
            //        smtpClient.Disconnect(true);
            //    }
            //    return true;
            //}
            //catch (SmtpException ex)
            //{
            //    //Console.WriteLine(ex.ToString());
            //    return false;
            //}
            return false;

        }

        public static async Task SendEmailAPI(ContactUsInfoMail mailinfo)
        {

            //string api = "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";
            //var client = new SendGrid.SendGridClient(api);
            //var from = new EmailAddress(mailinfo.SenderMail);
            //var to = new EmailAddress(mailinfo.ReceiverMail);


            //var msg = MailHelper.CreateSingleEmail(from, to, mailinfo.MailSubject, mailinfo.EmailBody, "");
            //var result= await client.SendEmailAsync(msg);

        }
        public static void MailGunAPI()
        {
            //    RestClient client = new RestClient();
            //    client.BaseUrl = new Uri("https://api.mailgun.net/v3/sandbox9d96813086284ffb8d07e63f57622862.mailgun.org"); 

            //client.Authenticator = new HttpBasicAuthenticator("api", "c696dfa261c7043e786d15e42436c9d1-e5da0167-3b787c4d");
            //    RestRequest request = new RestRequest();
            //    //request.AddParameter("domain", "YOUR_DOMAIN_NAME", ParameterType.UrlSegment);
            //    //request.Resource = "{domain}/messages";
            //    request.AddParameter("from", "mahmoud.shaker.2012@gmail.com");
            //    request.AddParameter("to", "mahmoud.shaker.2012@gmail.com");
            //    //request.AddParameter("to", "YOU@YOUR_DOMAIN_NAME");
            //    request.AddParameter("subject", "Hello");
            //    request.AddParameter("text", "Testing some Mailgun awesomness!");
            //    request.Method = Method.POST;
            //    var res = client.Execute(request);
            //    return res;

            // Compose a message
            //MimeMessage mail = new MimeMessage();
            //mail.From.Add(new MailboxAddress("Excited Admin", "mahmoud.shaker.2012@gmail.com"));
            //mail.To.Add(new MailboxAddress("Excited User", "mahmoud.shaker.2012@gmail.com"));
            //mail.Subject = "Hello";
            //mail.Body = new TextPart("plain")
            //{
            //    Text = @"Testing some Mailgun awesomesauce!",
            //};

            //// Send it!
            //using (var client = new  SmtpClient())
            //{
            //    // XXX - Should this be a little different?
            //    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            //    client.Connect("smtp.mailgun.org", 587, false);
            //    client.AuthenticationMechanisms.Remove("XOAUTH2");
            //    client.Authenticate("postmaster@YOUR_DOMAIN_NAME", "3kh9umujora5");

            //    client.Send(mail);
            //    client.Disconnect(true);
            //}

        }



        public static void SendEaMail(ContactUsInfoMail mailInfo)
        {

            //SmtpMail oMail = new SmtpMail("TryIT");
            //SmtpClient oSmtp = new SmtpClient();

            //// Set sender email address,
            //oMail.From = mailInfo.SenderMail;

            //// Set recipient email address, 
            //oMail.To = mailInfo.ReceiverMail;

            //// Set email subject
            //oMail.Subject = "test mail sub";// mailInfo.MailSubject;

            //// Set email body
            //oMail.TextBody = mailInfo.EmailBody;


            //// Do not set SMTP server address
            //SmtpServer oServer = new SmtpServer("");

            //try
            //{
            //    oSmtp.SendMail(oServer, oMail);
            //}
            //catch (Exception ep)
            //{

            //}
        }

        public static void SendMail(ContactUsInfoMail mailInfo)
        {
            //string receipientSMTP = new DnsHelper().GetSmtpServer("mahmoud.shaker.2012@gmail.com");

            //using (Smtp client = new Smtp())
            //{
            //    client.Connect(receipientSMTP, 25);
            //    IMail email = Fluent.Mail.Text("Hello")
            //        .From("mahmoud.shaker.2012@gmail.com")
            //        .To("mahmoud.shaker.2012@gmail.com")
            //        .Create();
            //    ISendMessageResult res= client.SendMessage(email);

            //    client.Close();
            //}
        }
    }
}