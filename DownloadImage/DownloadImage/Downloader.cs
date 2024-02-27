using System.IO;
using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;


namespace DownloadImage;
public class Downloader
{
    private readonly HttpClient _httpClient = new HttpClient();
    private string URL = "https://jsonplaceholder.typicode.com/photos";
    private List<string> imageUrls = new List<string>();
    private int numberOfThreads = 10;
    private int numberOfImagesForOneThread;
    private int numberOfRemainderImages = 0;

    private void ParseImageUrl()
    {
        try
        {
            string json = _httpClient.GetStringAsync(URL).Result;
            JArray jsonArray = JArray.Parse(json);
            foreach (var obj in jsonArray)
            {
                imageUrls.Add(obj["thumbnailUrl"].ToString());
            }
        }
        catch (System.Exception exeption)
        {
            Console.WriteLine(exeption.Message);
            throw;
        }

    }
    public void DownloadAllImages()
    {
        ParseImageUrl();
        numberOfImagesForOneThread = imageUrls.Count / numberOfThreads;
        numberOfRemainderImages = imageUrls.Count % numberOfThreads;

        var indicesOfThreads = new List<int>();
        for (int i = 0; i < numberOfThreads; i++)
        {
            indicesOfThreads.Add(i);
        }
        foreach (var threadIndex in indicesOfThreads)
        {
            var thread = new Thread(() => DownloadForOneThread(threadIndex));
            thread.Name = $"thread-{threadIndex}";
            thread.Start();
        }
    }
    private void DownloadForOneThread(int threadIndex)
    {
        if (numberOfRemainderImages != 0 && threadIndex == numberOfThreads - 1)
        {
            for (int j = (imageUrls.Count - numberOfRemainderImages); j < imageUrls.Count; j++)
            {
                DownloadImage(imageUrls[j], j + 1);
            }
        }
        else
        {
            for (int j = (numberOfImagesForOneThread * threadIndex); j < numberOfImagesForOneThread * (threadIndex + 1); j++)
            {
                DownloadImage(imageUrls[j], j + 1);
            }
        }
    }
    private void DownloadImage(string url, int indexForNaming)
    {
        string imageName = indexForNaming + "-by-" + Thread.CurrentThread.Name + ".jpeg";
        try
        {
            using (var stream = _httpClient.GetStreamAsync(url).Result)
            using (var imageStream = File.Create("DownloadedImages/" + imageName))
            {
                stream.CopyTo(imageStream);
            }
            Thread.Sleep(100);
        }
        catch (System.Exception exeption)
        {
            Console.WriteLine($"{imageName} download error: {exeption.Message}");
            throw;
        }

    }
}