using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lean.UI.Models.DTOs
{
    public class ContactUsInfoMail
    {
        public string MailSubject { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MailType { get; set; }
        public string EmailBody { get; set; }
        public DateTime MailDate { get; set; }
        public string attachmentPath { get; set; }


        public string SenderMail { get; set; }

        [Required]
        public string ReceiverMail { get; set; }

        public string Password { get; set; }

    }
}