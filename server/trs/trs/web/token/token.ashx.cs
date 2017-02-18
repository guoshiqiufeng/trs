using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeRing.BLL;
using TakeRing.Model;

namespace TakeRing
{
    /// <summary>
    /// token 的摘要说明
    /// </summary>
    public class token : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String print = "[{";
            var token = context.Request["token"].Trim();
            userBLL service = new userBLL();
            user model = new user();
            model.token = token;
            var m= service.token(model);
            string url ="http://"+ HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port; 
            if (m != null)
            {
                print += "\"status\":\"1\"";
                print += ",\"user\":{";
                print += "\"username\":\"" + m.username + "\"";
                if (m.uimg == null)
                {
                    print += ",\"uimg\":\"" + url + "/images/user/user.jpg" + "\"";
                }
                else 
                {
                    print += ",\"uimg\":\"" + url + m.uimg + "\"";
                }
                print += ",\"usex\":\"" + m.usex + "\"";
                print += ",\"nname\":\"" + m.nick_name + "\"";
                print += ",\"phone\":\"" + m.phone + "\"";
                print += ",\"email\":\"" + m.email + "\"";
                print += "}";
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