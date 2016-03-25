using System.Net.Mail;

namespace PardotAPI
{
    // -----------------------------------------------
    // --------- Adding Global Constants -------------
    // -----------------------------------------------

    public static class GlobalConstants
    {
        public static string pardotAPIUrl = "https://pi.pardot.com/api";
    }

    public static class GlobalMethods
    {
        public static void notifyAdmin(string message)
        {
            SmtpClient smtp = new SmtpClient();

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings.Get("PardotContactFrom"));
            mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings.Get("PardotContactTo"));
            mailMessage.Body = "<h1>The Pardot API has failed.</h1><br/><br/><strong>Error Message:</strong> " + message;
            mailMessage.Subject = "Pardot API Failure";
            mailMessage.IsBodyHtml = true;

            smtp.Send(mailMessage);
        }
    }

    // --------------------------------------------------
    // --------- Extending Base Class Types -------------
    // --------------------------------------------------

    public static class StringExtension
    {
        public static bool notFilled(this string str)
        {
            str = str.Trim();
            if (str != null && str.Length > 0 && str != " ")
            {
                return false;
            }
            return true;
        }
        public static bool isFilled(this string str)
        {
            str = str.Trim();
            if (str == null || str.Length == 0 || str == " ")
            {
                return false;
            }
            return true;
        }

    }
}