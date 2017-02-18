using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeRing.BLL;
using TakeRing.Model;

namespace TakeRing
{
    /// <summary>
    /// imgUpdate 的摘要说明
    /// </summary>
    public class imgUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String print = "[{";
            var token = context.Request["token"].Trim();
            var uimg = context.Request["uimg"].Trim();
            
            userBLL service = new userBLL();
            user model = new user();
            model.token = token;

            model.uimg = uimg;
            var m = service.imgUpdate(model);
            if (m >= 0)
            {
                print += "\"status\":\"1\"";
            }
            else
            {
                print += "\"status\":\"0\"";
            }
            print += "}]";
            context.Response.Write(print);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}