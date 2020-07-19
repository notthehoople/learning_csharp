using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Sync downloading");
            DownloadHtml("https://docs.microsoft.com");
            Console.WriteLine("Sync downloading...Done");
            System.Threading.Thread.Sleep(3000);

            Console.WriteLine("Async downloading");
            DownloadHtmlAsync("https://docs.microsoft.com");
            Console.WriteLine("Async downloading...Done");
            System.Threading.Thread.Sleep(3000);                // Keeps the console available for the last Console.WriteLine

        }

        public static void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"/tmp/result.html"))
            {
                streamWriter.Write(html);
                Console.WriteLine("Sync write done");
            }
        }

        public static async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"/tmp/result.html"))
            {
                await streamWriter.WriteAsync(html);
                Console.WriteLine("Async write done");
            }
        }
    }
}
