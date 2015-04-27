using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace CabinTempArduino
{
    class E_post
    {
        string receiverMail;
        string mailSubject;
        string mailText;
        string programEmail = "IA2.3.2015@gmail.com";       // The progam's emailaddress 
        string programEmailPassword = "arduino2015";        // and emailpassword

        MailAddress to;                                     // mailaddresses, message and smtpclient  
        MailAddress from;                                   // objects initialized outside of methode 
        MailMessage message;                                // to prevent duplicates
        SmtpClient smtpclient;

        public E_post() { }

        public void Send(string emailReceiver, string emailTheme, string emailMessage)
        // Methode for sending email with recipient, theme/subject and message as parameters
        {
            receiverMail = emailReceiver;
            mailSubject = emailTheme;
            mailText = emailMessage;

            to = new MailAddress(receiverMail);             // Declaration of emailaddresses  
            from = new MailAddress(programEmail);           // and emailmessage
            message = new MailMessage(from, to);
            message.Subject = mailSubject;
            message.Body = mailText;

            smtpclient = new SmtpClient();                  // SMTP settings for Gmail
            smtpclient.Host = "smtp.gmail.com";
            smtpclient.Port = 587;
            smtpclient.EnableSsl = true;
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.UseDefaultCredentials = false;
            smtpclient.Credentials = new NetworkCredential(from.Address, programEmailPassword);

            smtpclient.Send(message);                       // Sends email
            smtpclient.Dispose();                           // Ends the SMTP connection to Gmail
        }
        #region Properties
        public string ReciverMail
        {
            get
            {
                return receiverMail;
            }
            set
            {
                ReciverMail = value;
            }
        }
        public string MailSubject
        {
            get
            {
                return mailSubject;
            }
            set
            {
                MailSubject = value;
            }
        }
        public string MailText
        {
            get
            {
                return mailText;
            }
            set
            {
                MailText = value;
            }
        }
        public string ProgramMail
        {
            get
            {
                return programEmail;
            }
            set
            {
                ProgramMail = value;
            }
        }
        public string ProgramMailPassword
        {
            get
            {
                return programEmailPassword;
            }
            set
            {
                ProgramMailPassword = value;
            }
        }
        #endregion
    }
}
