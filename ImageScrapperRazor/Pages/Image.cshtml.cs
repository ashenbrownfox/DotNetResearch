using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace ImageScrapperRazor.Pages
{
    public class ImageModel : PageModel
    {
        private static readonly HttpClient client = new HttpClient();

        public string Message { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            string url = Request.Form["url"];
            Message = "POST used " + url;
            //scrapImagesAsync(url).Wait();
        }
        public async Task scrapImagesAsync(string url)
        {
            var values = new Dictionary<string, string>
            {
            { "thing1", "hello" },
            { "thing2", "world" }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}