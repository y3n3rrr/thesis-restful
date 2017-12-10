using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ThesisApp.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage SignIn(int a)//[FromBody]User user
        {
            return null;
            //try
            //{
            //    using (DatabaseContext context = DatabaseContext.Current)
            //    {
            //        //int result = context.UserRepository.CreateUser(user);
            //        //if (result == 0)
            //        //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Video not found");
            //        //else
            //        return Request.CreateResponse(HttpStatusCode.OK, new JsonHandler { Data = user, Message = "Kayit basarili", Success = true });
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}
        }

        [HttpPost]
        public HttpResponseMessage CreateUser(int a)//[FromBody]User user
        {
            //try
            //{
            //    using (DatabaseContext context = DatabaseContext.Current)
            //    {
            //        int result = context.UserRepository.CreateUser(user);
            //        if (result == 0)
            //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Video not found");
            //        else
            //            return Request.CreateResponse(HttpStatusCode.OK, new JsonHandler { Data = user, Message = "Kayit basarili", Success = true });
            //    }
            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            //}
            return null;
        }
    }
}
