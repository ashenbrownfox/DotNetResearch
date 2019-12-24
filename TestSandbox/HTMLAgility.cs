using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace TestSandbox
{
    public class HTMLAgility
    {
        public List<String> ParseTags(string url)
        {
            var html = @url;
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var imgNode = htmlDoc.DocumentNode.SelectNodes("//img");

            var imageCollections = new List<string>();
            foreach (var n in imgNode)
            {
                if (validURL(n.OuterHtml)) {
                    imageCollections.Add(n.OuterHtml);
                } 
                
            }
            foreach (var item in imageCollections)
            {
                Console.WriteLine(item);
            }
            return imageCollections;
        }
        public Boolean validURL(string imgSrc)
        {
            if (imgSrc.StartsWith('/') || imgSrc.StartsWith('.'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
