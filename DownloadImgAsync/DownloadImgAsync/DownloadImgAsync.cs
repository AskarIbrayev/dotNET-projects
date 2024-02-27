using System.Net.Http;
using System;
namespace DownloadImgAsync;

public class DownloadImgAsync
{
    private HttpClient _httpClient = new HttpClient();
    public async Task DownloadImage(string url, string path)
    {
        try
        {
            using (_httpClient){
                var stream = await _httpClient.GetStreamAsync(url);
                using (var imgStream = File.Create(path))
                {
                    await stream.CopyToAsync(imgStream);
                }
            }
        }
        catch (Exception exeption)
        {
            Console.WriteLine(exeption.Message);
            throw;
        }
    }
}

