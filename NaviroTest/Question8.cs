using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NaviroTest
{
    public class Question8
    {
        List<string> _urlList = new List<string>();
        List<string> _validUrls = new List<string>();
        List<string> _invalidUrls = new List<string>();
        HtmlDocument _htmlDoc = null;

        public List<string> ValidUrls
        {
            get { return _validUrls; }
            private set { }
        }

        public List<string> InvalidUrls
        {
            get { return _invalidUrls; }
            private set { }
        }

        /// Load the html snippet from the txt file
        private void LoadHtmlFile(string fileName)
        {
            TextReader reader = File.OpenText(fileName);
            _htmlDoc = new HtmlDocument();
            _htmlDoc.Load(reader);
            reader.Close();
        }

        // Extract all anchor tags using HtmlAgilityPack
        public List<string> ExtractAllAHrefTags(string fileName)
        {
            LoadHtmlFile(fileName);
            foreach (HtmlNode link in _htmlDoc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                _urlList.Add(att.Value);
            }

            _urlList = _urlList.Distinct().ToList();
            return _urlList;
        }

        public async Task CheckLinks()
        {
            if (_htmlDoc == null)
            {
                throw new NullReferenceException("HTML document is null");
            }

            // Instantiate the CancellationTokenSource.
            var cts = new CancellationTokenSource();

            try
            {
                await AccessTheWebAsync(cts.Token);
                Console.WriteLine("\r\nLink check complete");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\r\nLink check FAILED!!!");
            }

            cts = null;
        }

        async Task AccessTheWebAsync(CancellationToken ct)
        {
            HttpClient client = new HttpClient();

            // ***Create a query that, when executed, returns a collection of tasks.
            IEnumerable<Task<int>> downloadTasksQuery =
                from url in _urlList select ProcessURL(url, client, ct);

            // ***Use ToList to execute the query and start the tasks.
            List<Task<int>> downloadTasks = downloadTasksQuery.ToList();

            // ***Add a loop to process the tasks one at a time until none remain.
            while (downloadTasks.Count > 0)
            {
                // Identify the first task that completes.
                Task<int> firstFinishedTask = await Task.WhenAny(downloadTasks);

                // ***Remove the selected task from the list so that you don't
                // process it more than once.
                downloadTasks.Remove(firstFinishedTask);
                Console.WriteLine("Completed task : " + firstFinishedTask.Id.ToString());

                try
                {
                    // Await the completed task.
                    int length = await firstFinishedTask;
                }
                catch(Exception ex)
                {

                }
            }
        }

        async Task<int> ProcessURL(string url, HttpClient client, CancellationToken ct)
        {
            Console.WriteLine("Process url : " + url);
            try
            {
                // GetAsync returns a Task<HttpResponseMessage>.
                using (HttpResponseMessage response = await client.GetAsync(url, ct))
                {
                    Console.WriteLine("Waiting for response : ", url);
                    // Retrieve the website contents from the HttpResponseMessage.
                    if (response.StatusCode == HttpStatusCode.OK)
                        _validUrls.Add(url);
                    else
                        _invalidUrls.Add(url);
                    Console.WriteLine("Waiting for response SUCCESS : ", url);
                }   
            }
            catch(Exception ex)
            {
                _invalidUrls.Add(url);
                Console.WriteLine(url + ":" + ex.Message);
            }
            
            return 1;
        }
    }
}
