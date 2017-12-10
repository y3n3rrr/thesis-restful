using CrawlerDataAccess.Database;
using CrawlerDataAccess.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ThesisApp.Controllers
{
    public class CommentController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage CreateComment(int a)//[FromBody]Comment comment
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