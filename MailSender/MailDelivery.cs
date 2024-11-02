using System;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;

namespace MailSender
{
    public class MailDelivery
    {
        public static void sendMail()
        {
            try
            {
                DateTime today = DateTime.Now;
                int hour = today.Hour;
                string saludo = string.Empty;
                if (hour > 0 && hour < 12)
                {
                    saludo = "Buenos dias a todos,";
                }
                else if (hour >= 12 && hour <= 19)
                {
                    saludo = "Buenas tardes a todos,";
                }
                else
                {
                    saludo = "Buenas noches a todos,";
                }


                string dateToday = today.ToString("MM/dd/yyyy");
                string hourToday = today.ToString("h:mm tt");
                // create email message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("abraham.resendiz@dayta.com.mx"));
                InternetAddressList ial = new InternetAddressList();
                ial.Add(MailboxAddress.Parse("abraham.resendiz@dayta.com.mx"));
                ial.Add(MailboxAddress.Parse("maribel.arguello@dayta.com.mx"));
                ial.Add(MailboxAddress.Parse("rafael.ibarra@dayta.com.mx"));
                ial.Add(MailboxAddress.Parse("fabiola.bustos@dayta.com.mx"));

                email.To.AddRange(ial);
                email.Subject = "Error de conexion - ApiPush";
                email.Body = new TextPart(TextFormat.Html) { Text = saludo + "<br><br>Se presento un error de conexi&oacute;n el dia " + dateToday + " a las " + hourToday + " en el ApiPush lo que ocasion&oacute; la baja del Socket. Favor de reiniciar el servicio. <br><br>Por su atenci&oacute;n, muchas gracias.<br>Saludos" };

                // send email
                var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("abraham.resendiz@dayta.com.mx", "Vn!6OXI*o26A");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error al tratar de enviar el correo: " + e.Message);
            }
        }
    }
}
