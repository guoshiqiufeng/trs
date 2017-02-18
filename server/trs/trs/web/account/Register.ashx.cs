using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeRing.BLL;
using TakeRing.Model;

namespace TakeRing
{
    /// <summary>
    /// Register 的摘要说明
    /// </summary>
    public class Register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String print = "[{";
            var username = context.Request["username"].Trim();
            var password = context.Request["password"].Trim();
            userBLL service = new userBLL();
            user model = new Model.user();
            model.username = username;
            model.password = password.Md5();
            model.nick_name = String.Empty;
            model.phone = String.Empty;
            model.email = String.Empty;
            model.user_type = 0;
            model.uimg = String.Empty;
            Random ran = new Random();
            int RandKey = ran.Next(100, 999);
            string token = username + password + RandKey;
            model.token = token.Md5();
            var a = service.Register(model);
            print += "\"status\":\"" + a + "\"";
            if (a == 1)
            {
                print += ",\"token\":\"" + model.token + "\"";
            }
            else
            {
                print += ",\"token\":\"\"";
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