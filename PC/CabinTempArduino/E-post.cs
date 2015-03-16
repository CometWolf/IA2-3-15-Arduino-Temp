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
        static string reciverMail;
        static string mailSubject;
        static string mailText;
        const string programMail = "IA2.3.2015@gmail.com";      // Programmets mailadresse - konstant 
        const string programMailPassword = "arduino2015";             // Prog. mail passord - konstant
        static bool mailSent = false;
        
        public E_post(string epostMottager, string epostTema, string epostMelding)
            // Classe konstruktør med parametere
        {
            reciverMail = epostMottager;
            mailSubject = epostTema;
            mailText = epostMelding;
        }
        
        public bool Send()                                      
            // Metode for å sende mail med mottageradresse, emne og hovedtekst som parametere
        {
            MailAddress to = new MailAddress(reciverMail);      // Mailadresse objekt for mottager
            MailAddress from = new MailAddress(programMail);          // Mailadresse objekt for avsender
            MailMessage message = new MailMessage(from, to);    // Mail objekt, men avsender og mottager som parametere
            message.Subject = mailSubject;                      // Legger inn tema i mailobjektet
            message.Body = mailText;                            // Legger inn hovedteksten i mailobjektet 

            SmtpClient smtpclient = new SmtpClient();           // SMTP innstillinger for Gmail
            smtpclient.Host = "smtp.gmail.com";
            smtpclient.Port = 587;
            smtpclient.EnableSsl = true;
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.UseDefaultCredentials = false;
            smtpclient.Credentials = new NetworkCredential(from.Address, programMailPassword);

            smtpclient.Send(message);                           // Sender mail
            smtpclient.Dispose();                               // Avslutter oppkoblingen mot Gmail
            return (mailSent = true);
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
                mailText = value;
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
    }
}
