﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Text;  // for class Encoding
using System.IO; 
using AngleSharp;

namespace TestSandbox
{
    class Program
    {
        public static void Main(string[] args)
        {
            var SampleLink = "https://www.creativeshrimp.com/top-30-artworks-of-beeple.html";
            //ParseTagsASync(SampleLink).Wait();
            HTMLAgility ha = new HTMLAgility();
            ha.ParseTags(SampleLink);
        }

        //http client
        public static async Task<List<string>> ParseTagsASync(string url)
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
            var imageCollections = new List<string>();
            foreach(var img in imageTags)
            {
                var imgsrc = img.GetAttribute("src");
                var p = document.CreateElement("img");
                p.SetAttribute("src", imgsrc);
                document.Body.AppendChild(p);
                imageCollections.Add(img.OuterHtml);
                Console.WriteLine("Added " +imgsrc);
            }
            Console.WriteLine("Now the collcetion");
            foreach(var i in imageCollections)
            {
                Console.WriteLine(i);
            }
            return imageCollections;
        }

    }
}
