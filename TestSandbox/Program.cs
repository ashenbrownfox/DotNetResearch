using System;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;

namespace TestSandbox
{
    class Program
    {
        public static void Main(string[] args)
        {
            //<img src='https://www.creativeshrimp.com/wp-content/uploads/2015/11/SPORTFUCK.jpg' alt='sport'/>
            ParseTags("https://www.creativeshrimp.com/top-30-artworks-of-beeple.html").Wait();

        }

        public static async Task ParseTags(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# program");
            var content = await client.GetStringAsync(url);

            //Use the default configuration for AngleSharp
            var config = Configuration.Default;
            //Create a new context for evaluating webpages with the given config
            var context = BrowsingContext.New(config);

            //Create a virtual request to specify the document to load (here from our fixed string)
            var document = await context.OpenAsync(req => req.Content(content));

            //Do something with document like the following
            Console.WriteLine("Serializing the (original) document:");
            string html = document.DocumentElement.OuterHtml;
            Console.WriteLine(html);



            Console.WriteLine("Now searching for all imagetags");
            var imageTags = document.QuerySelectorAll("img");

            foreach(var img in imageTags)
            {
                var imgsrc = img.GetAttribute("src");
                var p = document.CreateElement("img");
                p.SetAttribute("src", imgsrc);
                document.Body.AppendChild(p);
                Console.WriteLine("Added " +src);
            }
        }

    }
}
