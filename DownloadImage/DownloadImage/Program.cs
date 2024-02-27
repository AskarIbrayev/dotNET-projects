using System.Net.Http;
using System;
using Newtonsoft.Json.Linq;
namespace DownloadImage {
    internal class Program
    {
        static void Main(string[] args)
        {
            var Downloader = new Downloader();
            Downloader.DownloadAllImages();
        }
    }

}