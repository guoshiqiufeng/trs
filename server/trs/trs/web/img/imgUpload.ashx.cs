using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TakeRing
{
    /// <summary>
    /// imgUpload 的摘要说明
    /// </summary>
    public class imgUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            
            var token = context.Request["token"].Trim();
            int l = context.Request.Files["uimg"].ContentLength;
            byte[] buffer = new byte[l];
            Stream s = context.Request.Files["uimg"].InputStream;
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(s);
            string imgname = token + ".jpg";
            string path = "../../images/user/";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
            {
               System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            }
            image.Save(context.Server.MapPath(path + "/" + imgname));
           
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