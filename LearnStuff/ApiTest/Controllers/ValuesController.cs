using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Net.Http.Headers;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpPost]
        public HttpResponseMessage Post(string version, string environment, string filetype)
        {
            var path = @"D:\putty.exe";
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

        //private static HttpClient Client { get; } = new HttpClient();
        //[HttpGet]
        //public async Task<IActionResult> Download()
        //{
        //    var path = @"D:\putty.exe";
        //    FileStream streamy = new FileStream(path, FileMode.Open, FileAccess.Read);
        //    Stream streams;
        //    await streamy.CopyToAsync(streamy);
        //    var response = File(streams, "application/octet-stream"); // FileStreamResult
        //    return response;
        //}

        [HttpGet("putty")]
        public FileResult Testy()
        {
            FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes(@"D:\ubuntu.iso"), "application/octet-stream")
            {
                FileDownloadName = "ubuntu.iso"
            };

            return result;
        }
    }
}
