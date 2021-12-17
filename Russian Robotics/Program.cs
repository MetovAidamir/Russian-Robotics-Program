using Consul;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;
using System;
using System.IO;
using System.Net;

namespace Russian_Robotics
{
    class Program
    {
        static void Main(string[] args)
        {
            DownloadFile download = new DownloadFile();
            UploadToDatabase uploadToDatabase = new UploadToDatabase();
            string login, pass,fileName;

            Console.WriteLine("Enter your login");
            login=Console.ReadLine();
            Console.WriteLine("Enter your password");
            pass = Console.ReadLine();
            fileName= download.Download(login, pass);
            uploadToDatabase.Upload(fileName);
            Console.WriteLine("Done");
        }
    }
}
