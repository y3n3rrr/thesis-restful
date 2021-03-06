﻿using CrawlerDataAccess.Database;
using CrawlerDataAccess.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using unirest_net.http;

namespace ThesisApp.Controllers
{
    public class UploadController : ApiController
    {
        const string API_Key= "CT7KKp0OHCmshfLm48OIe8AL6Lo3p19aWkjjsnUXkuzdLQ1A7D";
        [HttpPost, Route("api/upload")]
        public async Task<HttpResponseMessage> Upload()
        {
            
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                if (file.Headers.ContentDisposition.FileName == null)
                    continue;
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var buffer = await file.ReadAsByteArrayAsync();
                //Do whatever you want with filename and its binaray data.

                var stream = new MemoryStream(buffer);

                recognize(FileHelper.generatePath(filename));
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploads/" + filename);
                using (var fileStream = System.IO.File.Create(path))
                {
                    //stream.CopyTo(fileStream);
                    
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, new { JsonResponse= new JsonHandler { Data = "", Message = "Kayit basarili", Success = true }, success = true });
        }

        public void trainApi(string url)
        {
            try
            {
                HttpResponse<dynamic> response = Unirest.post("https://meerkat-frapi.p.mashape.com/train/person")
            .header("X-Mashape-Key", "CT7KKp0OHCmshfLm48OIe8AL6Lo3p19aWkjjsnUXkuzdLQ1A7D")
            .header("api_key", "key1")
            .field("image", File.ReadAllBytes(url))
            .field("label", "yener")
            .asJson<dynamic>();
                int a = 0;
                while (response == null)
                {
                    a++;
                    continue;
                }
            }
            catch(Exception ex)
            {

            }
        }


        public void recognize(string url)
        {
            try
            {
                HttpResponse<dynamic> response = Unirest.post("https://meerkat-frapi.p.mashape.com/recognize/people")
             .header("X-Mashape-Key", "CT7KKp0OHCmshfLm48OIe8AL6Lo3p19aWkjjsnUXkuzdLQ1A7D")
             .header("api_key", "key1")
             .field("image", File.ReadAllBytes(url))
             .asJson<dynamic>();
                int a = 0;
                while (response == null)
                {
                    a++;
                    continue;
                }
            }
            catch (Exception ex)
            {

            }
        }
        [HttpPost]
        public HttpResponseMessage UploadFile(int a)//[FromBody]Comment comment
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(",", ModelState.Values.SelectMany(s => s.Errors, (parent, child) => new { parent.Errors, child.ErrorMessage }).Select(s => s.ErrorMessage).ToList());
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errors);
            }
            return null;
            //using (DatabaseContext context = DatabaseContext.Current)
            //{
            //    int result = context.CommentRepository.CreateComment(comment);
            //    if (result == 0)
            //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Video not found");
            //    else
            //        return Request.CreateResponse(HttpStatusCode.OK, new JsonHandler { Data = "", Message = "Kayit basarili", Success = true });
            //}
        }

        [HttpGet]
        public HttpResponseMessage GetComment(int id)
        {
            return null;
            //using (DatabaseContext context = DatabaseContext.Current)
            //{
            //    List<Comment> comments = context.CommentRepository.GetCommentsOfVideoById(id);
            //    if (comments == null)
            //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Video not found");
            //    return Request.CreateResponse(HttpStatusCode.OK, new JsonHandler { Data = comments, Message = "Kayit basarili", Success = true });
            //}
        }
    }
}