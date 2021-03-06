﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DoormatWebSite.Tools
{
    public static class Mail
    {


        public static string SendEmail(string toAddress, string fromAddress,
                      string subject, string message)
        {
            
            try
            {
                using (var mail = new MailMessage())
                {
                    const string email = "info@padari.ir";
                    const string password = "2121402039";

                    var loginInfo = new NetworkCredential(email, password);


                    mail.From = new MailAddress(fromAddress);
                    mail.To.Add(new MailAddress(toAddress));
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;

                    try
                    {
                        using (var smtpClient = new SmtpClient(
                                                         "mail.padari.ir", 587))
                        {
                            smtpClient.EnableSsl = false;
                            smtpClient.UseDefaultCredentials = true;
                            smtpClient.Credentials = loginInfo;
                            smtpClient.Send(mail);
                        }

                    }

                    finally
                    {
                        //dispose the client
                        mail.Dispose();
                    }

                }

                return ("Your message has been successfully sent ");
            }
            catch (SmtpFailedRecipientsException ex)
            {
                foreach (SmtpFailedRecipientException t in ex.InnerExceptions)
                {
                    var status = t.StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        return ("Delivery failed - retrying in 5 seconds.");
                        System.Threading.Thread.Sleep(5000);
                        //resend
                        //smtpClient.Send(message);
                    }
                    else
                    {
                        return string.Format("Failed to deliver message to {0}",
                                          t.FailedRecipient);
                    }
                }
            }
            catch (SmtpException Se)
            {
                // handle exception here
              return  string.Format(Se.ToString());
            }

            catch (Exception ex)
            {
               return string.Format(ex.ToString());
            }

            return null;
        }
    }
}