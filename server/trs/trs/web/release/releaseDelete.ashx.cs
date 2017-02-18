using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeRing.BLL;

namespace TakeRing
{
    /// <summary>
    /// releaseDelete 的摘要说明
    /// </summary>
    public class releaseDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String print = "[{";
            var id =Convert.ToInt32(context.Request["id"].Trim());
            carBLL carService = new carBLL();
            int i= carService.Delete(id);
            if (i > 0)
            {
                print += "\"status\":\"1\"";
            }
            else {
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