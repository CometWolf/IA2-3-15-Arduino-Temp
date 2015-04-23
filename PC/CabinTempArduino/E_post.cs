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
        string reciverMail;
        string mailSubject;
        string mailText;
        string programMail = "IA2.3.2015@gmail.com";      // Prog. mailadresse - konstant 
        string programMailPassword = "arduino2015";       // Prog. mail passord - konstant

        MailAddress to;
        MailAddress from;
        MailMessage message;
        SmtpClient smtpclient;

        public void Send(string emailReciver, string emailTheme, string emailMessage)                                      
            // Metode for å sende mail med mottageradresse, emne og hovedtekst som parametere
        {
            reciverMail = emailReciver;
            mailSubject = emailTheme;
            mailText = emailMessage;

            to = new MailAddress(reciverMail);                  // Mailadresse objekt for mottager
            from = new MailAddress(programMail);                // Mailadresse objekt for avsender
            message = new MailMessage(from, to);                // Mail objekt, med avsender og mottager som parametere
            message.Subject = mailSubject;                      // Legger inn tema i mailobjektet
            message.Body = mailText;                            // Legger inn hovedteksten i mailobjektet 

            smtpclient = new SmtpClient();                      // SMTP innstillinger for Gmail
            smtpclient.Host = "smtp.gmail.com";
            smtpclient.Port = 587;
            smtpclient.EnableSsl = true;
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.UseDefaultCredentials = false;
            smtpclient.Credentials = new NetworkCredential(from.Address, programMailPassword);

            smtpclient.Send(message);                           // Sender mail
            smtpclient.Dispose();                               // Avslutter oppkoblingen mot Gmail
        }
        public string ReciverMail
        {
            get
            {
                return reciverMail;
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
                return programMail;
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
                return programMailPassword;
            }
            set
            {
                ProgramMailPassword = value;
            }
        }
        public bool MailSent
        {
            get
            {
                return mailSent;
            }
            set
            {
                MailSent = value;
            }
        }
    }
}
