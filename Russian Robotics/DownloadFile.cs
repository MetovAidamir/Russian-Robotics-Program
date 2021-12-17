using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Russian_Robotics
{
    class DownloadFile
    {
        public string Download(string login,string password)
        {
            string FileName = "";
            using (var client = new ImapClient())
            {
                ServicePointManager
                    .ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;

                client.Connect("imap.mail.ru", 993, SecureSocketOptions.SslOnConnect);
                client.Authenticate(login, password);
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadWrite);
                
                bool isFind = false;
                int index = inbox.Count - 1;
                while (!isFind)
                {
                    var message = inbox.GetMessage(index);
                    foreach (var attachment in message.Attachments)
                    {
                        var mimePart = attachment as MimePart;
                        FileName = mimePart.FileName;
                        if (string.Compare(FileName.Substring(FileName.Length - 3), "csv") == 0)
                        {
                            using (var fileStream = new FileStream("C:/Users/mnvp/Desktop/Russin Robotics/"+ FileName, FileMode.Create, FileAccess.Write))
                            {
                                mimePart.Content.DecodeTo(fileStream);
                            }
                            isFind = true;
                        }
                        
                        break;
                    }
                    index--;
                } 
                client.Disconnect(true);
                return FileName;
            }
            
        }
    }
}
