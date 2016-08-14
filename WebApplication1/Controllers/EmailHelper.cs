﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebApplication1.Controllers
{
    public class EmailHelper
    {
        private const String ADMIN_GMAIL_EMAIL = "trananhkhoi1996@gmail.com";
        private const String ADMIN_GMAIL_EMAIL_PASSWORD = "5560020123aA";

        private static EmailHelper instance;
        public static EmailHelper getInstance()
        {
            if (instance == null)
            {
                instance = new EmailHelper();
            }
            return instance;
        }

        public void sendPasswordRecoveryMail(Models.DataClassesDataContext data, string sendToEmail)
        {
            string password = DataHelper.getInstance().getPasswordOfMemberAccount(data, sendToEmail);
            if (!password.Equals(""))
            {
                sendMail(data, ADMIN_GMAIL_EMAIL, ADMIN_GMAIL_EMAIL_PASSWORD, sendToEmail, "Password recovery",
                    "Recovering the password: " + password);
            }
        }

        public void sendMail(Models.DataClassesDataContext data, string sendFromEmail, string sendFromPassword, string sendToEmail, string subject, string messageBody)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587; // Gmail works on this port

            mail.From = new MailAddress(sendFromEmail);
            mail.To.Add(sendToEmail);
            mail.Subject = subject;
            mail.Body = messageBody;
            mail.Priority = MailPriority.High;
            smtpServer.UseDefaultCredentials = false;
            smtpServer.Credentials = new System.Net.NetworkCredential(sendFromEmail, sendFromPassword);
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
    }
}