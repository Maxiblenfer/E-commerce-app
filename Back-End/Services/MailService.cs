using Back_End.IServices;
using Back_End.Models;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Net;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;
namespace Back_End.Utils
{
    public class MailService:IMailService
    {
        readonly static private string emailfrom = "ecommercec765@gmail.com";
        readonly static private string password = "xyghtytxemyafotc";
        public void SendEmailAutorization(User user, string url)
        {
            
            
            
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailfrom, password)


                };
                var email = new MailMessage(emailfrom, user.email);
                email.Subject = "Activate your account";
                email.Body = $"<p>Hello {user.names} {user.lastnames}! thank you for creating an account with us, now the next step is activating your account. <br>  Please enter to this link to activate it: </p> <a href='http://localhost:4200/welcome/activate/{url}'>http://localhost:4200/welcome/activate/{url}</a>";
                email.IsBodyHtml = true;
               
                    client.Send(email);
                

                
            }
            catch (Exception)
            {

              

            }
        }

        public void SendEmailForgotAutorization(User user, string url)
        {



            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailfrom, password)


                };
                var email = new MailMessage(emailfrom, user.email);
                email.Subject = "Activate your account";
                email.Body = $"<p>Hello {user.names} {user.lastnames}! As you forgot your credentials to activate your account, we are going to send it again. <br>  Please enter to this link to activate it: </p> <a href='http://localhost:4200/welcome/activate/{url}'>http://localhost:4200/welcome/activate/{url}</a>";
                email.IsBodyHtml = true;

                client.Send(email);



            }
            catch (Exception)
            {



            }
        }
    }
}
