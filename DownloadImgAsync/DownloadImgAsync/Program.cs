using System;

namespace DownloadImgAsync
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var imageUrl = "https://images.freeimages.com/images/previews/ac9/railway-hdr-1361893.jpg";
            var imageSavePath = "Image/image.jpeg";
            var AsyncDownloader = new DownloadImgAsync();
            await AsyncDownloader.DownloadImage(imageUrl, imageSavePath);
        }
    }
}